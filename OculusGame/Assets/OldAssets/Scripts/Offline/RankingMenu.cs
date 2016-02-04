using UnityEngine;
using System.Collections;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter
using UnityEngine.UI;
using GameMainData;

public class RankingMenu : MonoBehaviour {
	
	[SerializeField]
	Text lowText;
	[SerializeField]
	Text superiorText;

	//text読込用
	public TextAsset ranking;
	int[]Score = new int[10];
	string[] Name = new string[10];
	string stCsvData;

	//表示用
	string[] superiorRank = new string[5];
	string[] lowRank = new string[5];

	//for文用関数
	int Flg;

	void Awake() 
	{
		textRead();
		OnText();
	}

	void Update(){
		if(Input.GetKeyUp(KeyCode.RightShift)|| Input.GetButtonUp("BatuP1")){
			GameData.nextState = OfflineStatus.E_OFFLINE_STATE.MENU;
		}
	}

	void textRead()
	{
		char[] kugiri = {'\r', '\n'};
		string[] layoutInfo = ranking.text.Split(kugiri);
		string[] eachInfo;
		for (int i = 0; i < layoutInfo.Length; i++)
		{
			eachInfo = layoutInfo[i].Split(" "[0]);
			Score[i] = int.Parse(eachInfo[1]);
			Name[i] = eachInfo[2];
		}
	}

	void OnText()
	{
		for (Flg = 0; Flg < 5; Flg++)
		{
			//1~5位,6~10位の値入れ込み
			lowRank[Flg] =" " + Score [Flg + 5] + "   " + Name [Flg + 5];
			superiorRank[Flg] =" " + Score [Flg] + "   " + Name [Flg];
		}
		//１～５位表示
		stCsvData = string.Join("\n",superiorRank);
		superiorText.text = stCsvData;
		//６～９位表示
		stCsvData = string.Join("\n",lowRank);
		lowText.text = stCsvData;
	}
}