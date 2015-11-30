using UnityEngine;
using System.Collections;

public class BeaconHP : MonoBehaviour {
	enum beaconState{ENEMYCHARACTER, ENEMYBULLET}; //ダメージを受ける条件：敵キャラ、弾に当たる、自爆
	int beaconLife;
	GameObject explosion; //爆発時のエフェクト

	void Awake () {	
		beaconLife = 6;	//ビーコンのHP
		//explosion = Resources.Load ("Prefab/Explosion") as GameObject; 
		//↓に変更
        ResourcesManager.Instance.ResourcesLoadScene ("Play");
	}

	void Update(){
		BeaconDestruct ();
	}

	//自爆
	void BeaconDestruct(){
		if (Input.GetKeyDown(KeyCode.O)) {
			Destroy(gameObject);
			Debug.Log("DESTRUCT");
            Instantiate(ResourcesManager.Instance.GetResourceScene("Bom"), transform.position, transform.rotation);
		}
	}

	//ビーコンのHP減少
	void OnTriggerEnter(Collider Enemy){
		if (Enemy.gameObject.tag == "EnemyBullet") {
			BeaconDamage (beaconState.ENEMYBULLET);
		} else if (Enemy.gameObject.tag == "EnemyCharacter") {
			BeaconDamage (beaconState.ENEMYCHARACTER);
		}
	//ビーコンの耐久値が０以下になった時、爆発エフェクト
		if (beaconLife <= 0 ) {
			Destroy (gameObject);
			//爆発エフェクト呼び出し
            Instantiate(ResourcesManager.Instance.GetResourceScene("Bom"), transform.position, transform.rotation);

		}
	}
	//HP減少条件
	void BeaconDamage(beaconState life){
		switch (life) {
	//敵キャラが当たった時
		case beaconState.ENEMYCHARACTER:
			beaconLife -= 2;
			Debug.Log("EnemyHit");
			Debug.Log(beaconLife);
			break;
	//敵の弾が当たった時
		case beaconState.ENEMYBULLET:
			beaconLife --;
			Debug.Log("BulletHit");
			Debug.Log(beaconLife);
			break;
		default:
			break;
		}
	}
}