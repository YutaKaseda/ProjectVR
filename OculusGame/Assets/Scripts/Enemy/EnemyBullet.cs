using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    Vector3 enemyDirection;
    float enemyBulletSpeed;//弾の速さ

    void Awake()
    {
        enemyBulletSpeed = 800.0f;//弾の速さ
    }

    // Update is called once per frame
    public void EnemyShotMove(Vector3 target)
    {
        transform.LookAt(target);
        enemyDirection = transform.forward * enemyBulletSpeed;
        GetComponent<Rigidbody>().AddForce(enemyDirection);

        Destroy(gameObject, 3f);
    }
}