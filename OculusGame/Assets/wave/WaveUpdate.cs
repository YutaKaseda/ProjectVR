using UnityEngine;
using System.Collections;


public class WaveUpdate : MonoBehaviour {

	public static readonly string ENEMY_DATAEND = "end";
	public static readonly string DATANULL = "DataNull";


	[SerializeField]
	TextAsset waveText;
	[SerializeField]
	GameObject enemyFactory;


	class EnemyDate{
		string enemyName;		// 呼び出す敵の名前	
		float delayTime;		// 次までの待機時間
		
		public EnemyDate(string en , float dt){enemyName = en;delayTime = dt;}
		public void SetName(string en){enemyName = en;}
		public void SetDelayTime(float dt){delayTime = dt;}
		public string GetName(){return enemyName;}
		public float GetDelayTime(){return delayTime;}

	}
	EnemyDate[] waveData01;

	int waveState;
	int ArrayPosition;
	float stratTime;
	float rapTime;
	
	string[] wave01Info;
	string[] eachInfo;

	void Awake () {

		enemyFactory = GameObject.Find ("EnemyFactory");
		waveState = 0;

		// 配列などの初期化
		DataInit ();
		// Textの読込
		LoadText ();
		// タイマーの初期化
		timeInit ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waveText != null) {
			Wave ();
		}

	}

	void Wave(){

		if (waveData01[ArrayPosition].GetName () != DATANULL &&waveData01 [ArrayPosition].GetName () != ENEMY_DATAEND) {
			if (waveData01 [ArrayPosition].GetDelayTime () <= (Time.realtimeSinceStartup - stratTime)) {
			
				enemyFactory.GetComponent<EnemyFactory>().Create(waveData01[ArrayPosition].GetName());
				ArrayPosition++;
			}

		} else {

			Debug.Log ("waveが終わったよ");

			// 配列の初期化
			DataInit();
			// 次のテキストの読込
			LoadText();
			// タイマーのリセット
			timeInit();

		}
	}

	// textを読込enemyDateクラスの配列に登録

	void LoadText (){

		// 読み込むwaveの情報のテキストを取得
		// waveが進む際にも呼ばれるため読み込むテキストの変更も
		waveState++;
		waveText = Resources.Load ("Texts/wave" + waveState) as TextAsset;
		if (waveText == null) {
			// ゲーム終了
			Debug.LogError("TextNull");
			return;
		}

		wave01Info = waveText.text.Split('\r','\n');

		int nn = 0;
		for (int i = 0; i < wave01Info.Length; i++) {

			eachInfo = wave01Info [i].Split ("," [0]);
			if(wave01Info[i] != "/"){
				waveData01[i-nn].SetName(eachInfo[0]);
				waveData01[i-nn].SetDelayTime(float.Parse(eachInfo[1]));
			}
			else{
				nn++;
			}
			if(waveData01[i-nn].GetName() == ENEMY_DATAEND){
				System.Array.Resize(ref waveData01,(i - nn + 1));
				/*
				for(int j=0;j<(i-nn+1);j++){
					Debug.Log ("waveData["+j+"] Name :"+waveData01[j].GetName()+"  Time :"+waveData01[j].GetDelayTime());
				}
				*/
				break;
			}
		}

	}
	
	void DataInit(){

		// 配列の作成
		waveData01 = new EnemyDate[100];

		// クラスの初期化
		for (int i = 0; i < 100; i++) {
			waveData01[i] = new EnemyDate(DATANULL,-9999);
		}

		// 配列の位置
		ArrayPosition = 0;
	}
	
	void timeInit(){
		stratTime = Time.realtimeSinceStartup;
	}

}
