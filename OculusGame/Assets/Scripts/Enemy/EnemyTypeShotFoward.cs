using UnityEngine;
using System.Collections;

public class EnemyTypeShotFoward : MonoBehaviour {

    EnemyData enemyData;

    void Awake()
    {
        enemyData = GetComponent<EnemyData>();
        enemyData.createPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        enemyData.movePos = new Vector3(enemyData.createPos.x, enemyData.createPos.y, enemyData.createPos.z - 60);
        enemyData.stopTime = 20;
        enemyData.enemyBulletRapid = 0.9f;
        //enemyData.player2DPosition = GameObject.FindWithTag("Player2D").transform;
        enemyData.player3DPosition = GameObject.FindWithTag("Player3D").transform;
        enemyData.InitHP(3);
        StartCoroutine("EnemyTypeShotReturn");
        StartCoroutine("EnemyTypeShotFire");
    }

    IEnumerator EnemyTypeShotFire()     //弾を撃つ
    {
        while (enemyData.stopTime > 0)
        {
            enemyData.stopTime -= 1;
            enemyData.targetPlayerVec = enemyData.player3DPosition.transform.position; // 後でランダム処理にする
            //2Dの敵なら2D用の弾を
            enemyData.targetPlayerObject = Instantiate(ResourcesManager.Instance.GetResourceScene("2DEnemyBullet"), transform.position, transform.rotation) as GameObject;
            enemyData.targetPlayerObject.GetComponent<EnemyBullet2D>().EnemyShotMove(enemyData.targetPlayerVec);   //2は次元、そう2D

            //この一連の流れで、EnemyBullet側にPlayerの位置を与えてる
            yield return new WaitForSeconds(enemyData.enemyBulletRapid);
        }
    }

    IEnumerator EnemyTypeShotReturn()       //帰ります
    {
        while (transform.position != enemyData.movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.movePos, 0.1f);
            yield return null;
        }
        Delete();//消去
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
