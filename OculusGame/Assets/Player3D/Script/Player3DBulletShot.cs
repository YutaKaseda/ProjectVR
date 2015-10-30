using UnityEngine;
using System.Collections;

public class Player3DBulletShot : MonoBehaviour {

	//弾を設定
	GameObject player3DBullet;

	void Awake(){
		player3DBullet = Resources.Load ("Prefab/bullet") as GameObject;
	}

	//ここはShotBulletを呼び出せばいつでも弾がだせるよという意味で
	void Update () {
		ShotBullet ();
	}

	//弾を発射（弾を呼び出す）
    public void ShotBullet()
    {
		Instantiate(player3DBullet,transform.position,transform.rotation);
	}
}