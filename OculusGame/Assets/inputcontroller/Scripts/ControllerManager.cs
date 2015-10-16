using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour {

	Controll controller1P, controller2P;
	class Controll{
		public float horizon 		{ get; set; }	
		public float vertical		{ get; set; }
		public bool maru 			{ get; set; }
		public bool batu			{ get; set; }
		public bool sankaku			{ get; set; }
		public bool shikaku			{ get; set; }
		public bool R1				{ get; set; }
		public bool R2				{ get; set; }
		public bool R3				{ get; set; }
		public bool L1				{ get; set; }
		public bool L2				{ get; set; }
		public bool L3				{ get; set; }
		public bool start			{ get; set; }
		public bool select			{ get; set; }

		public Controll(){
			horizon = 0f;
			vertical = 0f;
			maru = false;
			batu = false;
			sankaku = false;
			shikaku = false;
			R1 = false;
			R2 = false;
			R3 = false;
			L1 = false;
			L2 = false;
			L3 = false;
			start = false;
			select = false;
		}

		//ゲッター
		public float GetAxis(string axis){

			switch (axis) {
			case "horizon":
				return horizon;
			case "vertical":
				return vertical;
			}
			return 0f;
		}

		//ゲッター
		public bool GetButton(string button){

			switch (button) {
			case "maru":
				return maru;
			case "batu":
				return batu;
			case "sankaku":
				return sankaku;
			case "shikaku":
				return shikaku;
			case "R1":
				return R1;
			case "R2":
				return R2;
			case "R3":
				return R3;
			case "L1":
				return L1;
			case "L2":
				return L2;
			case "L3":
				return L3;
			case "start":
				return start;
			case "select":
				return select;

			}
			return false;
		}
	
	};
	
	void Awake(){
		controller1P = new Controll();
		controller2P = new Controll();
	}

	void Update(){
		ControllButton ();
		GetControllButton ("maru", 1);
		GetControllButton ("batu", 1);
		GetControllAxis ("horizon",1);
		GetControllAxis ("vertical",1);
	}



	// 外部からボタンの状態を見る
	// GetControllButton("調べたいボタンの名前" , プレイヤーの番号 ※1 or 2 );

	public bool GetControllButton(string key , int player){

		if (player == 1) {
			controller1P.GetButton(key);
			Debug.Log ("Plaer1 Key  "+key +" " + controller1P.GetButton(key));
			return controller1P.GetButton(key);
		}
		if (player == 2) {
			controller2P.GetButton (key);
			Debug.Log ("Plaer2 Key  "+key +" "  + controller2P.GetButton (key));
			return controller2P.GetButton(key);
		}
	
		return false;
	}

	// 外部からAxisをみる
	// GetControllAxis("",プレイヤーの番号 ※1 or 2)
	public float GetControllAxis(string key , int player){

		if (player == 1) {
			controller1P.GetAxis(key);
			Debug.Log ("Plaer1 Key  " + controller1P.GetAxis(key));
			return controller1P.GetAxis(key);
		}
		if (player == 2) {
			controller2P.GetAxis (key);
			Debug.Log ("Plaer2 Key  " + controller2P.GetAxis (key));
			return controller2P.GetAxis(key);
		}

		return 0f;
		
	}



	void ControllButton(){

		controller1P.horizon = Input.GetAxis ("HorizontalP1");
		//Debug.Log ("HorizonP1 " + controller1P.horizon);
		controller2P.horizon = Input.GetAxis ("HorizontalP2");
		//Debug.Log ("HorizonP2 " + controller2P.horizon);
		
		controller1P.vertical = Input.GetAxis ("VerticalP1");
		//Debug.Log ("VerticalP1 " + controller1P.vertical);
		controller2P.vertical = Input.GetAxis ("VerticalP2");
		//Debug.Log ("VerticalP2 " + controller2P.vertical);
		
		// ○
		if (Input.GetButtonDown ("MaruP1")) {
			// Debug.Log ("MaruP1");
			controller1P.maru = true;
		} else
			controller1P.maru = false;

		if (Input.GetButtonDown ("MaruP2")) {
			// Debug.Log ("MaruP2");
			controller2P.maru = true;
		} else
			controller2P.maru = false;
		
		// ×
		if (Input.GetButtonDown ("BatuP1")) {
			// Debug.Log ("BatuP1");
			controller1P.batu = true;
		} else
			controller1P.batu = false;

		if (Input.GetButtonDown ("BatuP2")) {
			// Debug.Log ("BatuP1");
			controller2P.batu = true;
		} else
			controller2P.batu = false;
		
		// △
		if (Input.GetButtonDown ("SankakuP1")) {
			// Debug.Log ("SankakuP1");
			controller1P.sankaku = true;
		} else
			controller1P.sankaku = false;

		if (Input.GetButtonDown ("SankakuP2")) {
			// Debug.Log ("SankakuP2");
			controller2P.sankaku = true;
		} else
			controller2P.sankaku = false;
		
		// □
		if (Input.GetButtonDown ("ShikakuP1")) {
			// Debug.Log ("ShikakuP1");
			controller1P.shikaku = true;
		} else
			controller1P.shikaku = false;

		if (Input.GetButtonDown ("ShikakuP2")) {
			// Debug.Log ("ShikakuP2");
			controller2P.shikaku = true;
		} else
			controller2P.shikaku = false;
		
		// R1
		if (Input.GetButtonDown ("R1P1")) {
			// Debug.Log ("R1P1");
			controller1P.R1 = true;
		} else
			controller1P.R1 = false;

		if (Input.GetButtonDown ("R1P2")) {
			// Debug.Log ("R1P2");
			controller2P.R1 = true;
		} else
			controller2P.R1 = false;
		
		// R2
		if (Input.GetButtonDown ("R2P1")) {
			// Debug.Log ("R2P1");
			controller1P.R2 = true;
		} else
			controller1P.R2 = false;

		if (Input.GetButtonDown ("R2P2")) {
			// Debug.Log ("R2P2");
			controller2P.R2 = true;
		} else
			controller2P.R2 = false;
		
		// R3
		if (Input.GetButtonDown ("R3P1")) {
			// Debug.Log ("R3P1");
			controller1P.R3 = true;
		} else
			controller1P.R3 = false;

		if (Input.GetButtonDown ("R3P2")) {
			// Debug.Log ("R3P2");
			controller2P.R3 = true;
		} else
			controller2P.R3 = false;
		
		// L1
		if (Input.GetButtonDown ("L1P1")) {
			// Debug.Log ("L1P1");
			controller1P.L1 = true;
		} else
			controller1P.L1 = false;

		if (Input.GetButtonDown ("L1P2")) {
			// Debug.Log ("L1P2");
			controller2P.L1 = true;
		} else
			controller2P.L1 = false;
		
		// L2
		if (Input.GetButtonDown ("L2P1")) {
			// Debug.Log ("L2P1");
			controller1P.L2 = true;
		} else
			controller1P.L2 = false;

		if (Input.GetButtonDown ("L2P2")) {
			// Debug.Log ("L2P2");
			controller2P.L2 = true;
		} else
			controller2P.L2 = false;
		
		// L3
		if (Input.GetButtonDown ("L3P1")) {
			// Debug.Log ("L3P1");
			controller1P.L3 = true;
		} else
			controller1P.L3 = false;

		if (Input.GetButtonDown ("L3P2")) {
			// Debug.Log ("L3P2");
			controller2P.L3 = true;
		} else
			controller2P.L3 = false;
		
		// start
		if (Input.GetButtonDown ("StartP1")) {
			// Debug.Log ("StartP1");
			controller1P.start = true;
		} else
			controller1P.start = false;

		if (Input.GetButtonDown ("StartP2")) {
			// Debug.Log ("StartP2");
			controller2P.start = true;
		} else
			controller2P.start = false;
		
		// Select
		if (Input.GetButtonDown ("SelectP1")) {
			// Debug.Log ("SelectP1");
			controller1P.select = true;
		} else
			controller1P.select = false;

		if (Input.GetButtonDown ("SelectP2")) {
			//Debug.Log ("SelectP2");
			controller2P.select = true;
		} else
			controller2P.select = false;
	}


}
