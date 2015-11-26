using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour {

    PlayerData playerData;

    void Awake()
    {
        playerData = GetComponent<PlayerData>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //敵の弾に当たったら
            case "EnemyBullet":
                //HPを減らすとか
                playerData.Damege(10);
                break;

            //敵に当たったら
            case "enemy":
                playerData.Damege(3);
                break;
                
            default:
                break;
        }

    }

}
