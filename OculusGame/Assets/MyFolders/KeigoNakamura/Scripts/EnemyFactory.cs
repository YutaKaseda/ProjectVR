using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	public GameObject testteki;
	GameObject enemy;
	EnemyTypeNew enemyTypeNew;

	public void Create(string ss , Vector3 enemyPos ,float enemyDegree){
		switch (ss) {
		case "enemy":
			enemy = Instantiate (testteki, enemyPos, transform.rotation)as GameObject;
			enemyTypeNew = enemy.GetComponent<EnemyTypeNew>();
			enemyTypeNew.InitDegree(enemyDegree);
			break;
        
		}
	}
}
