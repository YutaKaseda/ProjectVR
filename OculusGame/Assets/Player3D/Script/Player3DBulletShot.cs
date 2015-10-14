using UnityEngine;
using System.Collections;

public class Player3DBulletShot : MonoBehaviour {

	//弾を設定
	[SerializeField]
	private GameObject player3DBullet;

	//プレイヤーを設定
	[SerializeField]
	private Transform player;

	// Update is called once per frame
	void Update () {
		ShotBullet ();
	}

	//弾を発射（弾を呼び出す）
	void ShotBullet(){
		Instantiate(player3DBullet,player.position,player.rotation);
	}
}