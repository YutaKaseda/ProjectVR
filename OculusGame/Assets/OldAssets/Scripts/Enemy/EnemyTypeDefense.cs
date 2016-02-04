using UnityEngine;
using System.Collections;

public class EnemyTypeDefense : MonoBehaviour {

    EnemyData enemyData;

    void Awake()
    {
        enemyData = GetComponent<EnemyData>();
        enemyData.createPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        enemyData.movePos = new Vector3(enemyData.createPos.x, enemyData.createPos.y, enemyData.createPos.z - 20);
        enemyData.stopTime = 20;
        enemyData.enemyBulletRapid = 0.9f;
        //enemyData.player2DPosition = GameObject.FindWithTag("Player2D").transform;
        enemyData.player3DPosition = GameObject.FindWithTag("Player3D").transform;
        enemyData.InitHP(6);
        StartCoroutine("EnemyTypeShotMove");
        StartCoroutine("EnemyTypeShotFire");
    }

    IEnumerator EnemyTypeShotMove()
    {
        while (transform.position != enemyData.movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.movePos, 0.05f);
            yield return null;
        }
    }

    IEnumerator EnemyTypeShotFire()
    {
        while (enemyData.stopTime > 0)
        {
            enemyData.stopTime -= 1;
            enemyData.targetPlayerVec = enemyData.player3DPosition.transform.position; // 後でランダム処理にする
            enemyData.targetPlayerObject = Instantiate(ResourcesManager.Instance.GetResourceScene("3DEnemyBullet"), transform.position, transform.rotation) as GameObject;
            enemyData.targetPlayerObject.GetComponent<EnemyBullet3D>().EnemyShotMove(enemyData.targetPlayerVec);
            //この一連の流れで、EnemyBullet側にPlayerの位置を与えてる
            yield return new WaitForSeconds(enemyData.enemyBulletRapid);
        }
        StartCoroutine("EnemyTypeShotReturn");
    }

    IEnumerator EnemyTypeShotReturn()
    {
        while (transform.position != enemyData.createPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.createPos, 0.05f);
            yield return null;
        }
        Delete();//消去
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
