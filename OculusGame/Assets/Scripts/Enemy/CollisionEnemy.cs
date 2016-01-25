using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {

    EnemyData enemyData;
    ScoreManager scoreManager;

    void Awake()
    {
        enemyData = GetComponent<EnemyData>();
        scoreManager = GameObject.Find("DataManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //プレイヤーの弾に当たったら
            case "Player2DBullet":
                enemyData.Damege(1);
                if (enemyData.enemyHP <= 0)
                {
                    scoreManager.plusScore(1000);
                    Destroy(gameObject);
                }
                break;
            //プレイヤーの弾に当たったら
            case "Player3DBullet":
                enemyData.Damege(1);
                if (enemyData.enemyHP <= 0)
                {
                    scoreManager.plusScore(1000);
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }

    }

}