//////////////////////////////
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

	//自身の進む方向と出現角度
	//bulletInit(進む方向'R'or'L',出現角度　player2dの角度など);
	public void BulletInit(char receiveVariable,float player2dDegree,float player2dPositionY){
		transform.position = new Vector3 (transform.position.x, player2dPositionY, transform.position.z);
		if(receiveVariable == 'R'){
			shotBulletWay = 1;
			bulletDegree = player2dDegree+degreeSpace;
		}else if(receiveVariable == 'L'){
			shotBulletWay = -1;
			bulletDegree = player2dDegree-degreeSpace;
		}
	}

	// Use this for initialization
	void Awake () {
		shotPosition = transform.position;
		bulletLife = radius * 1.4f;
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
		degreeWay (shotBulletWay);
		transform.position = new Vector3 (radius * Mathf.Cos (PAI / 180 * bulletDegree), transform.position.y,radius * Mathf.Sin (PAI / 180 * bulletDegree));
		transform.eulerAngles = new Vector3 (0, -bulletDegree, 0);
		BulletDestroy ();
	}

	void BulletDestroy(){
		if(bulletLife < Vector3.Distance(transform.position, shotPosition)){
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag)
		{
		default:
			Destroy(gameObject);
			break;
		}
		
	}
}
