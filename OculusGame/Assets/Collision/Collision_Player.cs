using UnityEngine;
using System.Collections;

public class Collision_Player : PlayerData {

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //敵の弾に当たったら
            case "enemybullet":
                //HPを減らすとか
                Damege(1);
                break;

            //敵に当たったら
            case "enemy":
                Damege(3);
                break;
                
            default:
                break;
        }

    }

}
