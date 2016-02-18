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

		GameObject playerObject = (GameObject)GameObject.Instantiate(spawnPrefabs[prefabNum], 
		                                                  GetStartPosition().position, 
		                                                  GetStartPosition().rotation);
        Debug.Log(GetStartPosition().position);
        Debug.Log(GetStartPosition().rotation);
        Debug.LogError("AddServer");
        
        prefabNum++;
        NetworkServer.Spawn(playerObject);
		NetworkServer.AddPlayerForConnection(conn, playerObject, playerControllerId);
        
	}

	public void Reset(){
		prefabNum = 0;
	}
}
