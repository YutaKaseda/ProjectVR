using UnityEngine;
using System.Collections;

public class barriercollision : MonoBehaviour {

    int barrierHP;

    void Awake()
    {
        barrierHP = 2;
    }

    public void BarrierDelete()
    {
        if (barrierHP <= 0)
        {
            Instantiate(ResourcesManager.Instance.GetResourceScene("Barrierbreak"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    //何かに当たったら消える
    void OnTriggerEnter(Collider other)
    {
        //条件はまだ決めてないし、処理も不明なので保留
        //バリアがくらった時の処理
        switch (other.tag)
        {
            case "Enemy":
                barrierHP -= 2;
                BarrierDelete();
                break;
            case "EnemyBullet":
                barrierHP -= 1;
                BarrierDelete();
                break;
            case "EnemyLaser":
                barrierHP -= 2;
                BarrierDelete();
                break;
            default:
                break;
        }
    }
}
