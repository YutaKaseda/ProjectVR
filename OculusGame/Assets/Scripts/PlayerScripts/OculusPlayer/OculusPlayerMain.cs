//<Summary>
//YutaKaseda
//2016/2/4
//2/17:ShotBulletに処理追加 by石田
//</Summary>

using UnityEngine;
using System.Collections;

public class OculusPlayerMain : MonoBehaviour {
	//OculusCamera
	[SerializeField]
	Camera oculusCamera;
	//FadeIn,FadeOutEffect
    [SerializeField]
	WarpEffect warpEffect;
    [SerializeField]
    EnemyData enemydata;

	//Use ShotBullet,Warp
    public Ray ray { private set; get; }
	//RayHitColliderChecking
	RaycastHit raycastHit;

	//WARP or DEAD 
	//Can't Move State
	enum e_PLAYER_STATE{
		WARP,
		DEAD,
		DEFAULT
	}

	e_PLAYER_STATE playerState;

	void Awake(){

		playerState = e_PLAYER_STATE.DEFAULT;
        OnlineLevel.Instance.VRDeviceEnabled();

	}

	void RayInit(){

		//Camera forward
		ray = new Ray(oculusCamera.transform.position,oculusCamera.transform.forward);
	
	}

	public void Main(){

		switch(playerState){
		case e_PLAYER_STATE.DEFAULT:

			if(Input.GetKey(KeyCode.A)){
				RayInit();
				ShotBullet();
			}
			
			if(Input.GetKeyDown(KeyCode.B)){
				RayInit();
				RayWarp();
			}

			break;

		case e_PLAYER_STATE.WARP:

			if(!warpEffect.activeWarp){
				gameObject.transform.position = raycastHit.collider.transform.position;
				playerState = e_PLAYER_STATE.DEFAULT;
			}

			break;

		case e_PLAYER_STATE.DEAD:

			break;
		}

	}

	void ShotBullet(){

        if (CheckHitRayWithTag(ray, "Enemy", 1.0f))
        {
            enemydata.Damage(1);
        }
            

	}

	void RayWarp(){
        if (CheckHitRayWithTag(ray, "Beacon", 2.0f)){
			warpEffect.FadeWhite();
			playerState = e_PLAYER_STATE.WARP;
		}
    }

	bool CheckHitRayWithTag(Ray checkRay,string checkTag,float rayRadius){

		if(Physics.SphereCast(ray,rayRadius,out raycastHit)){
			if(raycastHit.collider.tag == checkTag)
                return true;
		}

		return false;
	}
}
