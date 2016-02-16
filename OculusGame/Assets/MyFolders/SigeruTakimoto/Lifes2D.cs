using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本 全部

public class Lifes2D : MonoBehaviour {

	[SerializeField]
	Text lifesText;
	[SerializeField]
	PlayerData2D playerData2D;

	void Awake(){
		playerData2D.lifes = 6;
		LifesDraw ();
	}
	//確認用
	void Update () {
	if(Input.GetKeyUp(KeyCode.Z)){
			ReduceLife();
		}
	}
	//死んだとき
	public void ReduceLife(){
		playerData2D.lifes -= 1;
		LifesDraw ();
		if (playerData2D.lifes <= 0) {
			/*GAMEOVERの処理*/
		}
	}
	//表示用
	public void LifesDraw(){
		lifesText.text = "残機:"+playerData2D.lifes;
	}
}