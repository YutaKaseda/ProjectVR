using UnityEngine;
using System.Collections;

public class DroneControll : MonoBehaviour {

    Quaternion initDroneRotation;
    Vector3 moveRotation;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    GameObject warpEffect;
    void Awake(){
        initDroneRotation = transform.rotation;
        moveSpeed = 0.2f;
        
    }

    public void Init(){
        transform.rotation = initDroneRotation;
        Release();
    }

    public void DroneMain(){

        moveRotation = new Vector3(-Input.GetAxisRaw("VerticalP1"), Input.GetAxisRaw("HorizontalP1"), 0).normalized * moveSpeed;

        transform.eulerAngles += moveRotation;

    }

    public void Warping()
    {
        warpEffect.SetActive(false);
    }

    public void Release()
    {
        warpEffect.SetActive(true);
    }
	
}
