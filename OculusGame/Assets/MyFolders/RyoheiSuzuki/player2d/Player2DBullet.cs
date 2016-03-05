﻿//////////////////////////////
// 
// 2016/02/16
// 中村圭吾
// player2dの弾作成
// 円周移動
// 初期位置のバグ
// Awake時に角度が0なのが問題
//////////////////////////////
// 2016/02/18 鈴木
// 初期位置のバグ修正
// BulletDestroy修正
// class内容変更
// 2016/03/04 梅村　ホーミング弾追加
using UnityEngine;
using System.Collections;

public class Player2DBullet : MonoBehaviour {
	
	const float PAI = 3.14f;
	float bulletDegree; // 角度
	[SerializeField]
	float radius; // 半径
	[SerializeField]
	float bulletSpeed;
	[SerializeField]
	float degreeSpace;	// 発射する弾の位置調整用
	float bulletLife;
	Vector3 shotPosition;
	int shotBulletWay;	// 発射する弾の向き
	string bulletType; //弾の種類
	[SerializeField]
	Transform homingTarget;	
	//自身の進む方向と出現角度
	//bulletInit(進む方向'R'or'L',出現角度　player2dの角度など);
	public void BulletInit(char receiveVariable,float player2dDegree,float player2dPositionY,string type){
		transform.position = new Vector3(transform.position.x, player2dPositionY + Random.Range(-1, 1), transform.position.z + Random.Range(-1, 1));
		if(receiveVariable == 'R'){
			shotBulletWay = 1;
			bulletDegree = player2dDegree+degreeSpace;
		}else if(receiveVariable == 'L'){
			shotBulletWay = -1;
			bulletDegree = player2dDegree-degreeSpace;
			Debug.Log("前"+transform.eulerAngles);
			transform.Rotate(new Vector3(0,180,0));
			Debug.Log("後"+transform.eulerAngles);
		}
		bulletType = type;
		
		switch(type){
		case "NomalBullet":
			bulletSpeed = 7;
			bulletLife = radius * 1.4f;
			break;
		case "HomingMissile":
			bulletSpeed = 2;
			Destroy (gameObject, 1.0f);
			StartCoroutine(Search());
			break;
		}
	}
	
	// Use this for initialization
	void Awake () {
		shotPosition = transform.position;
		//EffectFactory.Instance.Create("flash", transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		ShotMove ();
	}
	void degreeWay(int bulletWay){
		switch (bulletWay) {
		case 1:
			bulletDegree += bulletSpeed;
			break;
		case -1:
			bulletDegree -= bulletSpeed;
			break;
		}
	}
	
	void ShotMove(){
		switch(bulletType){
		case "NomalBullet":
			degreeWay (shotBulletWay);
			transform.position = new Vector3 (radius * Mathf.Cos (PAI / 180 * bulletDegree), transform.position.y,radius * Mathf.Sin (PAI / 180 * bulletDegree));
			transform.eulerAngles = new Vector3 (0, -bulletDegree, 0);
			BulletDestroy ();
			break;
		case "HomingMissile":
			if(homingTarget == null){
				degreeWay (shotBulletWay);
				transform.position = new Vector3 (radius * Mathf.Cos (PAI / 180 * bulletDegree), transform.position.y,radius * Mathf.Sin (PAI / 180 * bulletDegree));
				transform.eulerAngles = new Vector3 (0, -bulletDegree, 0);
			}
			else{
				Homing();
			}
			break;
		}
	}
	
	void BulletDestroy(){
		if(bulletLife < Vector3.Distance(transform.position, shotPosition)){
			Destroy(gameObject);
		}
	}
	
	IEnumerator Search(){
		Ray searchRay = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		while(homingTarget == null){
			if(Physics.SphereCast (searchRay, 30f, out hit, 30f)){
				
				if(hit.collider.tag == "Enemy" || hit.collider.tag == "Boss"){
					homingTarget = hit.collider.transform;
				}

			}
			yield return new WaitForSeconds(0.1f);
		}
		bulletSpeed = 4;
	}
	
	void Homing(){
		Vector3 vec = homingTarget.position - transform.position;
		
		// ターゲットの方向を向く
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, vec.y, vec.z)), 1f);
		transform.Translate(Vector3.forward * bulletSpeed); // 正面方向に移動
	}
	
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag)
		{
		case "Boss":
		case "Enemy":
			Destroy(gameObject);
			break;
			
		default:
			//Destroy(gameObject);
			break;
		}
		
	}
}
