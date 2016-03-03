// 2/5 Layer切り替え削除・速度調整 byまさ

using UnityEngine;
using System.Collections;

public class BulletStandard : MonoBehaviour {
	
	//弾のスピード
	float bulletSpeed;
	Vector3 direction;
	
	// 初期化
	void Awake(){
		//bulletSpeed = 7000.0f;
		ShotBullet ();
	}
	
	//弾が前に動く
	void ShotBullet()
	{
		direction = transform.forward * bulletSpeed;
		GetComponent<Rigidbody> ().AddForce (direction);
	}
}
