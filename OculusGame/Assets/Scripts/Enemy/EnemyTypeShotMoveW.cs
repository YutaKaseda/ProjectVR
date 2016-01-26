using UnityEngine;
using System.Collections;

public class EnemyTypeShotMoveW : MonoBehaviour {

    enum E_w_updown { UP, DOWN };   //Wに動くときの上に行ってるか下に行ってるか
    E_w_updown updown;              //その保存場所
    EnemyData enemyData;

    void Awake()
    {
        enemyData.createPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (enemyData.createPos.y <= 0)
        {
            enemyData.movePos = new Vector3(enemyData.createPos.x, enemyData.createPos.y + 10, enemyData.createPos.z - 15);
            updown = E_w_updown.UP;
        }
        else
        {
            enemyData.movePos = new Vector3(enemyData.createPos.x, enemyData.createPos.y - 10, enemyData.createPos.z - 15);
            updown = E_w_updown.DOWN;
        }
        enemyData.stopTime = 20;
        enemyData.enemyBulletRapid = 0.9f;
        //enemyData.player2DPosition = GameObject.FindWithTag("Player2D").transform;
        enemyData.player3DPosition = GameObject.FindWithTag("Player3D").transform;
        enemyData.InitHP(3);
        StartCoroutine("EnemyTypeShotMoveOne");
        StartCoroutine("EnemyTypeShotFire");
    }

    IEnumerator EnemyTypeShotMoveOne()       //一度目の動き
    {
        while (transform.position != enemyData.movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.movePos, 0.1f);
            yield return null;
        }
        if (updown == E_w_updown.UP)
        {
            enemyData.movePos = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z - 15);
            updown = E_w_updown.DOWN;
        }
        else
        {
            enemyData.movePos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z - 15);
            updown = E_w_updown.UP;
        }
        StartCoroutine("EnemyTypeShotMoveTwo");
    }

    IEnumerator EnemyTypeShotMoveTwo()       //二度目の動き
    {
        while (transform.position != enemyData.movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.movePos, 0.1f);
            yield return null;
        }
        if (updown == E_w_updown.UP)
        {
            enemyData.movePos = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z - 15);
            updown = E_w_updown.DOWN;
        }
        else
        {
            enemyData.movePos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z - 15);
            updown = E_w_updown.UP;
        }
        StartCoroutine("EnemyTypeShotMoveThree");
    }

    IEnumerator EnemyTypeShotMoveThree()       //三度目の動き
    {
        while (transform.position != enemyData.movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.movePos, 0.1f);
            yield return null;
        }
        if (updown == E_w_updown.UP)
        {
            enemyData.movePos = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z - 15);
            updown = E_w_updown.DOWN;
        }
        else
        {
            enemyData.movePos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z - 15);
            updown = E_w_updown.UP;
        }
        StartCoroutine("EnemyTypeShotMoveFour");
    }

    IEnumerator EnemyTypeShotMoveFour()       //四度目の動き
    {
        while (transform.position != enemyData.movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.movePos, 0.1f);
            yield return null;
        }
        Delete();//消去
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
