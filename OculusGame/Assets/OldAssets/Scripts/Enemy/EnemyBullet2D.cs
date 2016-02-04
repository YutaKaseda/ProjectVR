using UnityEngine;
using System.Collections;

public class EnemyBullet2D : MonoBehaviour {

    Vector3 enemyDirection;
    float enemyBulletSpeed;//弾の速さ

    void Awake()
    {
        enemyBulletSpeed = 1000.0f;//弾の速さ
    }

    // Update is called once per frame
    public void EnemyShotMove(Vector3 target)
    {
        enemyDirection = transform.forward * enemyBulletSpeed * -1;
        GetComponent<Rigidbody>().AddForce(enemyDirection);

        Destroy(gameObject, 3f);
    }
}
