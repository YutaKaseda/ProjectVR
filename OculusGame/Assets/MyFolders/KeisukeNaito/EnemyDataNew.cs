/// <summary>
/// Enemy data new.
/// 用途　Enemyの変数等の管理
/// 使用方法　EnemyのPrefabに入れて行動をさせるクラスから参照する（基本してある）
/// 2/16 内藤　作成
/// 2/18 内藤　追記（追尾等）
/// 2/19 内藤　追記（Enemy3D用変数）
/// 3/3 梅村　score関連の修正
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyDataNew : MonoBehaviour {
	
	public Vector3 movePos{ get; set; }   				//移動先の位置
    public int enemyHP { get; private set; }            //EnemyのHP
	public float enemyDegree{ get; set; } 				//移動時に使う角度
	public float enemyRadius{ get; set; } 				//移動時に使う半径
	public float enemyDeleteTime{ get; set;}			//敵を消す時間
	public float enemyLifeTime{ get; set;}				//敵が生存している時間

	public float playerEnemyDistance{ get; set;}		//2点間の距離保存用
	public float stalkingX{ get; set;}					
	public float stalkingY{ get; set;}					//追尾用座標調整保存変数
	public float stalkingZ{ get; set;}
	public bool stalkingSearch{ get; set; }				//追尾用範囲内にいるかどうか
	public int enemyQuater{ get; set; }					//Enemy回転用

	public float enemySpeed{ get; set;}
	public float player2DDegree{ get; set; }			//Speed格納仮変数

	public float pi{ get; private set;}

	public Vector3 player3DBase{ get; set; }			//3DPlayerのいる位置を出た瞬間のみ保存
	public Vector3 enemy3DDirection{ get; set; }		//Enemy3D向かわせる方向

	[SerializeField]
	AllUI allUI;

	void Awake(){
		pi = 3.14f;
		allUI = GameObject.Find("UIObj").GetComponent<AllUI>();
	}

    //体力初期化
    public void InitHP(int hp)
    {
        enemyHP = hp;
    }

	public void EnemyDamage(string bullet){
		switch (bullet) {
		case "NormalBullet":
            SoundPlayer.Instance.PlaySoundEffect("Bomb", 1.0f);
            EffectFactory.Instance.Create("bom", transform.position, transform.rotation);
			allUI.UiUpdate("ComboUp",0);
			allUI.UiUpdate("ScoreUp",100);
			allUI.UiUpdate("DeathBlowGaugeUp",0);
            Destroy(gameObject);
			break;
		default:
			Debug.LogError ("bullet指定ミス");
			break;
		}
	}
}
