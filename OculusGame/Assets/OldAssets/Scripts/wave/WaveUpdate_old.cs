using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WaveUpdate_old : MonoBehaviour {

	public static readonly string ENEMY_DATAEND = "END";
	public static readonly string DATANULL = "NULL";
	public static readonly string WAVEDATE_END = "END,-9999,-9999,-9999,-9999";
	public static readonly string WAVE_BOSS = "boss";

	[SerializeField]
	List<TextAsset> waveTextList = new List<TextAsset>();
	EnemyFactory enemyFactory;
	[SerializeField]
	ResultScore resultScore;

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
	int arrayBox;			// 配列の初期個数100くらいに設定してください
	int waveState;			// Waveの進行数
	int arrayPosition;		// 配列の今の場所,敵生成時に使用
	float startTime;		// タイマーの開始時間
	float timeRap;			// 特定のタイミングの時間を記憶するときに使用
	[SerializeField]
	float stayTime;			// Waveが終わってどのくらい待つか
	string[] waveInfoArray;
	[SerializeField]
	List<string> waveInfo = new List<string>();
	bool socreFlg = false;
	public bool bossFlg = false;
	[SerializeField]
	Beacon beacon;

	void Awake () {
		waveTextList.Add(null);
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

		if (beacon.baseBeacon == true)
			Wave ();
		else
			timeInit ();
	}

	public void Wave(){

		if (waveData [arrayPosition].enemyName != DATANULL &&
			waveData [arrayPosition].enemyName != ENEMY_DATAEND &&
		    bossFlg == false) {

			if (waveData [arrayPosition].delayTime <= (Time.realtimeSinceStartup - startTime)) {
				enemyFactory.Create (waveData [arrayPosition].enemyName,
				                    new Vector3 (waveData [arrayPosition].pointX,
				            					waveData [arrayPosition].pointY,
				            					waveData [arrayPosition].pointZ)
				);
				if(waveData[arrayPosition].enemyName.Contains(WAVE_BOSS)){
					bossFlg = true;
				}
				arrayPosition++;
			} else {
				timeRap = Time.realtimeSinceStartup - startTime;
			}

		} else if(bossFlg == true) {

		}else {

			if(socreFlg == false && (Time.realtimeSinceStartup - startTime) >= (timeRap + (stayTime))){
                Debug.Log("result");
             //   resultScore.InitScoreText();
			//	socreFlg = true;
			//}
			//if(socreFlg == true && resultScore.resultViweFlg == false){
			//	socreFlg = false;
				NextWave();
			}
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
			this.gameObject.SetActive(false);
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
		for (int i = 0; i < arrayBox; i++) {
			waveData[i] = new EnemyDate(DATANULL,-9999);
		}

		// 配列の位置
		arrayPosition = 0;
		waveInfo.Clear ();
	}
	
	void timeInit(){
		startTime = Time.realtimeSinceStartup;
	}

	// 次のwaveへ
	void NextWave(){
		waveState++;
		// 配列の初期化
		DataInit();
		// 次のテキストの読込
		LoadText();
		// タイマーのリセット
		timeInit();
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
