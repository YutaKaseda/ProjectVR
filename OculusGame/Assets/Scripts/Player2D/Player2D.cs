using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	
    PlayerData2D playerData;
	GameObject player3D;
	Renderer ren;
    Beacon playerBeacon;
    BeaconUI playerBeaconUI;

	// Use this for initialization
	void Awake () {
        playerData = GetComponent<PlayerData2D>();
		player3D = GameObject.FindWithTag("Player3D");
		ren = gameObject.GetComponent<Renderer> ();
        playerData = GetComponent<PlayerData2D>();
        playerBeacon = GetComponent<Beacon>();
        playerBeaconUI = GetComponent<BeaconUI>();
        playerData.speed = 8.0f;
        playerData.bulletPrefab = Resources.Load("Prefab/Bullet2D") as GameObject;
       
		playerData.resurrectionTime = 3.0f;
		playerData.resurrectionPenalty = 3.0f;
	}
    public void Move()
    {
		if ((playerData.playerHP > 0 && ren.enabled == true) || (playerBeacon.moveFlg == false)) {
			playerData.vectorZ = Input.GetAxisRaw("HorizontalP2");
			playerData.vectorY = Input.GetAxisRaw("VerticalP2");
		}
		else if (playerData.playerHP <= 0 && ren.enabled == true) {
			StartCoroutine ("Resurrection");
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

	}

    void BulletShot()
    {
		if (Input.GetButtonDown("MaruP2")) {
            Instantiate(playerData.bulletPrefab, transform.position, transform.rotation);
		}
	}

	public IEnumerator Resurrection(){
		ren.enabled = false;
		playerData.vectorY = 0;
		playerData.vectorZ = 0;

		while (playerData.resurrectionTime > 0) {
			playerData.resurrectionTime -= Time.deltaTime;
			yield return null;
		}
		if (playerData.resurrectionPenalty < 10.0f) {
			playerData.resurrectionPenalty += 1.0f;//復活時間の増加
		}
		playerData.resurrectionTime = playerData.resurrectionPenalty;//復活時間の再設定
		playerData.InitHP();
		gameObject.transform.position = player3D.transform.position;
		ren.enabled = true;

	}
}
