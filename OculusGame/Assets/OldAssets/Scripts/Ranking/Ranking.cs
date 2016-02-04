using UnityEngine;
using System.Collections;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter
using UnityEngine.UI;
using System;

public class Ranking : MonoBehaviour {

	[SerializeField]
	Text lowText;
	[SerializeField]
	Text superiorText;

	public Text myScore;

	//表示用　とtext読込用
	private string guitxt = "";
	private string outputFileName = "Assets/ranking.txt";
	public InputField inputField;
	public TextAsset ranking;

	//	SAVE用
	string[]SAVE = new string[10]; 
	int[]Score = new int[10];
	string[] Name = new string[10];
	string stCsvData;

	//表示用
	string[] superiorRank = new string[5];
	string[] lowRank = new string[5];

	//数値は仮当て 終了時のSCORE代入
	int  nowScore = 300000000;

	//rankインしているかの判定用
	int myRanking = -1;

	//ループなどのカウント用
	int Flg;

	//自分のRANKINGが確定した場合
	bool rankingConfirm = false;
	
	void Awake() 
	{
		textRead();
		Replacement();
	}
	void Update () {
		if (myRanking >= 0)
		{
			NameInput ();
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			SaveRanking();
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
	void SaveRanking()
	{
	//セーブ用
		FileStream  Save = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
		BinaryWriter writer = new BinaryWriter(Save);
		stCsvData = string.Join("\n",SAVE);
		writer.Write (stCsvData);
		writer.Close();
	}
	void OnText()
	{
		for (Flg =0; Flg<5; Flg++)
		{
			//1~5位,6~10位の値入れ込み
			lowRank[Flg] =" " + Score [Flg+5] + " " + Name [Flg+5];
			superiorRank[Flg] =" " + Score [Flg] + " " + Name [Flg];
			SAVE[Flg] = " " + Score [Flg] + " " + Name [Flg];
			SAVE[Flg+5] =" " + Score [Flg+5] + " " + Name [Flg+5];
		}
		//現在のSCORE入れる
		myScore.text = "SCORE:" + nowScore;
		//１～５位表示
		stCsvData = string.Join("\n",superiorRank);
		superiorText.text = stCsvData;
		//６～９位表示
		stCsvData = string.Join("\n",lowRank);
		lowText.text = stCsvData;
	}
	void NameInput(){
	//名前入力
		int A = inputField.text.Length;
		if (A <= 10) {
			Name [myRanking] = inputField.text;
			SAVE [myRanking] = " " + Score [myRanking] + " " + Name [myRanking];
		}
		OnText ();
	}

	void Replacement(){
		//自分の順位はどこか確認
	
		for(Flg = 0;Flg < 10; Flg ++)
		{
			switch(Flg)
			{
			case 0:
				if(nowScore > Score[Flg])
				{
					myRanking = Flg;
					rankingConfirm = true;
				}
				break;
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
				if(nowScore > Score[Flg] ||
				   nowScore == Score[Flg-1] && nowScore != Score[Flg])
				{
					myRanking = Flg;
					rankingConfirm = true;
				}
				break;
			}
			//自分のRANKINGが確定した場合入れ替え処理
			if(rankingConfirm == true)
			{
				for(Flg = 9;Flg >= myRanking;Flg--)
				{
					Score[Flg] = Score[Flg-1];
					Name[Flg] = Name[Flg-1];
				}
				Score[myRanking] = nowScore;
				Name[myRanking] = "";
				break;
			}
		}
		OnText ();
	}
}