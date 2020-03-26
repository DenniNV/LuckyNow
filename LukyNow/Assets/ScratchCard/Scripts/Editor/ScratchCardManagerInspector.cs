using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ScratchCardManager))]
public class ScratchCardManagerInspector : Editor
{
	private SerializedProperty camera;
	private SerializedProperty renderType;
	private SerializedProperty card;
	private SerializedProperty mode;
	private SerializedProperty scratchSprite;
	private SerializedProperty eraseTexture;
	private SerializedProperty eraseTextureScale;
	private SerializedProperty progress;
	private SerializedProperty mesh;
	private SerializedProperty sprite;
	private SerializedProperty image;
	private SerializedProperty hasAlpha;
	private SerializedProperty maskProgressCutOffValue;
	private SerializedProperty maskShader;
	private SerializedProperty brushShader;
	private SerializedProperty maskProgressShader;
	private SerializedProperty maskProgressCutOffShader;
	private ScratchCard scratchCard;
	private EraseProgress eraseProgress;
	private Object scratchSurfaceSprite;

	void OnEnable()
	{
		camera = serializedObject.FindProperty("MainCamera");
		renderType = serializedObject.FindProperty("RenderType");
		card = serializedObject.FindProperty("Card");
		mode = serializedObject.FindProperty("Mode");
		scratchSprite = serializedObject.FindProperty("ScratchSurfaceSprite");
		hasAlpha = serializedObject.FindProperty("ScratchSurfaceSpriteHasAlpha");
		maskProgressCutOffValue = serializedObject.FindProperty("MaskProgressCutOffValue");
		eraseTexture = serializedObject.FindProperty("EraseTexture");
		eraseTextureScale = serializedObject.FindProperty("EraseTextureScale");
		progress = serializedObject.FindProperty("Progress");
		mesh = serializedObject.FindProperty("MeshCard");
		sprite = serializedObject.FindProperty("SpriteCard");
		image = serializedObject.FindProperty("ImageCard");
		maskShader = serializedObject.FindProperty("MaskShader");
		brushShader = serializedObject.FindProperty("BrushShader");
		maskProgressShader = serializedObject.FindProperty("MaskProgressShader");
		maskProgressCutOffShader = serializedObject.FindProperty("MaskProgressCutOffShader");
	}

	public override bool RequiresConstantRepaint()
	{
		return card.objectReferenceValue != null && scratchCard != null && scratchCard.RenderTexture != null;
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(camera, new GUIContent("Camera"));
		EditorGUILayout.PropertyField(renderType, new GUIContent("Render Type"));
		EditorGUILayout.PropertyField(scratchSprite, new GUIContent("Sprite"));
		EditorGUI.BeginDisabledGroup(true);
		EditorGUILayout.PropertyField(hasAlpha, new GUIContent("Sprite Has Alpha"));
		EditorGUI.EndDisabledGroup();
		if (hasAlpha.boolValue)
		{
			EditorGUILayout.Slider(maskProgressCutOffValue, 0f, 1f, new GUIContent("Mask Progress Cut Off"));
		}
		EditorGUILayout.PropertyField(eraseTexture, new GUIContent("Brush Texture"));
		var brushScaleChanged = false;
		if (eraseTexture.objectReferenceValue != null)
		{
			if (scratchCard != null)
			{
				eraseTextureScale.vector2Value = scratchCard.BrushScale;
			}
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField(eraseTextureScale, new GUIContent("Brush Texture Scale"));
			brushScaleChanged = EditorGUI.EndChangeCheck();
		}
		EditorGUILayout.PropertyField(card, new GUIContent("Scratch Card"));
		if (scratchCard != null)
		{
			mode.enumValueIndex = (int)scratchCard.Mode;
		}
		EditorGUI.BeginChangeCheck();
		EditorGUILayout.PropertyField(mode, new GUIContent("Scratch Mode"));
		var scratchModeChanged = EditorGUI.EndChangeCheck();
		EditorGUILayout.PropertyField(progress, new GUIContent("Erase Progress"));
		EditorGUILayout.PropertyField(mesh, new GUIContent("Mesh Card"));
		EditorGUILayout.PropertyField(sprite, new GUIContent("Sprite Card"));
		EditorGUILayout.PropertyField(image, new GUIContent("Image Card"));
		if (scratchSurfaceSprite != scratchSprite.objectReferenceValue && scratchSprite.objectReferenceValue != null)
		{
			var path = AssetDatabase.GetAssetPath(scratchSprite.objectReferenceValue);
			var importer = (TextureImporter) AssetImporter.GetAtPath(path);
			if (importer != null)
			{
				hasAlpha.boolValue = importer.DoesSourceTextureHaveAlpha();
				scratchSurfaceSprite = scratchSprite.objectReferenceValue;
			}
		}
		if (maskShader.objectReferenceValue == null)
		{
			EditorGUILayout.PropertyField(maskShader, new GUIContent("Mask Shader"));
		}
		if (brushShader.objectReferenceValue == null)
		{
			EditorGUILayout.PropertyField(brushShader, new GUIContent("Brush Shader"));
		}
		if (maskProgressShader.objectReferenceValue == null)
		{
			EditorGUILayout.PropertyField(maskProgressShader, new GUIContent("Mask Progress Shader"));
		}
		if (maskProgressCutOffShader.objectReferenceValue == null)
		{
			EditorGUILayout.PropertyField(maskProgressCutOffShader, new GUIContent("Mask Progress Cut Off Shader"));
		}
		if (card.objectReferenceValue != null)
		{
			scratchCard = card.objectReferenceValue as ScratchCard;
			if (scratchCard != null)
			{
				if (brushScaleChanged)
				{
					scratchCard.BrushScale = eraseTextureScale.vector2Value;
				}
				if (scratchModeChanged)
				{
					scratchCard.Mode = (ScratchCard.ScratchMode)mode.enumValueIndex;
				}
				if (scratchCard.RenderTexture != null)
				{
					EditorGUILayout.TextArea(string.Empty, GUI.skin.horizontalSlider);
					var rect = GUILayoutUtility.GetRect(160, 120, GUILayout.ExpandWidth(true));
					GUI.DrawTexture(rect, scratchCard.RenderTexture, ScaleMode.ScaleToFit);
					EditorGUILayout.TextArea(string.Empty, GUI.skin.horizontalSlider);

					if (Application.isPlaying)
					{
						if (eraseProgress == null)
						{
							eraseProgress = progress.objectReferenceValue as EraseProgress;
						}

						if (eraseProgress != null)
						{
							EditorGUILayout.LabelField(string.Format("Erase progress: {0}", eraseProgress.GetProgress()));
						}

						if (GUILayout.Button("Clear"))
						{
							scratchCard.ClearInstantly();
							if (progress.objectReferenceValue != null)
							{
								if (eraseProgress != null)
								{
									eraseProgress.ResetProgress();
									eraseProgress.UpdateProgress();
								}
							}
						}

						if (GUILayout.Button("Fill"))
						{
							scratchCard.FillInstantly();
							if (progress.objectReferenceValue != null)
							{
								if (eraseProgress != null)
								{
									eraseProgress.UpdateProgress();
								}
							}
						}
					}
				}
			}
		}
		serializedObject.ApplyModifiedProperties();
	}
}