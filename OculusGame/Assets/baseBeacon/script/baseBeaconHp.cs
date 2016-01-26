using UnityEngine;
using System.Collections;
using UnityEditor;


//ベースビーコンのHPの処理
public class baseBeaconHp : MonoBehaviour {
	enum beaconState{ENEMYCHARACTER, ENEMYBULLET}; //ダメージを受ける条件：敵キャラ、弾に当たる、自爆
	public int baseBeaconLife;

	public GameObject prefab;

	
		void Awake(){
		//タグ設定
		this.tag = ("DefaultBeacon");
		baseBeaconLife = 50;
		//3D出現用
		Instantiate(prefab,transform.position,transform.rotation);
	}





	//当たった場合の判定　
public void OnTriggerEnter(Collider Enemy){
		if (Enemy.gameObject.tag == "EnemyBullet") {
			baseBeaconDamage (beaconState.ENEMYBULLET);
		} else if (Enemy.gameObject.tag == "EnemyCharacter") {
			baseBeaconDamage (beaconState.ENEMYCHARACTER);
		}
		//ビーコンの耐久値が０以下になった時
		if (baseBeaconLife <= 0) {
			Destroy (gameObject);
			Debug.Log("ゲームオーバー");
		}
	}
     void baseBeaconDamage(beaconState life){
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
	//waveでの回復
	public	void BeaconRecovery(int wave){
		//5回に一回
		if(wave % 5== 0){
			baseBeaconLife +=20;
		}
	}
}

