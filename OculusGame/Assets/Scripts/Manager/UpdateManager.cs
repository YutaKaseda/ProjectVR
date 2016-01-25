using UnityEngine;
using System.Collections;

public class UpdateManager : MonoBehaviour {
	public Player3dMove player3dMove;
	[SerializeField]
	Player2D player2dMove;
	[SerializeField]
	Beacon beacon;

	// Use this for initialization
	void Awake () {
		player2dMove = GameObject.Find ("Player2D").GetComponent<Player2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(beacon.baseBeacon == true)
		player3dMove.Player3DMove ();

		player2dMove.Move();

	}
}
