/// <summary>
/// Enemy factory.
/// 2/18 内藤　追記（enemyの種類増やし）
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	public GameObject testteki;
	GameObject enemy;
	EnemyTypeNew enemyTypeNew;

	public void Create(string enemyName , Vector3 enemyPos ,float enemyDegree){
		switch (enemyName) {
		case "enemyL":
		case "enemyR":
		case "enemy":
			enemy = Instantiate (testteki, enemyPos, transform.rotation)as GameObject;
			enemyTypeNew = enemy.GetComponent<EnemyTypeNew>();
			enemyTypeNew.InitDegree(enemyPos,enemyDegree,enemyName);
			break;
        
		}
	}
}
