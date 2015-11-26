using UnityEngine;
using System.Collections;


public class PlayerData : MonoBehaviour {

	[SerializeField]
	OverHeat overheat;



	public float CannonGage{ get; private set; }
	public float BomGage{ get; private set; }


	bool[] Gageflg = new bool[2] {
	 true,true};



	void Awake(){
		CannonGage = 0;
		BomGage = 0;
	
	}

	void Update(){
		if (Input.GetKey (KeyCode.Z) && Gageflg [0] == true) {
			CannonGage += 0.1f;
			if (CannonGage >= 100) {
				Gageflg [0] = false;
			}
		} else {
			CannonGage -= 0.5f;
			if (CannonGage <= 0) {
				CannonGage = 0;
				Gageflg [0] = true;
			}
		}

		if (Input.GetKey (KeyCode.X) && Gageflg[1] == true) {
			BomGage = 100;
			Gageflg[1] = false;
		} else {
			BomGage -= 0.3f;
			if (BomGage <= 0) {
				BomGage = 0;
				Gageflg[1]= true;
			}
		}
		overheat.Draw ();

		}
}
			
			
		