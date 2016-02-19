//　2/18　まさ　ヘイト関係処理改変
// 2/19 梅村 地獄のリファクタ
using UnityEngine;
using System.Collections;

public class BossMk2 : MonoBehaviour {
	GameObject player2D;
	GameObject player3D;
	BossData bossData;

	Vector3 targetPos;
	float bossRotationSpeed;
	float bossWaitTime;
	Vector3 warpPosition;
	int warpPointNumber;
	int nowPositionNumber = 0;
	int nextPositionNumber = 0;
	
	[SerializeField]
	public GameObject [] warpPoint = new GameObject[1];
	
	[SerializeField]
	GameObject bossBullet;
	[SerializeField]
	GameObject bossRailgun;
	
	int attackPattern = 1;
	float attackTime = 0f;
	int Bullet;

	Transform targetPlayer2D,targetPlayer3D;
	Vector3 targetPlayerVec2D, targetPlayerVec3D;
	GameObject targetPlayerObject;

	void Awake(){
		player2D = GameObject.FindWithTag ("Player2D");
		player3D = GameObject.FindWithTag ("Player3D");
		targetPlayer2D = player2D.transform;
		targetPlayer3D = player3D.transform;
		bossData = GetComponent<BossData>();
		bossRotationSpeed = 0.6f;
		bossWaitTime = 8.0f;
		warpPointNumber = warpPoint.Length;
	}

	public void Main(){
		LockOn ();
		AttackPattern ();
	}

	void LockOn(){
		switch(bossData.bossAttackTarget){
		case 1:
			targetPos = player2D.transform.position;
			break;
		case 2:
			targetPos = player3D.transform.position;
			break;
		default:
			break;
		}
		transform.rotation = CalcRotationLeap(targetPos);
	}

	void Warp(){
		this.transform.position = WarpPointGet(warpPosition);
	}
	
	Vector3 WarpPointGet(Vector3 pos){
		while (nowPositionNumber == nextPositionNumber) {
			nextPositionNumber = Random.Range (0, warpPointNumber);
		}
		nowPositionNumber = nextPositionNumber;
		return warpPoint [nowPositionNumber].transform.position;
	}
	
	Quaternion CalcRotationLeap(Vector3 targetPos){
		var rotation = Quaternion.LookRotation(targetPos - transform.position);
		return Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * bossRotationSpeed);
	}


	void AttackPattern(){
		attackTime += Time.deltaTime;
		switch (attackPattern) {
		case 0:
			Stay ();
			break;
		case 1:
			Vulcan ();
			break;
		case 2:
			Railgun();
			break;
		}
	}
	
	//待機時間
	//呼ぶだけ
	void Stay(){
		if (attackTime >= 8f) {
			attackTime = 0;
			attackPattern = Random.Range(1,3);
			Warp();
		}
	}
	//Balkan攻撃
	//呼ぶだけ
	void Vulcan(){
		if (attackTime >= 0.2f) {
			attackTime = 0;
			switch(bossData.bossAttackTarget){
			case 1:
				targetPlayerVec2D = targetPlayer2D.transform.position;
				targetPlayerObject = Instantiate (bossBullet, transform.position, Quaternion.identity) as GameObject;
				targetPlayerObject.GetComponent<BossBullet> ().TargetBullet (targetPlayerVec2D);	
				break;
			case 2:
				targetPlayerVec3D = targetPlayer3D.transform.position;
				targetPlayerObject = Instantiate (bossBullet, transform.position, Quaternion.identity) as GameObject;
				targetPlayerObject.GetComponent<BossBullet> ().TargetBullet (targetPlayerVec3D);
				break;
			default:
				break;
			}
			
			Bullet += 1;
		}
		if (Bullet >= 50) {
			attackTime = 0;
			attackPattern = 0;
			Bullet = 0;
		}
	}
	//Railgun
	//呼ぶだけ
	void Railgun(){
		if (attackTime >= 10f) {
			attackPattern = 0;
			attackTime = 0;
			switch(bossData.bossAttackTarget){
			case 1:
				targetPlayerVec2D = targetPlayer2D.transform.position;
				targetPlayerObject = Instantiate (bossRailgun, transform.position, Quaternion.identity) as GameObject;
				targetPlayerObject.GetComponent<Railgun> ().TargetBullet (targetPlayerVec2D);
				break;
			case 2:
				targetPlayerVec3D = targetPlayer3D.transform.position;
				targetPlayerObject = Instantiate (bossRailgun, transform.position, Quaternion.identity) as GameObject;
				targetPlayerObject.GetComponent<Railgun> ().TargetBullet (targetPlayerVec3D);
				break;
			default:
				break;
			}
		}
	}
}
