// 2/4:加速度追加・全体整理 byまさ
// 2/5:Beacon関係削除。復活処理改良 byまさ
// 2/14:Turn処理追加、調整 by梅村
using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	int turnFlg;
	int playerQuater;

	PlayerData2D playerData;
	int i;	//弾の感覚管理
	Vector3 Pos2D;	//復活用position保存
	
	// Use this for initialization
	void Awake () {
		turnFlg = 1;
		playerQuater = 0;
		playerData = GameObject.Find("Player2D").GetComponent<PlayerData2D>();
		playerData.speed = 28.0f;
		
		playerData.resurrectionTime = 1.0f;
		playerData.resurrectionPenalty = 3.0f;
	}
	
	/***移動処理***/
	public void Move(){
		Debug.Log(gameObject.transform.localEulerAngles);
		if (playerData.playerHP > 0) {
			playerData.vectorZ = Input.GetAxisRaw ("HorizontalP2");
			playerData.vectorY = Input.GetAxisRaw ("VerticalP2");
		}
		if (playerData.playerHP <= 0){
			Debug.Log("2D_DEAD");
			StartCoroutine("Resurrection");
		}

		if(Input.GetAxisRaw ("HorizontalP2") > 0 || Input.GetKey(KeyCode.D)){
			if(turnFlg == 2){
				turnFlg = 1;
				StartCoroutine("RightTurn");
			}
		}
		else if(Input.GetAxisRaw ("HorizontalP2") < 0 || Input.GetKey(KeyCode.A)){
			if(turnFlg == 1){
				turnFlg = 2;
				StartCoroutine("LeftTurn");
			}
		}

		playerData.movePlayer = new Vector3(0, playerData.vectorY * playerData.speed, playerData.vectorZ * playerData.speed);
		GetComponent<Rigidbody>().velocity = playerData.movePlayer;
		
		BulletShot();
	}
	
	/***撃つ処理***/
	public void BulletShot(){
		if (Input.GetButton ("R1P2")) {
			Debug.Log ("Test2DShot");
			i++;
			if (i / 2 != 0 || i / 5 != 0) {
				Instantiate(ResourcesManager.Instance.GetResourceScene("Bullet2D"), transform.position, new Quaternion(0,0,0,0));
			}
		}

		else if (Input.GetButton ("L1P2")) {
			//if(Input.GetKey(KeyCode.Q)){
			Debug.Log ("Test2DShot");
			i++;
			if (i / 2 != 0 || i / 5 != 0) {
				Instantiate(ResourcesManager.Instance.GetResourceScene("Bullet2D"), transform.position,new Quaternion(0,1,0,0));
			}
		}

		if (Input.GetButtonUp ("R1P1") || Input.GetButtonUp ("L1P1")) {
			i = 0;
		}
	}
	
	/***呼び出せばPlayer2Dの破壊され復活までの処理が実行される***/
	public IEnumerator Resurrection(){
		Pos2D = gameObject.transform.position;
		playerData.vectorZ = -100000;
		
		while (playerData.resurrectionTime > 0) {
			playerData.resurrectionTime -= 1 * Time.deltaTime;
			playerData.InitHP();
			yield return null;
		}
		playerData.resurrectionTime = playerData.resurrectionPenalty;//復活時間の再設定
		gameObject.transform.position = Pos2D;
		Debug.Log(playerData.playerHP);
	}

	/***自機のターン処理***/
	IEnumerator RightTurn(){
		while (true) {
			playerQuater += 10;
			gameObject.transform.Rotate(0,-10,0);
			if(playerQuater >= 0 || turnFlg == 0){
				break;
			}
			yield return null;
		}
	}
	IEnumerator LeftTurn(){
		while (true) {
			playerQuater -= 10;
			gameObject.transform.Rotate(0,10,0);
			if(playerQuater <= -180 || turnFlg == 1){
				break;
			}
			yield return null;
		}
	}
}
