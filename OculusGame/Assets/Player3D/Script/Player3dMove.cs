using UnityEngine;
using System.Collections;

public class Player3dMove: MonoBehaviour {

    PlayerData3D playerData;

	void Awake(){
        playerData = GetComponent<PlayerData3D>();
        playerData.speed = 3f;
	}

	void Update(){
		Player3DMove ();
	}
	
	public void Player3DMove(){
        playerData.vectorX = Input.GetAxisRaw("Horizontal");
        playerData.vectorY = Input.GetAxisRaw("Vertical");
        playerData.movePlayer = new Vector3(playerData.vectorX * playerData.speed, playerData.vectorY * playerData.speed, 0);
        GetComponent<Rigidbody>().velocity = playerData.movePlayer;
	}
}
