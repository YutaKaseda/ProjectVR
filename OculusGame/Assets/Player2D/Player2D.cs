using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	
    PlayerData2D playerData;

	// Use this for initialization
	void Awake () {
        playerData = GetComponent<PlayerData2D>();
        playerData.speed = 8.0f;
        playerData.laneFlg = 0;
        playerData.bulletPrefab = Resources.Load("Prefab/Bullet") as GameObject;
        playerData.zero = transform.position.z;
        playerData.inputFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		BulletShot ();

	}

    public void Move()
    {
        playerData.vectorX = Input.GetAxisRaw("Horizontal");
        playerData.vectorY = Input.GetAxisRaw("Vertical");
        playerData.movePlayer = new Vector3(playerData.vectorX * playerData.speed, playerData.vectorY * playerData.speed, 0);
        GetComponent<Rigidbody>().velocity = playerData.movePlayer;
        if (playerData.inputFlg == true)
        {
            //レーン移動
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (playerData.laneFlg < 1)
                {
                    playerData.laneFlg++;
                    if (playerData.laneFlg == 0)
                        playerData.moveEX = playerData.zero;
                    else
                        playerData.moveEX = transform.position.z + playerData.laneFlg * 5;
                    StartCoroutine("LaneMove");//コルーチンの呼び出し
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (playerData.laneFlg > -1)
                {
                    playerData.laneFlg--;
                    if (playerData.laneFlg == 0)
                        playerData.moveEX = playerData.zero;
                    else
                        playerData.moveEX = transform.position.z + playerData.laneFlg * 5;
                    StartCoroutine("LaneMove");//コルーチンの呼び出し
                }
            }
        }
	}

    public void BulletShot()
    {

		if (Input.GetKey(KeyCode.Space)) {
            Instantiate(playerData.bulletPrefab, transform.position, transform.rotation);

		}
	}
	IEnumerator LaneMove(){
        playerData.inputFlg = false;
        while (transform.position.z != playerData.moveEX)
        {
            playerData.laneMovePlayer = new Vector3(transform.position.x, transform.position.y, playerData.moveEX);
            transform.position = Vector3.MoveTowards(transform.position, playerData.laneMovePlayer, 0.5f);
			yield return null;
		}
        playerData.inputFlg = true;
	}
}
