//<Summary>
//YutaKaseda
//2016/2/4
//</Summary>

using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class OculusPlayerMain : MonoBehaviour {
	//OculusCamera
	[SerializeField]
	Camera oculusCamera;

	//Use ShotBullet,Warp
	Ray ray;
	//RayHitColliderChecking
	RaycastHit raycastHit;

	void RayInit(){

		//Camera forward
		ray = new Ray(oculusCamera.transform.position,oculusCamera.transform.forward);
	}

	public void Update(){

		if(Input.GetKey(KeyCode.A)){
            RayInit();
			ShotBullet();
		}

		if(Input.GetKeyDown(KeyCode.B)){
            RayInit();
			RayWarp();
		}

	}

	void ShotBullet(){

        if (CheckHitRayWithTag(ray, "Enemy", 1.0f)) ;


	}

	void RayWarp(){
        if (CheckHitRayWithTag(ray, "Beacon", 20.0f))
            gameObject.transform.position = raycastHit.collider.transform.position;
    }

	bool CheckHitRayWithTag(Ray checkRay,string checkTag,float rayRadius){

		if(Physics.SphereCast(ray,rayRadius,out raycastHit)){
			if(raycastHit.collider.tag == checkTag)
                return true;
		}

		return false;
	}
}
