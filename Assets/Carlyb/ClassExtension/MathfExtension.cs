using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class MathfExtension {

	public static float EulerToRadian(this Mathf mathf, float value){
		return (value * Mathf.PI) / 180;
	}

	public static float RadianToEuler(this Mathf mathf, float value){
		return (value * 180) / Mathf.PI;
	}
}
