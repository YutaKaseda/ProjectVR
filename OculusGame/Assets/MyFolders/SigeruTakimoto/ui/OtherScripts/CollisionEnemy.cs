//2016/02/17 ui関連の紐づけ 梅村

using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {

    EnemyDataNew enemyDataNew;
    int dimension;

	[SerializeField]
	AllUI allUI;
    void Awake()
    {
		enemyDataNew = GetComponent<EnemyDataNew>();
		allUI = GameObject.Find("UICanvas").GetComponent<AllUI>();

        if (this.tag == "3DEnemy")
            dimension = 3;
        if (this.tag == "2DEnemy")
            dimension = 2;
    }
	
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //プレイヤーの弾に当たったら
            case "Player2DBullet":
                if (dimension == 2)
                {
					enemyDataNew.Damege(1);
					if (enemyDataNew.enemyHP <= 0)
                    {
					allUI.UiUpdate("ComboUp",0);
					allUI.UiUpdate("ScoreUp",1000);
					allUI.UiUpdate("DeathBlowGageUp",0);
                        Destroy(gameObject);
                    }
                }
                break;
            //プレイヤーの弾に当たったら
            case "Player3DBullet":
                if (dimension == 3)
                {
					enemyDataNew.Damege(1);
					if (enemyDataNew.enemyHP <= 0)
                    {
					allUI.UiUpdate("ComboUp",0);
					allUI.UiUpdate("ScoreUp",1000);
					allUI.UiUpdate("DeathBlowGageUp",0);
						Destroy(gameObject);
                    }
                }
                break;
            default:
                break;
        }

    }

}