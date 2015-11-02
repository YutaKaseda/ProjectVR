using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Vector3 direction;
	float bulletSpeed;//弾の速さ

	void Awake () {
		bulletSpeed = 800.0f;//弾の速さ
		ShotMove ();
	}

    public void ShotMove()
    {
		direction = transform.right * bulletSpeed;
		GetComponent<Rigidbody> ().AddForce(direction);
	}
}
