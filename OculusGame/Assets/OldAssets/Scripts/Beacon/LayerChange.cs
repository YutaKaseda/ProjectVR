using UnityEngine;
using System.Collections;

public class LayerChange : MonoBehaviour {

	void Start () {}

    void OnTriggerEnter(Collider col){
        Debug.Log(col.gameObject.tag + "TriggerEnter");
        if (col.gameObject.tag == "UseBeacon"){
            GameObject.Find("UseBeacon").layer = LayerMask.NameToLayer("UseBeacon");
            GameObject.Find("UseRing").layer = LayerMask.NameToLayer("UseBeacon");
        }
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.tag == "UseBeacon"){
            GameObject.Find("UseBeacon").layer = LayerMask.NameToLayer("Default");
            GameObject.Find("UseRing").layer = LayerMask.NameToLayer("Default");
        }
    }
}
