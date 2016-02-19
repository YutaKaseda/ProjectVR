//<Summary>
//YutaKaseda
//16/2/17
//</Summary>

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class OverrideNetworkManager : NetworkManager {
	
	int prefabNum = 0;

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {

        if (spawnPrefabs[prefabNum].tag == "Player2D")
            OnlineLevel.Instance.player2DConnected = true;

		GameObject playerObject = (GameObject)GameObject.Instantiate(spawnPrefabs[prefabNum], 
		                                                  GetStartPosition().position, 
		                                                  GetStartPosition().rotation);
        
        prefabNum++;
		NetworkServer.AddPlayerForConnection(conn, playerObject, playerControllerId);
        
	}

	public void Reset(){
		prefabNum = 0;
	}
}
