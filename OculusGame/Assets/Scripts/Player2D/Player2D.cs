using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	
    PlayerData2D playerData;
	GameObject player3D;
	Renderer ren;
	// Use this for initialization
	void Awake () {
        playerData = GetComponent<PlayerData2D>();
		player3D = GameObject.FindWithTag("Player3D");
		ren = gameObject.GetComponent<Renderer> ();
        playerData.speed = 8.0f;
        playerData.laneFlg = 0;
        playerData.bulletPrefab = Resources.Load("Prefab/Bullet2D") as GameObject;
        playerData.zero = transform.position.x;
        playerData.inputFlg = true;
		playerData.resurrectionTime = 3.0f;
		playerData.resurrectionPenalty = 3.0f;
	}
    public void Move()
    {
        

		if (playerData.playerHP > 0 && ren.enabled == true) {
			playerData.vectorZ = Input.GetAxisRaw("HorizontalP2");
			playerData.vectorY = Input.GetAxisRaw("VerticalP2");
		}
		else if (playerData.playerHP <= 0 && ren.enabled == true) {
			StartCoroutine ("Resurrection");
		}
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

		if (Input.GetButtonDown("MaruP2")) {
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
