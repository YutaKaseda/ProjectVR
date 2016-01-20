using UnityEngine;
using System.Collections;

public class EnemyTypeDefense : MonoBehaviour {

    Vector3 createPos;//生成された位置を記録
    Vector3 movePos;//移動先の位置
    int stopTime;//射撃停止秒数
    float enemyBulletRapid;//敵のたまの連射間隔
    Transform player2DPosition;
    Transform player3DPosition;
    Vector3 targetPlayerVec;
    GameObject targetPlayerObject;


    void Awake()
    {
        createPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        movePos = new Vector3(createPos.x, createPos.y, createPos.z - 20);
        stopTime = 20;
        enemyBulletRapid = 0.9f;
        //player2DPosition = GameObject.FindWithTag("Player2D").transform;
        player3DPosition = GameObject.FindWithTag("Player3D").transform;
        StartCoroutine("EnemyTypeShotMove");
        StartCoroutine("EnemyTypeShotFire");
    }

    IEnumerator EnemyTypeShotMove()
    {
        while (transform.position != movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePos, 0.1f);
            yield return null;
        }
    }

    IEnumerator EnemyTypeShotFire()
    {
        while (stopTime > 0)
        {
            stopTime -= 1;
            targetPlayerVec = player3DPosition.transform.position; // 後でランダム処理にする
            targetPlayerObject = Instantiate(ResourcesManager.Instance.GetResourceScene("EnemyBullet"), transform.position, transform.rotation) as GameObject;
            targetPlayerObject.GetComponent<EnemyBullet>().EnemyShotMove(targetPlayerVec);
            //この一連の流れで、EnemyBullet側にPlayerの位置を与えてる
            yield return new WaitForSeconds(enemyBulletRapid);
        }
        StartCoroutine("EnemyTypeShotReturn");
    }

    IEnumerator EnemyTypeShotReturn()
    {
        while (transform.position != createPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, createPos, 0.1f);
            yield return null;
        }
        Delete();//消去
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
