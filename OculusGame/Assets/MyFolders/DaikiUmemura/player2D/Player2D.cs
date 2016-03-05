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
// 2016/02/18 鈴木 bullet初期位置バグ修正
// 2016/03/1 梅村 ui関連
// 2016/03/4 梅村 missile追加
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player2D : MonoBehaviour {
	int playerTurnDirection;//1の時右向き,2のとき左向き
	int playerQuater;
	bool isDead;
	[SerializeField]
	PlayerData2D playerData2D;
	[SerializeField]
	GameObject playerObject;
	[SerializeField]
	GameObject bullet;		//resourceに追加するのは許可を得てからやるために
	[SerializeField]
	GameObject missile;
	[SerializeField]
	AllUI allUI;

	[SerializeField]
	GameObject zikki2D;
	[SerializeField]
	GameObject missilePod;
    bool vulcanPlaySound = false;

	void Awake () {
		allUI = GameObject.FindWithTag("UI").GetComponent<AllUI>();
		isDead = false;
		playerTurnDirection = 1;
		playerQuater = 0;
		playerData2D.speed = 0.5f;
		playerData2D.pi = 3.14f;
		playerData2D.resurrectionTime = 3.0f;
		playerData2D.InitHP ();
		playerData2D.lifes = 6;
	}
	
	/***移動処理***/
	public void Main(){
	//void Update(){
		if (isDead == false) {
			playerData2D.vectorZ = Input.GetAxisRaw ("HorizontalP2");
			playerData2D.vectorY = Input.GetAxisRaw ("VerticalP2");
            Circumference();
            BulletShot();
		} else {
			playerData2D.vectorY = 0;
			playerData2D.vectorZ = 0;
		}

		if(Input.GetAxisRaw ("HorizontalP2") > 0){
			if(playerTurnDirection == 2){
				playerTurnDirection = 1;
				StartCoroutine("RightTurn");
			}
		}
		else if(Input.GetAxisRaw ("HorizontalP2") < 0){
			if(playerTurnDirection == 1){
				playerTurnDirection = 2;
				StartCoroutine("LeftTurn");
			}
		}

	}
	
	/***撃つ処理***/
	public void BulletShot(){
		playerData2D.shotWaitTime += Time.deltaTime;
		playerData2D.missileWaitTime += Time.deltaTime;
		if (Input.GetButton ("R1P2")) {

			if(playerData2D.shotWaitTime > playerData2D.intervalTime){
				//ResourcesManagerの処理に置き換えます
				GameObject shotBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
				shotBullet.GetComponent<Player2DBullet>().BulletInit('R',playerData2D.degree,transform.position.y,"NomalBullet");

	            if (!vulcanPlaySound)
	            {
	                vulcanPlaySound = true;
	                SoundPlayer.Instance.PlaySoundEffect("Balkan2", 0.5f);
	                StartCoroutine(VulcanSoundInterval(0.2f));
	            }
				playerData2D.shotWaitTime = 0;
			}

			if(playerData2D.missileWaitTime > playerData2D.missileIntervalTime){
				//ResourcesManagerの処理に置き換えます
				GameObject shotMissile = Instantiate(missile, missilePod.transform.position, transform.rotation) as GameObject;
				shotMissile.GetComponent<Player2DBullet>().BulletInit('R',playerData2D.degree,missilePod.transform.position.y,"HomingMissile");
				
				if (!vulcanPlaySound)
				{
					vulcanPlaySound = true;
					SoundPlayer.Instance.PlaySoundEffect("Balkan2", 0.5f);
					StartCoroutine(VulcanSoundInterval(0.2f));
				}
				playerData2D.missileWaitTime = 0;
			}
		}
		else if (Input.GetButton ("L1P2")) {
			if(playerData2D.shotWaitTime > playerData2D.intervalTime){
				//ResourcesManagerにー
				GameObject shotBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
				shotBullet.GetComponent<Player2DBullet>().BulletInit('L', playerData2D.degree, transform.position.y,"NomalBullet");
	            if (!vulcanPlaySound)
	            {
	                vulcanPlaySound = true;
	                SoundPlayer.Instance.PlaySoundEffect("Balkan2", 0.5f);
	                StartCoroutine(VulcanSoundInterval(0.2f));
	            }
	            playerData2D.shotWaitTime = 0;
			}

			if(playerData2D.missileWaitTime > playerData2D.missileIntervalTime){
				//ResourcesManagerの処理に置き換えます
				GameObject shotMissile = Instantiate(missile, missilePod.transform.position,transform.rotation) as GameObject;
				shotMissile.GetComponent<Player2DBullet>().BulletInit('L',playerData2D.degree,missilePod.transform.position.y,"HomingMissile");
				
				if (!vulcanPlaySound)
				{
					vulcanPlaySound = true;
					SoundPlayer.Instance.PlaySoundEffect("Balkan2", 0.5f);
					StartCoroutine(VulcanSoundInterval(0.2f));
				}
				playerData2D.missileWaitTime = 0;
			}
		}

		if (playerData2D.shotWaitTime > playerData2D.intervalTime) {
			playerData2D.shotWaitTime = playerData2D.intervalTime;
		}
		if (playerData2D.missileWaitTime > playerData2D.missileIntervalTime) {
			playerData2D.missileWaitTime = playerData2D.missileIntervalTime;
		}
	}
	
	/***呼び出せばPlayer2Dの破壊され復活までの処理が実行される***/
	public IEnumerator Resurrection(){

		SoundPlayer.Instance.PlaySoundEffect("Bomb",1.0f);
		EffectFactory.Instance.Create("bom",transform.position,transform.rotation);
        GetComponent<BoxCollider>().enabled = false;

		allUI.UiUpdate ("Lifes2D",0);
		allUI.UiUpdate ("ComboReset",0);
		isDead = true;
		zikki2D.SetActive (false);

		while (playerData2D.resurrectionTime > 0) {
			playerData2D.resurrectionTime -= 1 * Time.deltaTime;
			yield return null;
		}
		isDead = false;
		zikki2D.SetActive (true);
		playerData2D.resurrectionTime = 3.0f;

        yield return new WaitForSeconds(2.0f);

        GetComponent<BoxCollider>().enabled = true;

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

        if (playerData2D.position.y >= 120)
            playerData2D.position.y = 120;
        if (playerData2D.position.y <= -20)
            playerData2D.position.y = -20;

		transform.position = playerData2D.position;
		transform.eulerAngles = new Vector3 (0, -playerData2D.degree,0);
	}

    IEnumerator VulcanSoundInterval(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        vulcanPlaySound = false;
    }

	void OnTriggerEnter(Collider other){
		switch (other.gameObject.tag) {

        case "Enemy":
        case "Boss":
		case "Railgun":
			if(isDead == false)
			StartCoroutine("Resurrection");
			break;
		}
	}
}
