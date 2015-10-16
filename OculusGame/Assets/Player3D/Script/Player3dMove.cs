using UnityEngine;
using System.Collections;

public class Player3dMove: MonoBehaviour {
	float speed;
	float vectorX, vectorY;	
	Vector3 playerMove;
	
	void Awake(){
		speed = 3f;
	}

	void Update(){
		Player3DMove ();
	}
	
	void Player3DMove(){
		float vectorX = Input.GetAxisRaw ("Horizontal");
		float vectorY = Input.GetAxisRaw ("Vertical");
		playerMove = new Vector3 (vectorX * speed, vectorY * speed, 0);
		GetComponent<Rigidbody> ().velocity = playerMove;
	}
}
