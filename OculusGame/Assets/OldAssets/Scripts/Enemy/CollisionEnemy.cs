using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {

    EnemyData enemyData;
    ScoreManager scoreManager;
    int dimension;

    void Awake()
    {
        enemyData = GetComponent<EnemyData>();
        //scoreManager = GameObject.Find("DataManager").GetComponent<ScoreManager>();
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
                    enemyData.Damege(1);
                    if (enemyData.enemyHP <= 0)
                    {
                        //scoreManager.plusScore(1000);
                        Destroy(gameObject);
                    }
                }
                break;
            //プレイヤーの弾に当たったら
            case "Player3DBullet":
                if (dimension == 3)
                {
                    enemyData.Damege(1);
                    if (enemyData.enemyHP <= 0)
                    {
                        //scoreManager.plusScore(1000);
                        Destroy(gameObject);
                    }
                }
                break;
            default:
                break;
        }

    }

}