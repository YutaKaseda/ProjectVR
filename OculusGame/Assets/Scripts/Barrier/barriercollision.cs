using UnityEngine;
using System.Collections;

public class barriercollision : MonoBehaviour {

    public void BarrierDelete()
    {
        Destroy(gameObject);
    }

    //何かに当たったら消える
    void OnTriggerEnter(Collider other)
    {
        //条件はまだ決めてないし、処理も不明なので保留
        //バリアがくらった時の処理
        switch (other.tag)
        {
            case "Enemy":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
