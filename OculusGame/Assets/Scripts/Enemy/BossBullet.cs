using UnityEngine;
using System.Collections;

public class BossBullet : MonoBehaviour {
	Vector3 enemyDirection;
	float enemyBulletSpeed;//弾の速さ
	float randomX,randomY,randomZ;
	// Use this for initialization
	void Awake () {
		enemyBulletSpeed = 3200.0f;//弾の速さ
		Destroy(gameObject,2.5f);
	}

	public void RandomBullet(){
		randomX = Random.Range (-15,15);
		randomY = Random.Range (-15,15);
		randomZ = Random.Range (-15,15);
		transform.Rotate (randomX, randomY, randomZ);
		enemyDirection = transform.forward * enemyBulletSpeed;
		GetComponent<Rigidbody> ().AddForce(enemyDirection);
	}

	public void TargetBullet(Vector3 target){
		transform.LookAt (target);
		enemyDirection = transform.forward * enemyBulletSpeed;
		GetComponent<Rigidbody> ().AddForce(enemyDirection);
	}

}
