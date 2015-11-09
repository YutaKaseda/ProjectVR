using UnityEngine;
using System.Collections;

public class Player3dMove: MonoBehaviour {

    PlayerData3D playerData;

	void Awake(){
        playerData = GetComponent<PlayerData3D>();
        playerData.speed = 3f;
        playerData.bulletPrefab = Resources.Load("Prefab/Bullet3D") as GameObject;
        playerData.oculusCamera = GameObject.Find("OculusCamera");
	}
	
	public void Player3DMove(){
        playerData.vectorX = Input.GetAxisRaw("HorizontalP1");
        playerData.vectorY = Input.GetAxisRaw("VerticalP1");
        playerData.movePlayer = new Vector3(playerData.vectorX * playerData.speed, playerData.vectorY * playerData.speed, 0);
        GetComponent<Rigidbody>().velocity = playerData.movePlayer;

        BulletShot();
	}

    void BulletShot()
    {

        if (Input.GetButton("MaruP1"))
        {
            playerData.bulletPosition = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z);
            Instantiate(playerData.bulletPrefab, playerData.bulletPosition, playerData.oculusCamera.transform.rotation);
        }
    }
}
