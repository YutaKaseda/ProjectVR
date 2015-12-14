using UnityEngine;
using System.Collections;

public class BaseBeacon : MonoBehaviour {
	enum beaconState{ENEMYCHARACTER, ENEMYBULLET}; //ダメージを受ける条件：敵キャラ、弾に当たる、自爆
	[SerializeField]
	int baseBeaconLife;
	GameObject explosion; //爆発時のエフェクト
	
	void Awake () {	
		baseBeaconLife = 30;	//ベースビーコンのHP
		//explosion = Resources.Load ("Prefab/Explosion") as GameObject; 
		//↓に変更
		ResourcesManager.Instance.ResourcesLoadScene ("Play");
		
		// 設置時に3DPlayerを生成して・Waveが始まる
		CreatePlayer3D ();
		// Waveの開始
		
	}
	
	//ビーコンのHP減少
	void OnTriggerEnter(Collider Enemy){
		if (Enemy.gameObject.tag == "EnemyBullet") {
			BeaconDamage (beaconState.ENEMYBULLET);
		} else if (Enemy.gameObject.tag == "EnemyCharacter") {
			BeaconDamage (beaconState.ENEMYCHARACTER);
		}
		//ビーコンの耐久値が０以下になった時、爆発エフェクト・ゲームオーバーへ
		if (baseBeaconLife <= 0 ) {
			// 爆発エフェクト
			Instantiate(ResourcesManager.Instance.GetResourceScene("Bom"), transform.position, transform.rotation);
			//ゲームオーバーへ遷移
			
		}
	}
	//HP減少条件
	void BeaconDamage(beaconState life){
		switch (life) {
			//敵キャラが当たった時
		case beaconState.ENEMYCHARACTER:
			baseBeaconLife -= 2;
			Debug.Log("EnemyHit");
			Debug.Log(baseBeaconLife);
			break;
			//敵の弾が当たった時
		case beaconState.ENEMYBULLET:
			baseBeaconLife --;
			Debug.Log("BulletHit");
			Debug.Log(baseBeaconLife);
			break;
		default:
			break;
		}
	}
	//Player3Dの生成
	void CreatePlayer3D(){
		Instantiate (ResourcesManager.Instance.GetResourceScene ("Player3D"),
		             transform.position, transform.rotation);
		Debug.Log ("CreatePlayer3D");
	}
	
}