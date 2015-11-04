﻿using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	
	float speed;//自機の移動の速さ
	Vector3 movePlayer;//自機の移動
	Vector3 laneMovePlayer;//レーンの変更
	int laneFlg;//今、どのレーンにいるか
	GameObject bulletPrefab;
	float vectorX,vectorY;

	// Use this for initialization
	void Awake () {

		speed = 8.0f;
		laneFlg = 0;
		bulletPrefab = Resources.Load ("Prefab/Bullet") as GameObject;
		//bulletPrefab.AddComponent<Bullet> ();
	}
		
	public void Move(){
		vectorX = Input.GetAxisRaw ("HorizontalP2");
		vectorY = Input.GetAxisRaw ("VerticalP2");
		movePlayer = new Vector3(vectorX * speed, vectorY * speed, 0);
		GetComponent<Rigidbody> ().velocity = movePlayer;
		//レーン移動
		if (Input.GetButtonDown ("L1P2")) {
			if (laneFlg < 1) {
				laneFlg++;
				StartCoroutine("LaneMove");//コルーチンの呼び出し
			}
		}
		if (Input.GetButtonDown ("R1P2")) {
			if (laneFlg > -1) {
				laneFlg--;
				StartCoroutine("LaneMove");//コルーチンの呼び出し
			}
		}
		BulletShot ();

	}

	void BulletShot(){

		if (Input.GetButton("MaruP2")) {
			Instantiate(bulletPrefab, transform.position, transform.rotation);

		}
	}
	IEnumerator LaneMove(){
		while(transform.position.z != laneFlg * 5f){
			laneMovePlayer = new Vector3 (transform.position.x, transform.position.y, laneFlg * 5);
			transform.position = Vector3.MoveTowards (transform.position, laneMovePlayer, 0.5f);
			yield return null;
		}
	}
}
