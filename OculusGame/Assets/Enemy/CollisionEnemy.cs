using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {
    GameObject scoreManager;
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //プレイヤーの弾に当たったら
            case "Player2DBullet":
                scoreManager = GameObject.Find("DataManager");
                scoreManager.GetComponent<ScoreManager>().plusScore(1000);
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }

}