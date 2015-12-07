using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WaveUpdate : MonoBehaviour {

	public static readonly string ENEMY_DATAEND = "END";
	public static readonly string DATANULL = "NULL";

	[SerializeField]
	List<TextAsset> waveTextList = new List<TextAsset>();
	EnemyFactory enemyFactory;

	class EnemyDate{
		public string enemyName{ get; set; }		// 呼び出す敵の名前	
		public float delayTime{ get; set; }		// 次までの待機時間
		
		public EnemyDate(string en , float dt){enemyName = en;delayTime = dt;}
	}
	EnemyDate[] waveData;

	[SerializeField]
	int arrayBox;
	int waveState;
	int arrayPosition;
	float startTime;
	float rapTime;

	[SerializeField]
	string[] waveInfo;

	void Awake () {
		enemyFactory = GameObject.Find ("EnemyFactory").GetComponent<EnemyFactory> ();
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
			Wave ();
	}

	void Wave(){

		if (waveData[arrayPosition].enemyName != DATANULL &&
		    waveData [arrayPosition].enemyName != ENEMY_DATAEND) {

			if (waveData [arrayPosition].delayTime <= (Time.realtimeSinceStartup - startTime)) {
			
				enemyFactory.Create(waveData[arrayPosition].enemyName);
				arrayPosition++;
			}

		} else {

			Debug.Log ("waveが終わったよ");
			waveState++;
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
		//waveText = Resources.Load ("Texts/wave" + waveState) as TextAsset;
		if (waveTextList [waveState] == null) {
			// ゲーム終了
			Debug.LogError ("TextNull");
			return;
		}
		waveInfo = waveTextList [waveState].text.Split ('\n');

		int nn = 0;
		string[] eachInfo;
		for (int i = 0; i < waveInfo.Length; i++) {

			eachInfo = waveInfo [i].Split ("," [0]);
			waveData [i - nn].enemyName = (eachInfo [0]);
			waveData [i - nn].delayTime = (float.Parse (eachInfo [1]));
			if (waveData [i - nn].enemyName == ENEMY_DATAEND) {
				System.Array.Resize (ref waveData, (i - nn + 1));
				break;
			}
		}
	}
	void DataInit(){

		// 配列の作成
		waveData = new EnemyDate[arrayBox];

		// クラスの初期化
		for (int i = 0; i < 100; i++) {
			waveData[i] = new EnemyDate(DATANULL,-9999);
		}

		// 配列の位置
		arrayPosition = 0;
	}
	
	void timeInit(){
		startTime = Time.realtimeSinceStartup;
	}

}
