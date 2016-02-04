using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameMainData;

public class UI : MonoBehaviour {
	enum UiState{
		NONE = -1,
		MENU = 0,
		SHIP,
		WEAPON,
		BALKAN,
		LASER,
		BOMB
	}

	[SerializeField]
	GameObject[] ui = new GameObject[6];
	[SerializeField]
	GameObject[] ship = new GameObject[3];
	[SerializeField]
	Image select;

	UiState prevGarageState;//前のシーン
	UiState garageState;	//今のシーン
	UiState nextGarageState;//次のシーン

	int nowSelection;//選択しているもの
	int itemNo;		 //項目数
	int nowOk;		 //決定時何を選択しているか

	float AxisY;
	int inputCnt;
	// Use this for initialization
	void Start () {
		prevGarageState = UiState.NONE;
		garageState = UiState.NONE;
		nextGarageState = UiState.MENU;
		nowSelection = 1;
		itemNo = 2;
		nowOk = 0;
		inputCnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//今どのシーンか
		switch (garageState) {
		case UiState.MENU:
			if(nowOk == -1){
				GameData.nextState = OfflineStatus.E_OFFLINE_STATE.MENU;
			}
			if(nowOk == 1){
				nextGarageState = UiState.SHIP;
			}
			if(nowOk == 2){
				nextGarageState = UiState.WEAPON;
			}
			break;
		case UiState.SHIP:
			if(nowOk == -1){
				nextGarageState = UiState.MENU;
			}
			if(nowOk == 1){
				nextGarageState = UiState.MENU;
			}
			if(nowOk == 2){
				nextGarageState = UiState.MENU;
			}
			if(nowOk == 3){
				nextGarageState = UiState.MENU;
			}

			ModelChange();
			break;
		case UiState.WEAPON:
			if(nowOk == -1){
				nextGarageState = UiState.MENU;
			}
			if(nowOk == 1){
				nextGarageState = UiState.BALKAN;
			}
			if(nowOk == 2){
				nextGarageState = UiState.LASER;
			}
			if(nowOk == 3){
				nextGarageState = UiState.BOMB;
			}
			break;
		case UiState.BALKAN:
			if(nowOk == -1){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 1){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 2){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 3){
				nextGarageState = UiState.WEAPON;
			}
			break;
		case UiState.LASER:
			if(nowOk == -1){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 1){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 2){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 3){
				nextGarageState = UiState.WEAPON;
			}
			break;
		case UiState.BOMB:
			if(nowOk == -1){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 1){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 2){
				nextGarageState = UiState.WEAPON;
			}
			if(nowOk == 3){
				nextGarageState = UiState.WEAPON;
			}
			break;
		default:
			break;
		}

		//次のシーンに移るなら実行
		while(nextGarageState != UiState.NONE)
		{
			nowSelection = 1;
			prevGarageState = garageState;//今のシーンを古いものへ
			garageState = nextGarageState;//次ののシーンを今のシーンへ
			nextGarageState = UiState.NONE;//次のシーンは空に//それぞれ代入

			//シーン遷移
			switch(garageState)
			{
			case UiState.MENU:
				itemNo = 2;
				ui[(int)UiState.MENU].SetActive(true);
				break;
			case UiState.SHIP:
				itemNo = 3;
				ui[(int)UiState.SHIP].SetActive(true);
				break;
			case UiState.WEAPON:
				itemNo = 3;
				ui[(int)UiState.WEAPON].SetActive(true);
				break;
			case UiState.BALKAN:
				itemNo = 3;
				ui[(int)UiState.BALKAN].SetActive(true);
				break;
			case UiState.LASER:
				itemNo = 3;
				ui[(int)UiState.LASER].SetActive(true);
				break;
			case UiState.BOMB:
				itemNo = 3;
				ui[(int)UiState.BOMB].SetActive(true);
				break;
			}

			//古いシーンは消す
			switch(prevGarageState)
			{
			case UiState.MENU:
				ui[(int)UiState.MENU].SetActive(false);
				break;
			case UiState.SHIP:
				ui[(int)UiState.SHIP].SetActive(false);
				break;
			case UiState.WEAPON:
				ui[(int)UiState.WEAPON].SetActive(false);
				break;
			case UiState.BALKAN:
				ui[(int)UiState.BALKAN].SetActive(false);
				break;
			case UiState.LASER:
				ui[(int)UiState.LASER].SetActive(false);
				break;
			case UiState.BOMB:
				ui[(int)UiState.BOMB].SetActive(false);
				break;
			}
		}
		nowOk = KeyCommand ();
	}

	//キー操作
	int KeyCommand(){

		AxisY = Input.GetAxisRaw("VerticalP1");
		inputCnt++;
		if(AxisY == 0){
			inputCnt = 50;
		}
		if ((Input.GetKeyDown (KeyCode.UpArrow) || AxisY > 0.1f) && inputCnt > 30) {
			nowSelection--;
			inputCnt = 0;
		}
		else if ((Input.GetKeyDown (KeyCode.DownArrow) || AxisY < -0.1f) && inputCnt > 30) {
			nowSelection++;
			inputCnt = 0;
		}
		else if (Input.GetKeyDown (KeyCode.Return) || Input.GetButtonUp("MaruP1")){
			return nowSelection;
		}
		else if (Input.GetKeyDown (KeyCode.RightShift) || Input.GetButtonUp("BatuP1")){
			return -1;
		}
		else if (Input.GetKeyDown (KeyCode.R) || Input.GetButtonUp("StartP1")){
			Application.LoadLevel("OnlinePlay");//とりあえず飛べ
		}
		if (nowSelection < 1) {
			nowSelection = itemNo;
		}
		if (nowSelection > itemNo) {
			nowSelection = 1;
		}
		Select ();
		Debug.Log (nowSelection);
		return 0;
	}

	void ModelChange(){
		ship [0].SetActive (false);
		ship [1].SetActive (false);
		ship [2].SetActive (false);
		ship [nowSelection - 1].SetActive (true);
	}

	void Select(){
		switch(nowSelection){
		case 1:
			select.transform.localPosition = new Vector2 (-275,110);
			break;
		case 2:
			select.transform.localPosition = new Vector2 (-275,50);
			break;
		case 3:
			select.transform.localPosition = new Vector2 (-275,-10);
			break;
		}
	}
}
