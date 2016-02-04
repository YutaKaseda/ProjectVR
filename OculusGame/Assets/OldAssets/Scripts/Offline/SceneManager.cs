using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
	enum SceneState{
		NONE = -1,
		TITLE = 0,
		MENU,
		GARAGE,
		RANKING,
		OPTION
	}
	
	[SerializeField]
	GameObject[] SceneObject = new GameObject[5];
	
	SceneState prevState;//前のシーン
	SceneState nowState; //今のシーン
	SceneState nextState;//次のシーン
	
	int nowSelection;//選択しているもの
	int itemNo;		 //項目数
	int nowOk;		 //決定時何を選択しているか
	// Use this for initialization
	void Start () {
		prevState = SceneState.NONE;
		nowState = SceneState.NONE;
		nextState = SceneState.TITLE;
		nowSelection = 1;
		itemNo = 2;
		nowOk = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//今どのシーンか
		switch(nowState){
		case SceneState.TITLE:
			if (nowOk == 1) {
				nextState = SceneState.MENU;
			}
			break;
		case SceneState.MENU:
			if (nowOk == 1) {
				nextState = SceneState.GARAGE;
			}
			if (nowOk == 2) {
				nextState = SceneState.RANKING;
			}
			if (nowOk == 3) {
				nextState = SceneState.OPTION;
			}
			break;
		case SceneState.GARAGE:
			if (nowOk == -1) {
				nextState = SceneState.MENU;
			}
			break;
		case SceneState.RANKING:
			if (nowOk == -1) {
				nextState = SceneState.MENU;
			}
			break;
		case SceneState.OPTION:
			if (nowOk == -1) {
				nextState = SceneState.MENU;
			}
			break;
		default:
			break;
		}
		//次のシーンに移るなら実行
		while(nextState != SceneState.NONE)
		{
			nowSelection = 1;
			prevState = nowState;//今のシーンを古いものへ
			nowState = nextState;//次ののシーンを今のシーンへ
			nextState = SceneState.NONE;//次のシーンは空に//それぞれ代入
			
			//シーン遷移
			switch(nowState)
			{
			case SceneState.TITLE:
				itemNo = 1;
				SceneObject[(int)SceneState.TITLE].SetActive(true);
				break;
			case SceneState.MENU:
				itemNo = 3;
				SceneObject[(int)SceneState.MENU].SetActive(true);
				break;
			case SceneState.GARAGE:
				itemNo = 1;
				SceneObject[(int)SceneState.GARAGE].SetActive(true);
				break;
			case SceneState.RANKING:
				itemNo = 1;
				SceneObject[(int)SceneState.RANKING].SetActive(true);
				break;
			case SceneState.OPTION:
				itemNo = 1;
				SceneObject[(int)SceneState.OPTION].SetActive(true);
				break;
			}
			
			//古いシーンは消す
			switch(prevState)
			{
			case SceneState.TITLE:
				SceneObject[(int)SceneState.TITLE].SetActive(false);
				break;
			case SceneState.MENU:
				SceneObject[(int)SceneState.MENU].SetActive(false);
				break;
			case SceneState.GARAGE:
				SceneObject[(int)SceneState.GARAGE].SetActive(false);
				break;
			case SceneState.RANKING:
				SceneObject[(int)SceneState.RANKING].SetActive(false);
				break;
			case SceneState.OPTION:
				SceneObject[(int)SceneState.OPTION].SetActive(false);
				break;
			}
		}
		nowOk = KeyCommand ();
	}
	
	//キー操作
	int KeyCommand(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			nowSelection--;
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			nowSelection++;
		}
		else if (Input.GetKeyDown (KeyCode.Return)){
			return nowSelection;
		}
		else if (Input.GetKeyDown (KeyCode.RightShift)){
			return -1;
		}
		
		if (nowSelection < 1) {
			nowSelection = itemNo;
		}
		if (nowSelection > itemNo) {
			nowSelection = 1;
		}
		Debug.Log (nowSelection);
		return 0;
	}

}
