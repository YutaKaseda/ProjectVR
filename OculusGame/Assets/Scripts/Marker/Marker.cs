using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

    Canvas canvas;

    void Awake()
    {
        canvas = GameObject.Find("MarkerCanvas").GetComponent<Canvas>();
    }

    public void TargetMarker(Vector3 markerPos)
    {
        //Debug.Log(markerPos);
        canvas.transform.position = new Vector3(markerPos.x, markerPos.y, canvas.transform.position.z);
    }
}
