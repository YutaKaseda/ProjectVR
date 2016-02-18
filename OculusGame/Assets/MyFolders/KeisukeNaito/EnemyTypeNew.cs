﻿/// <summary>
/// 
/// Enemy type new
/// 用途　Enemyの行動
/// 使用方法　EnemyのPrefabにEnemyDataと共に入れる
/// 内容　敵が生成位置から前進
/// プレイヤーを発見し次第追尾を追加予定
/// 2016 2/16 内藤 作成
/// 2/18 内藤　追記（追尾等）
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyTypeNew : MonoBehaviour {

	EnemyDataNew enemyDataNew;
	GameObject player2D;
	PlayerData2D playerData2D;

	void Awake()
	{
		enemyDataNew = GetComponent<EnemyDataNew>();
		enemyDataNew.enemyRadius = 125f;
		enemyDataNew.enemyDeleteTime = 15f;
		enemyDataNew.enemyLifeTime = 0;
		enemyDataNew.stokingSearch = false;
		player2D = GameObject.Find ("Player2D");
		playerData2D = player2D.GetComponent<PlayerData2D>();
	}

	//EnemyFactoryからの生成時の初期化関数
	public void InitDegree(Vector3 enemyPos,float degree,string enemyName){
		enemyDataNew.enemyDegree = degree;
		enemyDataNew.movePos = enemyPos;
		if (enemyName == "enemyL")
			enemyDataNew.enemySpeed = 0.3f;
		if (enemyName == "enemyR")
			enemyDataNew.enemySpeed = -0.3f;
		StartCoroutine("EnemyTypeNewMove");
	}

	//メインループのようなもの、移動する
	IEnumerator EnemyTypeNewMove()
	{
		while (enemyDataNew.enemyDeleteTime >= enemyDataNew.enemyLifeTime)
		{
			enemyDataNew.enemyLifeTime += Time.deltaTime;
			StokingAI();
			enemyDataNew.enemyDegree += enemyDataNew.enemySpeed;
			
			enemyDataNew.movePos = new Vector3 (enemyDataNew.enemyRadius * Mathf.Cos (enemyDataNew.pi / 180 * enemyDataNew.enemyDegree),
			                                    enemyDataNew.movePos.y + enemyDataNew.stokingY,
			                                    enemyDataNew.enemyRadius * Mathf.Sin (enemyDataNew.pi / 180 * enemyDataNew.enemyDegree));

			transform.position=enemyDataNew.movePos;
			transform.eulerAngles = new Vector3 (0, -enemyDataNew.enemyDegree, 0);
			yield return null;
		}
		enemyDataNew.movePos = new Vector3 (transform.position.x, transform.position.y+100, transform.position.z);
		StartCoroutine("EnemyTypeNewReturn");
	}

	IEnumerator EnemyTypeNewReturn()
	{
		while (transform.position != enemyDataNew.movePos)
		{
			transform.position = Vector3.MoveTowards(transform.position, enemyDataNew.movePos, 2f);
			yield return null;
		}
		Delete();//消去
	}

	//AIとして追尾の場所を関数
	void StokingAI(){
		enemyDataNew.playerEnemyDistance = Vector3.Distance (transform.position, player2D.transform.position);
		if (enemyDataNew.playerEnemyDistance <= 30) { 

			enemyDataNew.stokingSearch = true;
			if (transform.position.y <= player2D.transform.position.y)
				enemyDataNew.stokingY = 0.2f;
			else
				enemyDataNew.stokingY = -0.2f;

		} else if (enemyDataNew.stokingSearch == true) {
			enemyDataNew.stokingSearch = false;
			enemyDataNew.stokingY = 0;

			if(enemyDataNew.enemyDegree > playerData2D.degree){
				enemyDataNew.enemySpeed = -0.3f;
			}
			else if(enemyDataNew.enemyDegree < playerData2D.degree){
				enemyDataNew.enemySpeed = 0.3f;
			}
		}
	}
	
	void Delete()
	{
		Destroy(gameObject);
	}
}