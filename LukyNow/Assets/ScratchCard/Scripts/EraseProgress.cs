using UnityEngine;
using UnityEngine.Rendering;

public class EraseProgress : MonoBehaviour
{
	public ScratchCard Card;
	public event ProgressHandler OnProgress;
	public event ProgressHandler OnCompleted;
	public delegate void ProgressHandler(float progress);

	private ScratchCard.ScratchMode scratchMode;
	private RenderTexture renderPercent;
	private RenderTargetIdentifier rti;
	private CommandBuffer commandBuffer;
	private Mesh mesh;
	private float currentProgress;
	public float GetCurrent => currentProgress;
	private bool isCompleted;

	void Awake()
	{
		scratchMode = Card.Mode;
		commandBuffer = new CommandBuffer();
		commandBuffer.name = "EraseProgress";
		CreateRenderTexture();
		rti = new RenderTargetIdentifier(renderPercent);

		mesh = new Mesh();
		mesh.vertices = new[]
		{
			new Vector3(0, 0, 0),
			new Vector3(0, 1, 0),
			new Vector3(1, 1, 0),
			new Vector3(1, 0, 0),
		};
		mesh.uv = new[]
		{
			new Vector2(0, 0),
			new Vector2(0, 1),
			new Vector2(1, 1),
			new Vector2(1, 0),
		};
		mesh.triangles = new[]
		{
			0, 1, 2,
			2, 3, 0
		};
		mesh.colors = new[]
		{
			Color.white,
			Color.white,
			Color.white,
			Color.white
		};
	}

	void Update()
	{
		if (Card.Mode != scratchMode)
		{
			scratchMode = Card.Mode;
			ResetProgress();
		}
		if (Card.IsScratching && !isCompleted)
		{
			UpdateProgress();
		}
	}

	private void CreateRenderTexture()
	{
		renderPercent = new RenderTexture(1, 1, 0, RenderTextureFormat.ARGB32);
		renderPercent.Create();
	}

	private void CalcProgress()
	{
		if (!isCompleted)
		{
			var prevRenderTextureT = RenderTexture.active;
			RenderTexture.active = renderPercent;
			var progressTexture = new Texture2D(renderPercent.width, renderPercent.height, TextureFormat.ARGB32, false, true);
			progressTexture.ReadPixels(new Rect(0, 0, renderPercent.width, renderPercent.height), 0, 0);
			progressTexture.Apply();
			RenderTexture.active = prevRenderTextureT;

			var red = progressTexture.GetPixel(0, 0).r;
			currentProgress = red;
			if (OnProgress != null)
			{
				OnProgress(red);
				var completeValue = Card.Mode == ScratchCard.ScratchMode.Erase ? 1f : 0f;
				if (red == completeValue)
				{
					if (OnCompleted != null)
					{
						OnCompleted(red);
					}
					isCompleted = true;
				}
			}
		}
	}
	
	public float GetProgress()
	{
		return currentProgress;
	}
	public void Clear()
	{
		Card.ClearInstantly();
		ResetProgress();
		UpdateProgress();
		
	}
	public void UpdateProgress()
	{
		GL.LoadOrtho();
		commandBuffer.Clear();
		commandBuffer.SetRenderTarget(rti);
		commandBuffer.DrawMesh(mesh, Matrix4x4.identity, Card.Progress);
		Graphics.ExecuteCommandBuffer(commandBuffer);
		CalcProgress();
		
	}

	public void ResetProgress()
	{
		isCompleted = false;
	}
}