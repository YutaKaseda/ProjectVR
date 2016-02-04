using UnityEngine;
using System.Collections;

//プレイヤーの３D移動の所　以下のやつを追加してください
public class P3D : MonoBehaviour {

	//準備
	GameObject play3d;
	float stayTime; 
	
	void Awake(){
		//ベースビーコンの座標取得
		play3d=GameObject.Find("player");
		}
		/*
		if (キー設定) {
			BeaconWarp ();
		}else {
			stayTime =0;
		}*/
	//ベースビーコンの移動
public void BeaconWarp(){
			stayTime += Time.deltaTime * 1f;
			if (stayTime > 2f) {
				transform.position = play3d.GetComponent<Player3D> ().basebeacon;
				stayTime = 0;
			}
		} 




}
