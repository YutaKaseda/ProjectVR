﻿/// <summary>
/// Enemy factory.
/// 2/18 内藤　追記（enemyの種類増やし）
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	[SerializeField]
	GameObject enemy2D;
	[SerializeField]
	GameObject enemy3D;
	GameObject enemy;
	EnemyTypeNew enemyTypeNew;

	public void Create(string enemyName , Vector3 enemyPos ,float enemyDegree){
		switch (enemyName) {
		case "enemyL":
		case "enemyR":
			enemy = Instantiate (enemy2D, enemyPos, transform.rotation)as GameObject;
			enemyTypeNew = enemy.GetComponent<EnemyTypeNew>();
			enemyTypeNew.InitDegree(enemyPos,enemyDegree,enemyName);
			break;
		case "enemy3D":
			enemy = Instantiate (enemy3D, enemyPos, transform.rotation)as GameObject;
			break;
		}
	}
}
