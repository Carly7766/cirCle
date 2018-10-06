using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamingAssetLoader {

	public static T LoadFromFile<T>(string path, string assetName)where T : Object{
		string assetBundlePath = Application.streamingAssetsPath + path;
		AssetBundle assetBundle = AssetBundle.LoadFromFile(assetBundlePath);

		T value = assetBundle.LoadAsset<T>(assetName);
		assetBundle.Unload(false);

		return value;
	}
}
