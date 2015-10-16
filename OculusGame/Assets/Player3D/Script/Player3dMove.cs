using UnityEngine;
using System.Collections;

public class Player3dMove: MonoBehaviour {
	enum playerState{UP, DOWN, LEFT, RIGHT};
	Vector3 move;
	float speed;

	void Awake(){
		speed = 1f;
	}
	void Update(){
		PlayerStateMove ();
	}

	void PlayerStateMove(){
		//入力処理
		float Vertical = Input.GetAxis ("Vertical");
		float Side = Input.GetAxis ("Horizontal");

		//上下
		if (Vertical > 0.1) {
			PlayerMove(playerState.UP);
		}
		else if (Vertical < -0.1) {
			PlayerMove(playerState.DOWN);
		}
		//左右
		if (Side > 0.1){
			PlayerMove(playerState.RIGHT);
		}
		else if (Side < -0.1){
			PlayerMove(playerState.LEFT);
		}
	}

	void PlayerMove(playerState Move){
		switch (Move){

		case playerState.UP:
			move = transform.TransformDirection(0, 0.1f, 0);
			move *= speed;
			move.z *= 0;
			transform.localPosition += move;
			break;
			
		case playerState.DOWN:
			move = transform.TransformDirection(0, -0.1f, 0);
			move *= speed;
			move.z *= 0;
			transform.localPosition += move;
			break;
			
		case playerState.RIGHT:
			move = transform.TransformDirection(0.1f, 0, 0);
			move *= speed;
			move.z *= 0;
			transform.localPosition += move;
			break;
			
		case playerState.LEFT:
			move = transform.TransformDirection(-0.1f, 0, 0);
			move *= speed;
			move.z *= 0;
			transform.localPosition += move;
			break;
		}
	}
}