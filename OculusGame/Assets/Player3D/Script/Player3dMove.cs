using UnityEngine;
using System.Collections;

public class Player3dMove: MonoBehaviour {
	float speed;
	float vectorX, vectorY;	
	Vector3 playerMove;
	GameObject player3DBullet;
	
	void Awake(){
		player3DBullet = Resources.Load ("Prefab/bullet") as GameObject;
		speed = 3f;
	}

	public void Player3DMove(){
		float vectorX = Input.GetAxisRaw ("HorizontalP1");
		float vectorY = Input.GetAxisRaw ("VerticalP1");
		playerMove = new Vector3 (vectorX * speed, vectorY * speed, 0);
		GetComponent<Rigidbody> ().velocity = playerMove;
		ShotBullet ();
	}

	void ShotBullet(){
		if(Input.GetButton("MaruP1")){
			Instantiate(player3DBullet,transform.position,transform.rotation);
		}
	}
}
