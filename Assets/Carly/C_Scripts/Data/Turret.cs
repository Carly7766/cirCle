using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* このクラスは砲台のパラメータを持っているのではなく砲台そのものとして扱う */
[System.Serializable]
public class Turret {

    public float RadianAngle;   //砲台の角度(ラジアン)
    public float rotation;
    public float trunSpeed = 3;   //砲台が回るスピード
    public float trunRadius = 2.4f;   //砲台の回転半径
    public float turretLength = 1.3f;   //砲台の先端までの長さ

    public Transform transform;
    public Color color;   //タレットの色
    public Sprite sprite;   //タレットの画像
    GameObject Bullet;   //撃つ弾の種類

    SpriteRenderer renderer;
    GameObject gameObject;

    public Turret(GameObject original, Transform parent) {
        gameObject = GameObject.Instantiate(original);
        
        transform = gameObject.GetComponent<Transform>();
        transform.parent = parent;

        renderer = gameObject.GetComponent<SpriteRenderer>();
    }
}