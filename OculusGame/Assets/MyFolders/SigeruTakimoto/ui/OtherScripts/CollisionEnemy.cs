//2016/02/17 ui関連の紐づけ 梅村
// 2016/02/19 梅村 DeathBlowGaugeUpの名前変更
// 2016/03/3 梅村 score関連の処理をダメージ関数側にうつした
using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {
	EnemyDataNew enemyDataNew;

    public bool awakeCollision { private set; get; }

    void Awake()
    {
		enemyDataNew = GetComponent<EnemyDataNew>();
        StartCoroutine(EnablePlayerCollision());
    }

    IEnumerator EnablePlayerCollision()
    {
        awakeCollision = false;
        yield return new WaitForSeconds(1.0f);
        awakeCollision = true;

    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //プレイヤーの弾に当たったら
            case "Player2DBullet":
				enemyDataNew.EnemyDamage("NormalBullet");
	            break;
			case"Player2D":
			case"Player3D":
				Destroy(gameObject);
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