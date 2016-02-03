using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fadeio : MonoBehaviour
{
    [SerializeField]
    BabelSelect becon;
	// Use this for initialization
    void Awake()
    {
        
        //becon = GameObject.Find("2DCamera").GetComponent<BabelSelect>();
    }

    public void WarpStart()
    {
        becon = GameObject.FindWithTag("Player3D").GetComponent<BabelSelect>();
        becon.Warp();
    }
}
