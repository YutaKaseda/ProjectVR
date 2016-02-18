// 2/4:加速度追加・全体整理 byまさ
// 2/5:Beacon関係削除。復活処理改良 byまさ
// 2/14:Turn処理追加、調整 by梅村
// 2/15:Circumference追加 by鈴木
// 2/16:Circumference更新 by鈴木
/////////////////////////////
// 2016/02/17 中村圭吾
// bulletを呼び出す部分の変更
// 弾のgameobjectの追加
// ただしresource追加の許可を得るまでの措置
/////////////////////////////
// 2016/02/17 梅村 ui関連(lifes)の紐づけ
// 2016/02/18 鈴木
// bullet初期位置バグ修正
using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour {
	int playerTurnDirection;//1の時右向き,2のとき左向き
	int playerQuater;
	[SerializeField]
	PlayerData2D playerData2D;
	Vector3 Pos2D;	//復活用position保存
	[SerializeField]
	GameObject playerObject;
	[SerializeField]
	GameObject bullet;		//resourceに追加するのは許可を得てからやるために
	[SerializeField]
	AllUI allUI;
	void Awake () {
		allUI = GameObject.Find("UICanvas").GetComponent<AllUI>();
		playerTurnDirection = 1;
		playerQuater = 0;
		playerData2D.speed = 0.5f;
		playerData2D.pi = 3.14f;
		playerData2D.resurrectionTime = 1.0f;
	}
	
	/***移動処理***/
	public void Move(){
		if (playerData2D.playerHP > 0) {
			playerData2D.vectorZ = Input.GetAxisRaw ("HorizontalP2");
			playerData2D.vectorY = Input.GetAxisRaw ("VerticalP2");
		}
		if (playerData2D.playerHP <= 0){
			StartCoroutine("Resurrection");
		}

		if(Input.GetAxisRaw ("HorizontalP2") > 0 || Input.GetKey(KeyCode.D)){
			if(playerTurnDirection == 2){
				playerTurnDirection = 1;
				StartCoroutine("RightTurn");
			}
		}
		else if(Input.GetAxisRaw ("HorizontalP2") < 0 || Input.GetKey(KeyCode.A)){
			if(playerTurnDirection == 1){
				playerTurnDirection = 2;
				StartCoroutine("LeftTurn");
			}
		}
	
		Circumference();
		BulletShot();
	}
	
	/***撃つ処理***/
	public void BulletShot(){
		playerData2D.shotWaitTime += Time.deltaTime;
		if (Input.GetButton ("R1P2") && playerData2D.shotWaitTime > playerData2D.intervalTime) {

			//ResourcesManagerの処理に置き換えます
			GameObject shotBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			shotBullet.GetComponent<Player2DBullet>().bulletInit('R',playerData2D.degree,transform.position.y);
			playerData2D.shotWaitTime = 0;
		}
		else if (Input.GetButton ("L1P2") && playerData2D.shotWaitTime > playerData2D.intervalTime) {

			//ResourcesManagerにー
			GameObject shotBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			shotBullet.GetComponent<Player2DBullet>().bulletInit('L',playerData2D.degree,transform.position.y);
			playerData2D.shotWaitTime = 0;
		}

		if (playerData2D.shotWaitTime > playerData2D.intervalTime) {
			playerData2D.shotWaitTime = playerData2D.intervalTime;
		}
	}
	
	/***呼び出せばPlayer2Dの破壊され復活までの処理が実行される***/
	public IEnumerator Resurrection(){
		Pos2D = gameObject.transform.position;
		playerData2D.vectorZ = -100000;

		allUI.UiUpdate ("Lifes2D",0);
		allUI.UiUpdate ("ComboReset",0);

		while (playerData2D.resurrectionTime > 0) {
			playerData2D.resurrectionTime -= 1 * Time.deltaTime;
			playerData2D.InitHP();
			yield return null;
		}
		playerData2D.resurrectionTime = 1.0f;
		gameObject.transform.position = Pos2D;
	}

	/***自機のターン処理***/
	IEnumerator RightTurn(){
		while (true) {
			playerQuater += 10;
			playerObject.transform.Rotate(0,-10,0);
			if(playerQuater >= 0 || playerTurnDirection == 0){
				break;
			}
			yield return null;
		}
	}
	IEnumerator LeftTurn(){
		while (true) {
			playerQuater -= 10;
			playerObject.transform.Rotate(0,10,0);
			if(playerQuater <= -180 || playerTurnDirection == 1){
				break;
			}
			yield return null;
		}
	}

	/***呼び出せば回る 回る大きさはInspectorのRadiusを調整で変更***/
	void Circumference(){
		
		if(playerData2D.vectorZ > 0){
			playerData2D.degree++;
		}
		else if(playerData2D.vectorZ < 0){
			playerData2D.degree--;
		}
		playerData2D.position.x = playerData2D.radius * Mathf.Cos (playerData2D.pi / 180 * playerData2D.degree);
		playerData2D.position.y += playerData2D.vectorY * playerData2D.speed;
		playerData2D.position.z = playerData2D.radius * Mathf.Sin (playerData2D.pi / 180 * playerData2D.degree);
		transform.position = playerData2D.position;
		transform.eulerAngles = new Vector3 (0, -playerData2D.degree,0);
	}
}
