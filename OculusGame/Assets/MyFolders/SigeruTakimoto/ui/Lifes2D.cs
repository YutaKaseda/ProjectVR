using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本  ReduceLife,LifesDraw
// 2016/02/17 梅村 Text周りをちょっと修正
// 2016/02/19 梅村 全体的に見やすくなったかな？
public class Lifes2D : MonoBehaviour {

	PlayerData2D playerData2D;
	Text lifesText;

	void Awake(){
		playerData2D = GameObject.FindWithTag("Player2D").GetComponent<PlayerData2D>();
		lifesText = GameObject.Find("Lifes2DText").GetComponent<Text>();
		playerData2D.lifes = 6;
		LifesDraw ();
	}

	//2D死んだとき呼ぶ
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