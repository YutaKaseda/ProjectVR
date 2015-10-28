using UnityEngine;
using System.Collections;

public class EnemyCreate : MonoBehaviour {
	GameObject enemyTypeAttackPrefab;//突撃型
	GameObject enemyTypeShotPrefab;//射撃型
	Vector3 enemyTypeShotPos;//射撃型の生成位置

	void Awake () {
		enemyTypeAttackPrefab = Resources.Load ("Prefab/EnemyTypeAttack") as GameObject;
		enemyTypeShotPrefab = Resources.Load ("Prefab/EnemyTypeShot") as GameObject;

	}
	
	void Update () {
		Anim ();
	}

	void Anim(){

		if (Input.GetKeyDown(KeyCode.Z)) {
			Instantiate(enemyTypeAttackPrefab, transform.position, transform.rotation);
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			enemyTypeShotPos = new Vector3 (Random.Range (-5, 6), Random.Range (0, 10), 20);
			Instantiate(enemyTypeShotPrefab, enemyTypeShotPos, transform.rotation);
		}
	}
}
