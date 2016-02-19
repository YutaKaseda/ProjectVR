// 2/19 まさ 他のボス関係との結合
// 2月～19日　瀧本　基礎(TargetBullet,OnCollisionEnter);

using UnityEngine;
using System.Collections;

public class BossBullet: MonoBehaviour {


	float bulletSpeed = 10000;
	Vector3 direction;

	void Awake(){
		Destroy (gameObject, 3f);
	}
	//方向変換
	//狙うプレイヤーのVector3	入れて呼ぶ
	public void TargetBullet(Vector3 target){
		transform.LookAt (target);
		direction = transform.forward * bulletSpeed;
		GetComponent<Rigidbody> ().AddForce(direction);
	}
}
