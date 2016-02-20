using UnityEngine;
using System.Collections;

public class OfflineAvoid : MonoBehaviour {

    void Update(){

        if(Input.GetButtonDown("MaruP1") || Input.GetButtonDown("BatuP1") ||
            Input.GetButtonDown("ShikakuP1") || Input.GetButtonDown("SankakuP1"))
        {
            Application.LoadLevelAsync("OnlineLevel");
        }

    }
	
}
