using UnityEngine;
using System.Collections;

public class WaveBase : MonoBehaviour {
	
	class WaveDate{
		string enemyName		{ get; set; }	// 呼び出す敵の名前	
		int delayTime			{ get; set; }	// 次までの待機時間

		public WaveDate(string en , int dt){enemyName = en;delayTime = dt;}
	}
	WaveDate enemy01 = new WaveDate ("enemy01",1);

	class Wavebase{



	}

	Wavebase Wave01;


	// Use this for initialization
	void Awake () {
		Wave01 = new Wavebase ("enemy01", 1);
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Wave01"+Wave01);
	}
}
