using UnityEngine;
using System.Collections;

public class BossMk2 : MonoBehaviour {

	int bossMotionFlg;	//後々増やすことを前提にint型
	Vector3 bossPos;
	GameObject player2D;
	GameObject player3D;
	Vector3 targetPos;
	float bossRotationSpeed;
	float bossWaitTime;
	Vector3 warpPosition;
	int warpPointNumber;
	int nowPositionNumber = 0;
	int nextPositionNumber = 0;
	[SerializeField]
	public GameObject [] warpPoint = new GameObject[ 1];

	void Awake(){
		player2D = GameObject.Find ("Player2D");
		player3D = GameObject.Find ("Player3D");
		bossMotionFlg = 0;
		bossRotationSpeed = 0.6f;
		bossWaitTime = 1.0f;
		warpPointNumber = warpPoint.Length;

		StartCoroutine("Warp");
	}

	void Update(){
		if (Input.GetKey (KeyCode.K)) {
			bossMotionFlg = 0;
		}
		if (Input.GetKey (KeyCode.D)) {
			bossMotionFlg = 1;
		}

		LockOn ();
	}
	
	public IEnumerator Warp(){
		while(true){
			this.transform.position = WarpPointGet(warpPosition);
			SoundPlayer.Instance.PlaySoundEffect("warp", 0.2f);
			yield return new WaitForSeconds (bossWaitTime);
		};
	}

	Vector3 WarpPointGet(Vector3 pos){
		while (nowPositionNumber == nextPositionNumber) {
			 nextPositionNumber = Random.Range (0, warpPointNumber);
		}
		nowPositionNumber = nextPositionNumber;
		return warpPoint [nowPositionNumber].transform.position;
	}

	void LockOn(){
		if (bossMotionFlg == 0) {
			targetPos = player2D.transform.position;
		} else if (bossMotionFlg == 1) {
			targetPos = player3D.transform.position;
		}

		transform.rotation = CalcRotationLeap(targetPos);
	}

	Quaternion CalcRotationLeap(Vector3 targetPos){
		var rotation = Quaternion.LookRotation(targetPos - transform.position);
		return Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * bossRotationSpeed);
	}

	void Shot(){
		Debug.Log ("BossShot");
	}

}
