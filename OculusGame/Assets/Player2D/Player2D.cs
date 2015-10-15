using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	
	private float speed = 8.0f;//自機の移動の速さ
	private float bulletSpeed = 5.0f;//弾の速さ
	public GameObject bulletPrefab;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		BulletShot ();
	}
	
	void Move(){
		GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed, 0);
	}

	void BulletShot(){

		if (Input.GetKey(KeyCode.Space)) {
			GameObject Shot = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

			Bullet b = Shot.AddComponent<Bullet>();

			b.ShotMove(bulletSpeed);//弾を管理するスクリプトの関数を実行
		}
	}
}
