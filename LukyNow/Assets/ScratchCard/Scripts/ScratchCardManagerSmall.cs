using UnityEngine;
using UnityEngine.UI;

public class ScratchCardManagerSmall : MonoBehaviour
{
	public enum ScratchCardRenderType
	{
		MeshRenderer,
		SpriteRenderer,
		CanvasRenderer
	}

	public Camera MainCamera;
	public ScratchCardRenderType RenderType;
	public Sprite ScratchSurfaceSprite;
	public bool ScratchSurfaceSpriteHasAlpha;
	public float MaskProgressCutOffValue = 0.33f;
	public Texture EraseTexture;
	public Vector2 EraseTextureScale = Vector2.one;
	public ScratchCard Card;
	public ScratchCard.ScratchMode Mode;
	public EraseProgress Progress;
	public GameObject MeshCard;
	public GameObject SpriteCard;
	public GameObject ImageCard;

	public Shader MaskShader;
	public Shader BrushShader;
	public Shader MaskProgressShader;
	public Shader MaskProgressCutOffShader;

	private Material eraserMaterial;
	private const string MaskProgressCutOffField = "_CutOff";

	//private void Clear()
	//{
	//	Card.ClearInstantly();
	//	if (Progress != null)
	//	{
	//		Progress.ResetProgress();
	//		Progress.UpdateProgress();
	//	}
	//}

	private void OnEnable()
	{
		SetSprite();
	}
	public void SetSprite()
	{
		Material scratchSurfaceMaterial = null;
		scratchSurfaceMaterial = new Material(MaskShader) { mainTexture = ScratchSurfaceSprite.texture };
		Card.ScratchSurface = scratchSurfaceMaterial;
		var image = ImageCard.GetComponent<Image>();
		image.sprite = ScratchSurfaceSprite;
		image.material = scratchSurfaceMaterial;
		Card.Config();
	}

	void Awake()
	{
		Config();
	}
	
	private void Config()
	{
		if (Card.MainCamera == null)
		{
			Card.MainCamera = MainCamera != null ? MainCamera : Camera.main;
		}

		Material scratchSurfaceMaterial = null;
		if (Card.ScratchSurface == null)
		{
			scratchSurfaceMaterial = new Material(MaskShader) { mainTexture = ScratchSurfaceSprite.texture };
			Card.ScratchSurface = scratchSurfaceMaterial;
		}

		if (Card.Eraser == null)
		{
			eraserMaterial = new Material(BrushShader) { mainTexture = EraseTexture };
			Card.Eraser = eraserMaterial;
		}

		Card.BrushScale = EraseTextureScale;
		Card.Mode = Mode;

		if (Card.Progress == null)
		{
			var shader = ScratchSurfaceSpriteHasAlpha ? MaskProgressCutOffShader : MaskProgressShader;
			var progressMaterial = new Material(shader);
			if (ScratchSurfaceSpriteHasAlpha)
			{
				progressMaterial.SetFloat(MaskProgressCutOffField, MaskProgressCutOffValue);
			}
			Card.Progress = progressMaterial;
		}

		if (RenderType == ScratchCardRenderType.MeshRenderer)
		{
			MeshCard.SetActive(true);
			if (SpriteCard != null)
			{
				SpriteCard.SetActive(false);
			}
			if (ImageCard != null)
			{
				ImageCard.SetActive(false);
			}
			Card.Surface = MeshCard.transform;
			MeshCard.GetComponent<Renderer>().material = scratchSurfaceMaterial;
		}
		else if (RenderType == ScratchCardRenderType.SpriteRenderer)
		{
			if (MeshCard != null)
			{
				MeshCard.SetActive(false);
			}
			SpriteCard.SetActive(true);
			if (ImageCard != null)
			{
				ImageCard.SetActive(false);
			}
			Card.Surface = SpriteCard.transform;
			var sprite = SpriteCard.GetComponent<SpriteRenderer>();
			sprite.sprite = ScratchSurfaceSprite;
			sprite.material = scratchSurfaceMaterial;
		}
		else if (RenderType == ScratchCardRenderType.CanvasRenderer)
		{
			if (MeshCard != null)
			{
				MeshCard.SetActive(false);
			}
			if (SpriteCard != null)
			{
				SpriteCard.SetActive(false);
			}
			ImageCard.SetActive(true);
			Card.Surface = ImageCard.transform;
			var image = ImageCard.GetComponent<Image>();
			image.sprite = ScratchSurfaceSprite;
			image.material = scratchSurfaceMaterial;
		}
	}
	public void SetEraseTexture(Texture texture)
	{
		eraserMaterial.mainTexture = texture;
	}
	public void ResetScratchCard()
	{
		Card.Reset();
	}
}