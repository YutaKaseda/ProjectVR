using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	
	float speed;//自機の移動の速さ
	Vector3 movePlayer;
	GameObject bulletPrefab;
	float vectorX,vectorY;

	// Use this for initialization
	void Awake () {

		speed = 8.0f;

		bulletPrefab = Resources.Load ("Prefab/Bullet") as GameObject;
		//bulletPrefab.AddComponent<Bullet> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		BulletShot ();
	}
	
	void Move(){
		vectorX = Input.GetAxisRaw ("Horizontal");
		vectorY = Input.GetAxisRaw ("Vertical");
		movePlayer = new Vector3(vectorX * speed, vectorY * speed, 0);
		GetComponent<Rigidbody> ().velocity = movePlayer;
	}

	void BulletShot(){

		if (Input.GetKey(KeyCode.Space)) {
			Instantiate(bulletPrefab, transform.position, transform.rotation);

		}
	}
}
