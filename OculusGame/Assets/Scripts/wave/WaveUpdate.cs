using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WaveUpdate : MonoBehaviour {

	public static readonly string ENEMY_DATAEND = "END";
	public static readonly string DATANULL = "NULL";
	public static readonly string WAVEDATE_END = "END,-9999,-9999,-9999,-9999";

	[SerializeField]
	List<TextAsset> waveTextList = new List<TextAsset>();
	EnemyFactory enemyFactory;

	class EnemyDate{
		public string enemyName{ get; set; }	// 呼び出す敵の名前	
		public float delayTime{ get; set; }		// 次までの待機時間
		public float pointX{ get; set; }		// 座標x
		public float pointY{ get; set; }		// 座標y
		public float pointZ{ get; set; }		// 座標z
		
		public EnemyDate(string en , float dt){enemyName = en;delayTime = dt;}
	}
	EnemyDate[] waveData;

	[SerializeField]
	int arrayBox;
	int waveState;
	int arrayPosition;
	float startTime;
	float rapTime;

	string[] waveInfoArray;
	[SerializeField]
	List<string> waveInfo = new List<string>();

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
			
				enemyFactory.Create(waveData[arrayPosition].enemyName ,
				                    new Vector3(waveData[arrayPosition].pointX ,
				            					waveData[arrayPosition].pointY ,
				            					waveData[arrayPosition].pointZ)
				                    );
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
		waveInfoArray = waveTextList [waveState].text.Split ('\n');
		int reSize = 0;
		string[] eachInfo;
		for (int i = 0; i < waveInfoArray.Length; i++) {
			waveInfo.Add (waveInfoArray [i]);
		}
		StartCoroutine ("ArrayWhile");

		for (int i = 0; i < waveInfo.Count; i++) {

			eachInfo = waveInfo [i].Split ("," [0]);
			waveData [i - reSize].enemyName = (eachInfo [0]);
			waveData [i - reSize].delayTime = (float.Parse (eachInfo [1]));
			waveData [i - reSize].pointX = (float.Parse (eachInfo [2]));
			waveData [i - reSize].pointY = (float.Parse (eachInfo [3]));
			waveData [i - reSize].pointZ = (float.Parse (eachInfo [4]));
			if (waveData [i - reSize].enemyName == ENEMY_DATAEND) {
				System.Array.Resize (ref waveData, (i - reSize + 1));
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

	IEnumerator ArrayWhile(){
		int arrayInt = 0;
		while(waveInfo[arrayInt] != WAVEDATE_END) {
			if (waveInfo [arrayInt].StartsWith ("#")) {
				waveInfo.RemoveAt (arrayInt);
				arrayInt = 0;
			}else{
				arrayInt++;
			}
			if(waveInfo[arrayInt] == WAVEDATE_END){
				break;
			}
		}

		yield return null;
	}

}
