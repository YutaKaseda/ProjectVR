using UnityEngine;
using System.Collections;

public class UpdateManager : MonoBehaviour {
	[SerializeField]
	GameObject player3dMove;
	[SerializeField]
	GameObject player2dMove;




	// Use this for initialization
	void Awake () {
		player3dMove = GameObject.Find ("Player3D");
		player2dMove = GameObject.Find ("Player2D");


	}
	
	// Update is called once per frame
	void Update () {
		player3dMove.GetComponent<Player3dMove> ().Player3DMove ();
		player2dMove.GetComponent<Player2D> ().Move ();




	
	}
}
