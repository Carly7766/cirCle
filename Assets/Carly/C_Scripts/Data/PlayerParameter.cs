using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerParameter {

	public bool isAction;   //trueの場合、プレイヤーの射撃、移動を制限する
	public bool doNotTrun;   //trueの場合、砲台の動きを制限する

	Material material;   //プレイヤーオブジェクトのマテリアル

	public Vector3 moveVel, oldVel;   //プレイヤーの移動量
}
