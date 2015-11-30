using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	
    PlayerData2D playerData;
    Beacon playerBeacon;
    BeaconUI playerBeaconUI;

	// Use this for initialization
	void Awake () {
        playerData = GetComponent<PlayerData2D>();
        playerBeacon = GetComponent<Beacon>();
        playerBeaconUI = GetComponent<BeaconUI>();
        playerData.speed = 8.0f;
        playerData.bulletPrefab = Resources.Load("Prefab/Bullet2D") as GameObject;
	}
    public void Move()
    {
        if(playerBeacon.moveFlg == false){
            playerData.vectorZ = Input.GetAxisRaw("HorizontalP2");
            playerData.vectorY = Input.GetAxisRaw("VerticalP2");
        }
        if (playerBeacon.moveFlg == true)
        {
            playerData.vectorY = 0;
            playerData.vectorZ = 0;
        }
 
        playerData.movePlayer = new Vector3(0, playerData.vectorY * playerData.speed, playerData.vectorZ * playerData.speed);
        GetComponent<Rigidbody>().velocity = playerData.movePlayer;
        
        BulletShot();
        playerBeacon.BeaconPut();
        playerBeaconUI.BeaconPutUI();
        playerBeaconUI.BarrierOpen();
	}

    void BulletShot()
    {

		if (Input.GetButton("MaruP2")) {
            Instantiate(playerData.bulletPrefab, transform.position, transform.rotation);

		}
	}
}
