//　2/18　まさ　ヘイト関係処理改変
// 2/19 梅村 地獄のリファクタ
using UnityEngine;
using System.Collections;

public class BossMk2 : MonoBehaviour {
	GameObject player2D;
	GameObject player3D;
	BossData bossData;

	Vector3 targetPos;//プレイヤーの位置
	[SerializeField]
	float bossRotationSpeed;//ボス振り向き速度
	int warpPointNumber;//ワープポイントの数
	int nowPositionNumber;//今いるワープポイント
	int nextPositionNumber;//次に行くワープポイント
	
	[SerializeField]
	public GameObject [] warpPoint;
	
	[SerializeField]
	GameObject bossBullet;
	[SerializeField]
	GameObject bossRailgun;
	
	int attackPattern;//ボスの攻撃パターン
	float attackTime;//攻撃までの時間
	int bulletCnt;//弾を撃った数

	Transform targetPlayer2D,targetPlayer3D;
	Vector3 targetPlayerVec2D, targetPlayerVec3D;
	GameObject targetPlayerObject;
	[SerializeField]
	GameObject enemyCreateObj;

	public void Init(){
		player2D = GameObject.FindWithTag ("Player2D");
		player3D = GameObject.FindWithTag ("Player3D");
		bossRailgun = GameObject.FindWithTag ("Railgun");
		bossRailgun.SetActive (false);
		targetPlayer2D = player2D.transform;
		targetPlayer3D = player3D.transform;
		bossData = GetComponent<BossData>();
		bossRotationSpeed = 0.6f;
		warpPointNumber = warpPoint.Length;
		nowPositionNumber = 0;
		nextPositionNumber = 0;
		attackPattern = 0;
		attackTime = 0f;
       
	}


	public void Main(){
		LockOn ();
		AttackPattern ();
	}

	void LockOn(){
		switch(bossData.bossAttackTarget){
		case BossData.TARGET2D:
			targetPos = player2D.transform.position;
			break;
		case BossData.TARGET3D:
			targetPos = player3D.transform.position;
			break;
		default:
			break;
		}
	}

	void Warp(){
		this.transform.position = WarpPointGet();
	}
	
	Vector3 WarpPointGet(){
		while (nowPositionNumber == nextPositionNumber) {
			nextPositionNumber = Random.Range (0, warpPointNumber);
		}
		nowPositionNumber = nextPositionNumber;
		if (attackPattern == BossData.BOSS_PATTERN_RAILGUN)
			nowPositionNumber = 4;
		return warpPoint [nowPositionNumber].transform.position;
	}
	
	Quaternion CalcRotationLeap(Vector3 targetPos){
		var rotation = Quaternion.LookRotation(targetPos - transform.position);
		return Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * bossRotationSpeed);
	}


	void AttackPattern(){
		attackTime += Time.deltaTime;
		switch (attackPattern) {
		case BossData.BOSS_PATTERN_STAY:
			Stay ();
			break;
		case BossData.BOSS_PATTERN_VULCAN:
			Vulcan ();
			break;
		case BossData.BOSS_PATTERN_RAILGUN:
			StartCoroutine(Railgun());
			break;
		case BossData.BOSS_PATTERN_TACKLE:
			Tackle ();
			break;
		case BossData.BOSS_PATTERN_ENEMY_CREATE:
			StartCoroutine(EnemyCreate());
			break;
        case BossData.BOSS_PATTERN_NULL:
            break;
            default:
            Debug.LogError("AttackPattern指定ミス");
            break;
		}
	}
	
	//待機時間
	//呼ぶだけ
	void Stay(){
        transform.rotation = CalcRotationLeap(targetPos);
		if (attackTime >= 3f) {
			attackTime = 0;
			attackPattern = Random.Range(1,3);

		}
	}
	//Balkan攻撃
	//呼ぶだけ
	void Vulcan(){
		if (attackTime >= 0.2f) {
			attackTime = 0;
			switch(bossData.bossAttackTarget){
			case BossData.TARGET2D:
				targetPlayerVec2D = targetPlayer2D.transform.position;
				targetPlayerObject = Instantiate (bossBullet, transform.position, Quaternion.identity) as GameObject;
				targetPlayerObject.GetComponent<BossBullet> ().TargetBullet (targetPlayerVec2D);	
				break;
			case BossData.TARGET3D:
				targetPlayerVec3D = targetPlayer3D.transform.position;
				targetPlayerObject = Instantiate (bossBullet, transform.position, Quaternion.identity) as GameObject;
				targetPlayerObject.GetComponent<BossBullet> ().TargetBullet (targetPlayerVec3D);
				break;
			default:
				break;
			}
			
			bulletCnt += 1;
		}
		if (bulletCnt >= 50) {
			attackTime = 0;
			attackPattern = BossData.BOSS_PATTERN_STAY;
			bulletCnt = 0;
		}
	}
	//Railgun
	//呼ぶだけ
	IEnumerator Railgun(){
		attackPattern = BossData.BOSS_PATTERN_NULL;
		SoundPlayer.Instance.PlaySoundEffect ("charge", 1.0f);
		EffectFactory.Instance.Create ("concentration",transform.position,transform.rotation);
		while(attackTime <= 3f){
			yield return null;
		}
		if (attackTime >= 3f) {
			SoundPlayer.Instance.PlaySoundEffect ("Railgun", 1.0f);
            SoundPlayer.Instance.PlaySoundEffect("thunder", 1.0f);
			bossRailgun.SetActive (true);
			yield return new WaitForSeconds(4.0f);
		}
		if (attackTime >= 4f) {
			attackPattern = BossData.BOSS_PATTERN_STAY;
			attackTime = 0;
			bossRailgun.SetActive (false);
			Warp();
		}
		
	}

	void Tackle(){
		if(attackTime <= 6f){
			transform.rotation = CalcRotationLeap(targetPos);
		}
		if(attackTime > 6f){
			transform.TransformDirection(0,0,1);
		}
		if(attackTime > 12f){
			attackPattern = BossData.BOSS_PATTERN_STAY;
			attackTime = 0;
			Warp();
		}
	}

	IEnumerator EnemyCreate(){
		attackPattern = BossData.BOSS_PATTERN_NULL;
		while(attackTime <= 3f){
			transform.rotation = CalcRotationLeap(targetPos);
			yield return null;
		}
		if (attackTime >= 3f) {
			for(int i = 0;i < 10;i++){
			Instantiate(enemyCreateObj,new Vector3(transform.position.x + Random.Range(-100,100),
			                                       transform.position.y + Random.Range(-100,100),
			                                       transform.position.z + Random.Range(-100,100)),transform.rotation);
				yield return new WaitForSeconds(1.0f);
			}
		}
		attackPattern = BossData.BOSS_PATTERN_STAY;
		attackTime = 0;
		Warp();
	}
}
