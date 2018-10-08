using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CustomMonoBehaviour {

	private List<Joycon> joycons;

	[SerializeField]
	private GameObject originalTurret;   //タレットのプレファブ	セーブで読み込む方式の実装時に変えること

	[SerializeField]
	private PlayerParameter parameter;
	[SerializeField]
	private Turret[] turrets;

	//Joyconを取得する関数(あとで何か変更するかも)
	private void GetJoycon() {
		joycons = JoyconManager.Instance.j;
	}

#region default event function
	private void Awake() {
		GetJoycon();
		
		SettingPlayer();
		SettingTurret();
	}

	private void Update() {
	}

	private void FixedUpdate() {
		TurretTurn();
		PlayerMove();
	}
#endregion

#region  Initialize Settings

	private void SettingPlayer() {

	}

	private void SettingTurret() {

		//あとでセーブデータ読み込む実装の時とかに変えろ

		//ジョイコンの数だけ砲台をインスタンス化
			turrets = new Turret[joycons.Count];
		//砲台が配列なのでコンストラクタが呼ばれない => forで回してコンストラクタを明示的に呼び出す
		for(int i = 0; i < joycons.Count; i++){
			turrets[i] = new Turret(originalTurret, transform);
		}
	}
#endregion

#region Controls
	//砲台の回転処理
	private void TurretTurn() {
		for(int i = 0; i < joycons.Count; i++) {
			Turret inProcTurret = turrets[i];
			Joycon inProcJoycon = joycons[i];

			//砲台の角度を加算
			inProcTurret.rotation += inProcJoycon.GetGyro().z * inProcTurret.trunSpeed * Time.fixedDeltaTime;

			//角度、砲台からプレイヤーまでの距離を元に砲台の位置を計算
			float x = Mathf.Cos(-inProcTurret.rotation) * inProcTurret.trunRadius * transform.localScale.x;
			float y = Mathf.Sin(-inProcTurret.rotation) * inProcTurret.trunRadius * transform.localScale.y;

			//計算した位置に砲台を移動
			inProcTurret.transform.SetPosition(new Vector3(x,y) + transform.position);

			//プレイヤーから砲台までの方向ベクトルを計算して正規化
			Vector2 lookDir = (inProcTurret.transform.position - transform.position).normalized;

			//方向ベクトルを元に砲台の向きを変える
			inProcTurret.transform.LookAt2D(lookDir);
		}
	}

	//プレイヤーの移動
	private void PlayerMove() {
		for(int i = 0; i < joycons.Count; i++) {
			Joycon inProcJoycon = joycons[i];

			//スティックの入力値をジョイコンの数分格納
			Vector2 stickInput = (new Vector2(inProcJoycon.GetStick()[0], inProcJoycon.GetStick()[1]) * parameter.moveSpeed);

			parameter.moveVel += EasingLerps.OutQuad(parameter.oldVel, stickInput, parameter.accelSpeed * Time.fixedDeltaTime) / joycons.Count;
		}
		//格納された値を補間して速度に代入
		rigidbody2D.velocity = parameter.moveVel;
		parameter.ResetVel();

	}
#endregion
}