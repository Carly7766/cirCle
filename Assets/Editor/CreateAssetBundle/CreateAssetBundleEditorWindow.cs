using System.Collections;
using UnityEngine;
using UnityEditor;

public class CreateAssetBundleEditorWindow : ScriptableWizard {

	[MenuItem ("Window/Create Asset Bundle")]
	private static void Open() {
		DisplayWizard<CreateAssetBundleEditorWindow>("Create Asset Bundle","Create","SetName");
	}

	private void OnEnable() {
		Data.buildTarget = BuildTarget.NoTarget;
		size = 1;
		Data.createObject = new Object[size];
	}

	private CreateData Data = new CreateData();
	private CreateAssetBundleEditor editor = new CreateAssetBundleEditor();
	private int size;

	protected override bool DrawWizardGUI() {
		GUI.skin.label.fontSize = 14;

		GUILayout.Label("Export Settings");
		Data.path = EditorGUILayout.TextField("Build Path", Data.path);
		Data.option = (BuildAssetBundleOptions)EditorGUILayout.EnumPopup("Build Option", Data.option);
		Data.buildTarget = (BuildTarget)EditorGUILayout.EnumPopup("Build Target", Data.buildTarget);

		EditorGUILayout.Space();

		GUILayout.Label("Create Assets");

		Data.AssetBundleName = EditorGUILayout.TextField("Asset Bundle Name", Data.AssetBundleName);
		Data.AssetBundleVariant = EditorGUILayout.TextField("Variant",Data.AssetBundleVariant);

		EditorGUILayout.Space();

		EditorGUI.BeginChangeCheck();
		size = EditorGUILayout.IntField("Size", size);
		if(EditorGUI.EndChangeCheck()){
			Data.createObject = new Object[size];
		}

		for(int i = 0; i < size; i++){
			Data.createObject[i] = EditorGUILayout.ObjectField("Build Asset",Data.createObject[i], typeof(Object));
		}

		if(string.IsNullOrEmpty(Data.AssetBundleName))Data.AssetBundleName = "streamingassets";
		if(string.IsNullOrEmpty(Data.path))Data.path = "Assets/StreamingAssets";


		return true;
	}


	private void OnWizardCreate() {
		editor.buildAssetBundle(Data.path,Data.option,Data.buildTarget);
	}

	private void OnWizardOtherButton() {
		editor.SetAssetBundleName(Data.createObject, Data.AssetBundleName, Data.AssetBundleVariant);
	}
}
