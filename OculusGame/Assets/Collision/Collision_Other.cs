using UnityEngine;
using System.Collections;

public class Collision_Other : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //弾に当たったら
            case "bullet":

                //HPを減らすとか

                break;
                
            default:
                break;
        }

    }

}
