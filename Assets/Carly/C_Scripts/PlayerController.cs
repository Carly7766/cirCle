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
		//接続されているジョイコンの数だけ処理をする
		for(int i = 0; i < joycons.Count; i++) {
			//操作するジョイコンと砲台を配列から持ってくる
			Turret selectTurret = turrets[i];
			Joycon selectJoycon = joycons[i];

			//砲台の角度をラジアン角で加算
			selectTurret.rotation += selectJoycon.GetGyro().z * selectTurret.trunSpeed * Time.fixedDeltaTime;

			//角度、砲台からプレイヤーまでの距離を元に砲台の位置を計算
			float x = Mathf.Cos(-selectTurret.rotation) * selectTurret.trunRadius * transform.localScale.x;
			float y = Mathf.Sin(-selectTurret.rotation) * selectTurret.trunRadius * transform.localScale.y;

			//計算した位置に砲台を移動
			selectTurret.transform.SetPosition(new Vector3(x,y) + transform.position);

			//プレイヤーから砲台までの方向ベクトルを計算して正規化
			Vector2 lookDir = (selectTurret.transform.position - transform.position).normalized;

			//方向ベクトルを元に砲台の向きを変える
			selectTurret.transform.LookAt2D(lookDir);
		}
	}

	//プレイヤーの移動
	private void PlayerMove() {
		for(int i = 0; i < joycons.Count; i++) {
			Joycon selectJoycon = joycons[i];

			//プレイヤーの移動速度を設定
			/*parameter.moveVel = new Vector3(selectJoycon.GetStick()[0], selectJoycon.GetStick()[1]) / joycons.Count;
			if(joycons.Count == i + 1){
			rigidbody2D.velocity = EaseLerp.Lin(parameter.moveVel, parameter.oldVel, 2f);
			parameter.oldVel = parameter.moveVel;
			}*/
		}
	}
#endregion

}
