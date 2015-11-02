using UnityEngine;
using System.Collections;

public class Player3DBulletShot : MonoBehaviour {

	//弾を設定
	GameObject player3DBullet;

	void Awake(){
		player3DBullet = Resources.Load ("Prefab/bullet") as GameObject;
	}

	//弾を発射（弾を呼び出す）
	public void ShotBullet(){
		Instantiate(player3DBullet,transform.position,transform.rotation);
	}
}