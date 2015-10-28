using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	
	Transform player2DPosition;
	Vector3 enemyDirection;
	//Vector3 playerPos3D;
	Vector3 targetPlayer;

	float enemyBulletSpeed;//弾の速さ


	void Awake () {
		player2DPosition = GameObject.FindWithTag("Player").transform;
		enemyBulletSpeed = 800.0f;//弾の速さ

		EnemyShotMove ();
	}
	
	// Update is called once per frame
	void EnemyShotMove () {
		targetPlayer = player2DPosition.transform.position;
		transform.LookAt (targetPlayer);

		enemyDirection = transform.forward * enemyBulletSpeed;
		GetComponent<Rigidbody> ().AddForce(enemyDirection);

		Destroy(gameObject,1.5f);
	}
}
