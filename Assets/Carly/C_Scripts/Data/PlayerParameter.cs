using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerParameter {

	public bool isAction;   //trueの場合、プレイヤーの射撃、移動を制限する
	public bool doNotTrun;   //trueの場合、砲台の動きを制限する

	public Material material;   //プレイヤーオブジェクトのマテリアル

	public float moveSpeed, accelSpeed;

	public Vector3 moveVel, oldVel;   //プレイヤーの移動量

	public void ResetVel() {
		oldVel = moveVel;
		moveVel = new Vector3(0,0,0);
	}
}
