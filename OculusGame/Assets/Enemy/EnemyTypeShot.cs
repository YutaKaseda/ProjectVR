using UnityEngine;
using System.Collections;

public class EnemyTypeShot : MonoBehaviour {
	GameObject enemyBulletPrefab;//敵のたま
	Vector3 createPos;//生成された位置を記録
	Vector3 movePos;//移動先の位置
	float stopTime;//射撃停止秒数
	int enemyBulletRapid;//敵のたまの連射速度

	void Awake () {
		enemyBulletPrefab = Resources.Load ("Prefab/EnemyBullet") as GameObject;
		createPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		movePos = new Vector3 (Random.Range (-5, 6), Random.Range (1, 10), Random.Range (8, 15));
		stopTime = 5.0f;
		enemyBulletRapid = 0;
		StartCoroutine("EnemyTypeShotMove");
	}

	IEnumerator EnemyTypeShotMove(){
		while(transform.position != movePos){
			transform.position = Vector3.MoveTowards (transform.position, movePos, 0.2f);
			yield return null;
		}
		StartCoroutine("EnemyTypeShotReturn");
	}

	IEnumerator EnemyTypeShotReturn(){
		while(transform.position != createPos){
			stopTime -= Time.deltaTime;
			enemyBulletRapid += 1;

			if(enemyBulletRapid >= 50 && stopTime >= 0.0f){
				Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
				enemyBulletRapid = 0;
			}

			if(stopTime <= 0.0f){
				transform.position = Vector3.MoveTowards (transform.position, createPos, 0.2f);
			}
			yield return null;
		}
		Delete ();//消去
	}

	void Delete(){
		Destroy(gameObject);
	}
}
