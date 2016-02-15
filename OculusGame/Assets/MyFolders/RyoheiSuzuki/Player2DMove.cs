//  2016/02/15  鈴木亮平  更新
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2DMove : MonoBehaviour {
	
	PlayerData2D playerData;

	// Use this for initialization
	void Awake () {
		playerData = GetComponent<PlayerData2D>();
		playerData.speed = 8.0f;
		playerData.degree = 0;
		playerData.pi = 3.14f;
	}
	
	public void Move()
	{
		if (playerData.playerHP > 0) {
			playerData.vectorZ = Input.GetAxisRaw("HorizontalP2");
			playerData.vectorY = Input.GetAxisRaw("VerticalP2");
		}
		
		//playerData.movePlayer = transform.TransformDirection(0, playerData.vectorY * playerData.speed, playerData.vectorZ * playerData.speed);//new Vector3(0, playerData.vectorY * playerData.speed, playerData.vectorZ * playerData.speed);
		//GetComponent<Rigidbody>().velocity = playerData.movePlayer;
		Circumference();
		BulletShot();
	}
	
	public void BulletShot(){
		if (Input.GetButton ("BatuP2")) {
			Instantiate(ResourcesManager.Instance.GetResourceScene("Bullet2D"), transform.position, transform.rotation);
		}
	}

	public void Circumference(){

		if(playerData.vectorZ > 0){
			playerData.degree++;
		}
		else if(playerData.vectorZ < 0){
			playerData.degree--;
		}
		playerData.position.x = playerData.radius * Mathf.Cos (playerData.pi / 180 * playerData.degree);
		//playerData.playerPosition.y = 
		playerData.position.z = playerData.radius * Mathf.Sin (playerData.pi / 180 * playerData.degree);

		transform.position = playerData.position;
		transform.eulerAngles = new Vector3 (0, -playerData.degree,0);
	}
}