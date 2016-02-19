//2016/02/17 ui関連の紐づけ 梅村
// 2016/02/19 梅村 DeathBlowGaugeUpの名前変更
using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {

	[SerializeField]
	AllUI allUI;

	EnemyDataNew enemyDataNew;

    void Awake()
    {
		allUI = GameObject.Find("UIObj").GetComponent<AllUI>();
		enemyDataNew = GetComponent<EnemyDataNew>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //プレイヤーの弾に当たったら
            case "Player2DBullet":
				allUI.UiUpdate("ComboUp",0);
				allUI.UiUpdate("ScoreUp",1000);
				allUI.UiUpdate("DeathBlowGageUp",0);
				enemyDataNew.EnemyDamage("NormalBullet");

	            break;
            //プレイヤーの弾に当たったら
            /*case "Player3DBullet":
				allUI.UiUpdate("ComboUp",0);
				allUI.UiUpdate("ScoreUp",1000);
				allUI.UiUpdate("DeathBlowGageUp",0);
				Destroy(gameObject);
            	break;*/
            default:
                break;
        }

    }
}	