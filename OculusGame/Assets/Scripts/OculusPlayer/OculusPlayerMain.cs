//<Summary>
//YutaKaseda
//2016/2/4
//</Summary>

using UnityEngine;
using System.Collections;

public class OculusPlayerMain : MonoBehaviour {
	//OculusCamera
	[SerializeField]
	Camera oculusCamera;

	//Use ShotBullet,Warp
	Ray ray;
	//RayHitColliderChecking
	RaycastHit raycastHit;

	void Init(){

		//Camera forward
		ray = new Ray(oculusCamera.transform.position,oculusCamera.transform.forward);

	}

	public void Main(){

		if(Input.GetKeyDown(KeyCode.A)){
			ShotBullet();
		}

		if(Input.GetKeyDown(KeyCode.B)){
			RayWarp();
		}

	}

	void ShotBullet(){

		if(CheckHitRayWithTag(ray,"Enemy",1.0f));

	}

	void RayWarp(){

		if(CheckHitRayWithTag(ray,"Base",4,0f));

	}

	bool CheckHitRayWithTag(Ray checkRay,string checkTag,float rayRadius){

		Physics.Raycast()

	}

}
