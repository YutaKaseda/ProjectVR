using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	
    PlayerData2D playerData;

	// Use this for initialization
	void Awake () {
        playerData = GetComponent<PlayerData2D>();
        playerData.speed = 8.0f;
        playerData.laneFlg = 0;
        playerData.bulletPrefab = Resources.Load("Prefab/Bullet2D") as GameObject;
        playerData.zero = transform.position.x;
        playerData.inputFlg = true;
	}
    public void Move()
    {
        playerData.vectorZ = Input.GetAxisRaw("HorizontalP2");
        playerData.vectorY = Input.GetAxisRaw("VerticalP2");
        playerData.movePlayer = new Vector3(0, playerData.vectorY * playerData.speed, playerData.vectorZ * playerData.speed);
        GetComponent<Rigidbody>().velocity = playerData.movePlayer;
        if (playerData.inputFlg == true)
        {
            //レーン移動
            if (Input.GetButtonDown("R1P2"))
            {
                if (playerData.laneFlg < 1)
                {
                    playerData.laneFlg++;
                    if (playerData.laneFlg == 0)
                        playerData.moveEX = playerData.zero;
                    else
                        playerData.moveEX = transform.position.x + playerData.laneFlg * 5;
                    StartCoroutine("LaneMove");//コルーチンの呼び出し
                }
            }
            if (Input.GetButtonDown("L1P2"))
            {
                if (playerData.laneFlg > -1)
                {
                    playerData.laneFlg--;
                    if (playerData.laneFlg == 0)
                        playerData.moveEX = playerData.zero;
                    else
                        playerData.moveEX = transform.position.x + playerData.laneFlg * 5;
                    StartCoroutine("LaneMove");//コルーチンの呼び出し
                }
            }
        }
        BulletShot();
	}

    void BulletShot()
    {

		if (Input.GetButton("MaruP2")) {
            Instantiate(playerData.bulletPrefab, transform.position, transform.rotation);

		}
	}
	IEnumerator LaneMove(){
        playerData.inputFlg = false;
        while (transform.position.x != playerData.moveEX)
        {
            playerData.laneMovePlayer = new Vector3(playerData.moveEX, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, playerData.laneMovePlayer, 0.5f);
			yield return null;
		}
        playerData.inputFlg = true;
	}
}
