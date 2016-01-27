using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2D : MonoBehaviour {

	[SerializeField]
	Slider BulletSlider;

    PlayerData2D playerData;
	GameObject player3D;
	Renderer ren;
    Beacon playerBeacon;
    BeaconUI playerBeaconUI;

	int i;
	float SliderVol;
	bool OverHeatFlg;
	OverHeat2D overHeat2D;

	// Use this for initialization
	public void Awake () {
        playerData = GetComponent<PlayerData2D>();
		player3D = GameObject.FindWithTag("Player3D");
		ren = gameObject.GetComponent<Renderer> ();
        playerData = GetComponent<PlayerData2D>();
        playerBeacon = GetComponent<Beacon>();
        playerBeaconUI = GetComponent<BeaconUI>();
        playerData.speed = 8.0f;
		//playerData.bulletPrefab = Resources.Load("Prefabs/Play/Player/Bullet") as GameObject;



		SliderVol = BulletSlider.value;
		OverHeatFlg = true;
		//overHeat2D = GameObject.Find("overheat").GetComponent<OverHeat2D>();
       
		playerData.resurrectionTime = 3.0f;
		playerData.resurrectionPenalty = 3.0f;
	}
    public void Move()
    {
		if ((playerData.playerHP > 0 /*&& ren.enabled == true*/) || (playerBeacon.moveFlg == false)) {
			playerData.vectorZ = Input.GetAxisRaw("HorizontalP2");
			playerData.vectorY = Input.GetAxisRaw("VerticalP2");
		}
		if (playerData.playerHP <= 0 && ren.enabled == true) {
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
        //overHeat2D.BulletCoolTime();

	}

    public void BulletShot(){
	
		if (Input.GetButton ("MaruP2")) {
			SliderVol = BulletSlider.value;
			if(SliderVol >= 59f){
				OverHeatFlg = false;
			}if(SliderVol <= 0f){
				OverHeatFlg = true;
			}
			if(OverHeatFlg == true){	
				i++;
				if (i / 2 != 0 || i / 5 != 0) {
					//overHeat2D.OverHeat(0);
						//Instantiate (playerData.bulletPrefab, transform.position, transform.rotation);
                    Instantiate(ResourcesManager.Instance.GetResourceScene("Bullet2D"), transform.position, transform.rotation);
				}
			}
		}
			
		if (Input.GetButtonUp ("MaruP2")) {
			i = 0;
		}
	}

	public IEnumerator Resurrection(){
		ren.enabled = false;
		playerData.vectorZ = -100000;

		while (playerData.resurrectionTime > 0) {
			playerData.resurrectionTime -= Time.deltaTime;
			yield return null;
		}
		if (playerData.resurrectionPenalty < 10.0f) {
			playerData.resurrectionPenalty += 1.0f;//復活時間の増加
		}
		playerData.resurrectionTime = playerData.resurrectionPenalty;//復活時間の再設定
		gameObject.transform.position = player3D.transform.position;
		ren.enabled = true;
		playerData.InitHP ();

	}
}
