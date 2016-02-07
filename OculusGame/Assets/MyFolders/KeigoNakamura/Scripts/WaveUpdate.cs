///////////////////////////////////////
/// 
/// 2016/02/07 中村圭吾
/// 各所のリファクタ(前回のバージョンでしか使わない変数などの削除,変数の名前の見直しなど)
/// 円状に敵を出現させるためのクラス制作
/// テキストの読込部の改変(円状に配置するのに必要な数値を読み込むように)
/// CreateOrder関数追加　連続して敵を出す際にテキストの分量を増やさなくてもよいようにしました
/// 
///////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WaveUpdate : MonoBehaviour {

	public static readonly string ENEMY_DATAEND	= "END";
	public static readonly string DATANULL		= "NULL";
	public static readonly string WAVE_BOSS		= "boss";
	public static readonly float  PAI			= 3.14f;

	[SerializeField] List<TextAsset> waveTextList = new List<TextAsset>();
	[SerializeField] EnemyFactory enemyFactory;
	[SerializeField] int initArrayBoxVar;				// 配列の初期個数100くらいに設定してください
	int waveProgress;									// Waveの進行数
	int arrayPosition;									// 配列の今の場所,敵生成時に使用
	float startTime;									// タイマーの開始時間
	float timeRap;										// 特定のタイミングの時間を記憶するときに使用
	[SerializeField] float stayTime;					// Waveが終わってどのくらい待つか
	string[] waveInfoArray;
	[SerializeField] List<string> waveInfo = new List<string>();
	public bool bossFlg = false;
	[SerializeField] int enemyPositionSpace;

	class BaseEnemyData{
		public string enemyName{ get; set; }			// 呼び出す敵の名前
		public float delayTime{ get; set; }				// 次までの待機時間
		public float pointX{ get; set; }				// 座標x
		public float pointY{ get; set; }				// 座標y
		public float pointZ{ get; set; }				// 座標z
		
		public BaseEnemyData(){enemyName = DATANULL;delayTime = -9999;pointX = 0;pointY = 0;pointZ = 0;}
	}
	
	class WosimWaveData : BaseEnemyData{
		public float degree{ get; set; }				// 角度
		public float radius{ get; set; }				// 半径

		public int enemySuccessin{ get; set; }			// 連続して出す敵の数
		public string enemyLineDirection{ get; set; }	// 連続出現する場合の連なる方向
		// 'N':特に連続して出さない場合'U':上方向にのびていく'D':下方向にのびていく'L':左方向にのびていく'R':右方向にのびていく
		// 'UL':左上方向にのびていく'UR':右上方向にのびていく'DL':左下方向にのびていく'DR':右下方向にのびていく

		public WosimWaveData(){degree = 0;radius = 0; enemySuccessin = 0;enemyLineDirection = "N";}

	}

	//EnemyData[] waveData;
	WosimWaveData[] waveData;

	void Awake () {
		waveTextList.Add(null);
		//enemyFactory = GameObject.Find ("EnemyFactory").GetComponent<EnemyFactory> ();
		waveProgress = 0;

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
	void DataInit(){
		
		// 配列の作成
		waveData = new WosimWaveData[initArrayBoxVar];
		
		// クラスの初期化
		for (int i = 0; i < initArrayBoxVar; i++) {
			waveData[i] = new WosimWaveData();
		}
		
		// 配列の位置
		arrayPosition = 0;
		waveInfo.Clear ();
	}

	void LoadText (){
		
		// 読み込むwaveの情報のテキストを取得
		// waveが進む際にも呼ばれるため読み込むテキストの変更も
		//waveText = Resources.Load ("Texts/wave" + waveProgress) as TextAsset;
		if (waveTextList [waveProgress] == null) {
			// ゲーム終了
			Debug.LogError ("TextNull");
			this.gameObject.SetActive(false);
			return;
		}
		waveInfoArray = waveTextList [waveProgress].text.Split ('\n');
		for (int i = 0; i < waveInfoArray.Length; i++) {
			waveInfo.Add (waveInfoArray [i]);
		}
		StartCoroutine ("ArrayWhile");
		ReadClassValueSelect();

	}

	// そのゲームによってwaveに必要な情報が違ってくるため
	// 格納する場所と入れる物を変更する
	// 今回は敵の名前,出現時間,角度,半径,高さ,出現数,線の方向(連番時)
	void ReadClassValueSelect(){
		string[] eachInfo;
		for (int i = 0; i < waveInfo.Count; i++) {
			
			eachInfo = waveInfo [i].Split ("," [0]);
			waveData [i].enemyName			= (eachInfo [0]);
			waveData [i].delayTime			= (float.Parse (eachInfo [1]));
			waveData [i].degree				= (float.Parse (eachInfo [2]));
			waveData [i].radius				= (float.Parse (eachInfo [3]));
			waveData [i].pointY				= (float.Parse (eachInfo [4]));
			waveData [i].enemySuccessin		= (int.Parse (eachInfo [5]));
			waveData [i].enemyLineDirection	= (eachInfo [6]);
			if (waveData [i].enemyName == ENEMY_DATAEND) {
				System.Array.Resize (ref waveData, (i + 1));
				break;
			}
		}
	}

	public void Wave(){

		if (!waveData [arrayPosition].enemyName.Contains(DATANULL) &&
			!waveData [arrayPosition].enemyName.Contains(ENEMY_DATAEND) &&
		    bossFlg == false) {

			if (waveData [arrayPosition].delayTime <= (Time.realtimeSinceStartup - startTime)) {
				// 敵の発生
				CreateOrder();

				if(waveData[arrayPosition].enemyName.Contains(WAVE_BOSS)){
					bossFlg = true;
				}
				arrayPosition++;
			} else {
				timeRap = Time.realtimeSinceStartup - startTime;
			}

		} else if(bossFlg == true) {

		}else {

			if(Time.realtimeSinceStartup - startTime >= timeRap + stayTime){
				NextWave();
			}
		}
	}

	void CreateOrder(){
		Vector3 pos;
		float positionSpace = enemyPositionSpace;
		pos.x = waveData[arrayPosition].radius * Mathf.Cos (PAI/180 * waveData[arrayPosition].degree);
		pos.y = waveData [arrayPosition].pointY;
		pos.z = waveData[arrayPosition].radius * Mathf.Sin (PAI/180 * waveData[arrayPosition].degree);

		for (int createNumber = 0;createNumber < waveData[arrayPosition].enemySuccessin;createNumber++){
			enemyFactory.Create (waveData [arrayPosition].enemyName,pos);


			switch(waveData[arrayPosition].enemyLineDirection){
			case "U":
				pos.y += enemyPositionSpace;
				break;
			case "D":
				pos.y -= enemyPositionSpace;
				break;
			case "L":
				pos.x = waveData[arrayPosition].radius * Mathf.Cos (PAI/180 * (waveData[arrayPosition].degree+positionSpace));
				pos.z = waveData[arrayPosition].radius * Mathf.Sin (PAI/180 * (waveData[arrayPosition].degree+positionSpace));
				break;
			case "R":
				pos.x = waveData[arrayPosition].radius * Mathf.Cos (PAI/180 * (waveData[arrayPosition].degree-positionSpace));
				pos.z = waveData[arrayPosition].radius * Mathf.Sin (PAI/180 * (waveData[arrayPosition].degree-positionSpace));
				break;
			case "UL":
				pos.x = waveData[arrayPosition].radius * Mathf.Cos (PAI/180 * (waveData[arrayPosition].degree+positionSpace));
				pos.y += enemyPositionSpace;
				pos.z = waveData[arrayPosition].radius * Mathf.Sin (PAI/180 * (waveData[arrayPosition].degree+positionSpace));
				break;
			case "UR":
				pos.x = waveData[arrayPosition].radius * Mathf.Cos (PAI/180 * (waveData[arrayPosition].degree-positionSpace));
				pos.y += enemyPositionSpace;
				pos.z = waveData[arrayPosition].radius * Mathf.Sin (PAI/180 * (waveData[arrayPosition].degree-positionSpace));
				break;
			case "DL":
				pos.x = waveData[arrayPosition].radius * Mathf.Cos (PAI/180 * (waveData[arrayPosition].degree+positionSpace));
				pos.y -= enemyPositionSpace;
				pos.z = waveData[arrayPosition].radius * Mathf.Sin (PAI/180 * (waveData[arrayPosition].degree+positionSpace));
				break;
			case "DR":
				pos.x = waveData[arrayPosition].radius * Mathf.Cos (PAI/180 * (waveData[arrayPosition].degree-positionSpace));
				pos.y -= enemyPositionSpace;
				pos.z = waveData[arrayPosition].radius * Mathf.Sin (PAI/180 * (waveData[arrayPosition].degree-positionSpace));
				break;
			}
			positionSpace += enemyPositionSpace;
		}
	}

	void timeInit(){
		startTime = Time.realtimeSinceStartup;
	}

	// 次のwaveへ
	void NextWave(){
		waveProgress++;
		// 配列の初期化
		DataInit();
		// 次のテキストの読込
		LoadText();
		// タイマーのリセット
		timeInit();
	}
	IEnumerator ArrayWhile(){
		int arrayInt = 0;
		while(!waveInfo[arrayInt].StartsWith("END")) {
			if (waveInfo [arrayInt].StartsWith ("#")) {
				waveInfo.RemoveAt (arrayInt);
				arrayInt = 0;
			}else{
				arrayInt++;
			}
			if(waveInfo[arrayInt].StartsWith("END")){
				break;
			}
		}

		yield return null;
	}
}
