using UnityEngine;
using System.Collections;

public class CollisionPlayer2D : MonoBehaviour {

    PlayerData2D playerData;

    void Awake()
    {
        playerData = GetComponent<PlayerData2D>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //敵の弾に当たったら
            case "EnemyBullet2D":
                //HPを減らすとか
                playerData.Damege(10);
                break;

            //敵に当たったら
            case "2DEnemy":
                playerData.Damege(5);
                break;

            case "Railgun":
                playerData.Damege(30);
                break;

            default:
                break;
        }

    }
}
