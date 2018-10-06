using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;
using System.IO;

public class CreateAssetBundleEditor {


	public void SetAssetBundleName(Object[] asset,string Name, string Variant) {

		foreach(Object obj in asset.Where(v => v != null)){
		var path = AssetDatabase.GetAssetPath(obj);
		if(path.IndexOf("Resources/")>= 0) return;

		AssetImporter importer = AssetImporter.GetAtPath(path);

		importer.assetBundleName = Name;
		importer.assetBundleVariant = Variant;
		}
	}

	public void buildAssetBundle(string exportPath, BuildAssetBundleOptions buildOption,BuildTarget buildTarget) {
		if(!Directory.Exists(exportPath)) Directory.CreateDirectory(exportPath);
		
		BuildPipeline.BuildAssetBundles(
			exportPath,
			buildOption,
			buildTarget
		);
		AssetDatabase.Refresh();
	}
}

[System.Serializable]
public struct CreateData {
	public string AssetBundleName;
	public string AssetBundleVariant;
	public string path;
	public BuildAssetBundleOptions option;
	public BuildTarget buildTarget;
	public Object[] createObject;
}