/// <summary>
/// 
/// Enemy type 3D
/// 用途　Enemyの行動3D追尾
/// 使用方法　EnemyのPrefabにEnemyDataと共に入れる
/// 内容　敵が生成位置から3D追尾
/// プレイヤーを発見し次第追尾を追加予定
/// 2016 2/19 内藤 作成
/// 2016/02/20 鈴木
/// HPの初期化追加
/// Delete処理追加
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyType3D : MonoBehaviour {
	
	EnemyDataNew enemyDataNew;
	GameObject player3D;
	GameObject enemy3DMain;
	
	void Awake()
	{
		enemyDataNew = GetComponent<EnemyDataNew>();
		enemyDataNew.InitHP (1);
		enemy3DMain = transform.FindChild ("Enemy3DMain").gameObject;
		enemy3DMain.transform.Rotate (0, 180, 0);
		enemyDataNew.enemyRadius = 125f;
		enemyDataNew.enemyDeleteTime = 30f;
		enemyDataNew.enemyLifeTime = 0;
		enemyDataNew.stalkingSearch = false;
		player3D = GameObject.FindWithTag ("Player3D");
		enemyDataNew.player3DBase = player3D.transform.position;
		StartCoroutine("EnemyTypeNewMove");
	}

	//メインループのようなもの、移動する
	IEnumerator EnemyTypeNewMove()
	{
		while (enemyDataNew.enemyDeleteTime >= enemyDataNew.enemyLifeTime)
		{
			enemyDataNew.enemyLifeTime += Time.deltaTime;
			if(enemyDataNew.enemyHP <= 0){
				Delete();
			}
			enemyDataNew.enemy3DDirection = enemyDataNew.player3DBase - transform.position; //方向
			enemyDataNew.enemy3DDirection = enemyDataNew.enemy3DDirection.normalized;   //単位化（距離要素を取り除く）
			transform.position = transform.position + (enemyDataNew.enemy3DDirection * 50f * Time.deltaTime);
			transform.LookAt(enemyDataNew.player3DBase);   //プレイヤーの方を向く
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

	void Delete()
	{
		Destroy (gameObject);
	}
}
