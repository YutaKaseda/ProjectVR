using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	[SerializeField]
	HPBar HPBar;

	public float HP{ get; private set; }
	
	void Awake(){
			HP = 100;
		   
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.Space)) {
			HP-=10;
			HPBar.Draw();
			}
	}
}
