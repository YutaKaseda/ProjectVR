using UnityEngine;
using System.Collections;

public class DroneControll : MonoBehaviour {

    Quaternion initDroneRotation;
    Vector3 moveRotation;

    [SerializeField]
    float moveSpeed;

    void Awake(){
        initDroneRotation = transform.rotation;
        moveSpeed = 0.08f;
    }

    public void Init(){
        transform.rotation = initDroneRotation;
    }

    public void DroneMain(){

        moveRotation = new Vector3(-Input.GetAxisRaw("VerticalP1"), Input.GetAxisRaw("HorizontalP1"), 0).normalized * moveSpeed;

        transform.eulerAngles += moveRotation;

    }
	
}
