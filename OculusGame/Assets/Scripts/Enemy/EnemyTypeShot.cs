﻿using UnityEngine;
using System.Collections;

public class EnemyTypeShot : MonoBehaviour
{

    EnemyData enemyData;

    void Awake()
    {
        enemyData = GetComponent<EnemyData>();
        enemyData.createPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (this.tag == "3DEnemy")
            enemyData.movePos = new Vector3(enemyData.createPos.x, enemyData.createPos.y, enemyData.createPos.z - 10);
        if (this.tag == "2DEnemy")
            enemyData.movePos = new Vector3(enemyData.createPos.x, enemyData.createPos.y, enemyData.createPos.z - 20);
        enemyData.stopTime = 9;
        enemyData.enemyBulletRapid = 0.9f;
        //enemyData.player2DPosition = GameObject.FindWithTag("Player2D").transform;
        enemyData.player3DPosition = GameObject.FindWithTag("Player3D").transform;
        enemyData.InitHP(3);
        StartCoroutine("EnemyTypeShotMove");
        StartCoroutine("EnemyTypeShotFire");
    }

    IEnumerator EnemyTypeShotMove()
    {
        while (transform.position != enemyData.movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.movePos, 0.1f);
            yield return null;
        }
    }

    IEnumerator EnemyTypeShotFire()
    {
        while (enemyData.stopTime > 0)
        {
            enemyData.stopTime -= 1;
            enemyData.targetPlayerVec = enemyData.player3DPosition.transform.position; // 後でランダム処理にする
            if (this.tag == "3DEnemy")
            {
                //3Dの敵なら3D用の弾を
                enemyData.targetPlayerObject = Instantiate(ResourcesManager.Instance.GetResourceScene("3DEnemyBullet"), transform.position, transform.rotation) as GameObject;
                enemyData.targetPlayerObject.GetComponent<EnemyBullet3D>().EnemyShotMove(enemyData.targetPlayerVec);   //3は次元、そう3D
            }
            if (this.tag == "2DEnemy")
            {
                //2Dの敵なら2D用の弾を
                enemyData.targetPlayerObject = Instantiate(ResourcesManager.Instance.GetResourceScene("2DEnemyBullet"), transform.position, transform.rotation) as GameObject;
                enemyData.targetPlayerObject.GetComponent<EnemyBullet2D>().EnemyShotMove(enemyData.targetPlayerVec);   //2は次元、そう2D
                
            }
            //この一連の流れで、EnemyBullet側にPlayerの位置を与えてる
            yield return new WaitForSeconds(enemyData.enemyBulletRapid);
        }
        StartCoroutine("EnemyTypeShotReturn");
    }

    IEnumerator EnemyTypeShotReturn()
    {
        while (transform.position != enemyData.createPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyData.createPos, 0.1f);
            yield return null;
        }
        Delete();//消去
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}