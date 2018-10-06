using System.Collections;
using UnityEngine;

public static partial class GameObjectExtension {

	public static GameObject Instantiate(this GameObject gameObject, Object original) {
		return GameObject.Instantiate(original) as GameObject;
		}

		public static GameObject Instantiate(this GameObject gameObject, GameObject original, Vector3 position) {
			return GameObject.Instantiate(original, position, Quaternion.identity) as GameObject;
		}

		public static GameObject Instantiate(this GameObject gameObject, GameObject original, Vector3 position, Quaternion rotation) {
			return GameObject.Instantiate(original,position,rotation) as GameObject;
		}
}