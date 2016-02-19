using UnityEngine;
using System.Collections;

public class MainInterface : MonoBehaviour {

    [SerializeField]
    Player2D player2DMain;

    [SerializeField]
    OculusPlayerMain oculusPlayerMain;

    public void IMain(){

        if (player2DMain)
            player2DMain.Main();

        if (oculusPlayerMain)
            oculusPlayerMain.Main();

    }
	
}
