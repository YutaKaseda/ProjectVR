using UnityEngine;
using System.Collections;

public class CollisionPlayer3D : MonoBehaviour {

    PlayerData3D playerData;

    void Awake()
    {
        playerData = GetComponent<PlayerData3D>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //敵の弾に当たったら
            case "EnemyBullet3D":
                //HPを減らすとか
                Debug.Log(playerData.playerHP);
                playerData.Damege(10);

                break;

            //敵に当たったら
            case "3DEnemy":
                playerData.Damege(5);
                break;

            case "Railgun":
                playerData.Damege(50);
                break;

            default:
                break;
        }
        if (playerData.playerHP <= 0)
        {
            Debug.Log("GAME OVER");
           // Application.Quit();
        }

    }

}
