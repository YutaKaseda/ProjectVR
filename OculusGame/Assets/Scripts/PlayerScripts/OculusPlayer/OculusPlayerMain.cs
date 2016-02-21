//<Summary>
//YutaKaseda
//2016/2/4
//2/17:ShotBulletに処理追加 by石田
//2016/02/20 鈴木
//enemyDataNew 追加
//ShotBullet 処理追加
//</Summary>

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class OculusPlayerMain : MonoBehaviour {
	//OculusCamera
	[SerializeField]
	Camera oculusCamera;
	//FadeIn,FadeOutEffect
    [SerializeField]
	WarpEffect warpEffect;
	EnemyDataNew enemyDataNew;
    BossData bossData;

    [SerializeField]
    Transform effectpos;

    [SerializeField]
    Vector3 posRevision;

    [SerializeField]
    DroneControll droneControll;

    bool vulcanPlaySound;
    bool hitSound;

	//Use ShotBullet,Warp
    public Ray ray { private set; get; }
	//RayHitColliderChecking
	RaycastHit raycastHit;

	Animator vulcanKnockBackAnim;

    Vector3 posCorrection;
	//WARP or DEAD 
	//Can't Move State
	enum e_PLAYER_STATE{
		WARP,
        WARP_END,
		DEAD,
		DEFAULT
	}

	e_PLAYER_STATE playerState;

	void Awake(){

		playerState = e_PLAYER_STATE.DEFAULT;
        OnlineLevel.Instance.VRDeviceEnabled();
        droneControll = GameObject.FindWithTag("Beacon").GetComponent<DroneControll>();
		vulcanKnockBackAnim = GetComponent<Animator>();

        posCorrection = transform.position;
	}

	void RayInit(){

		//Camera forward
		ray = new Ray(oculusCamera.transform.position,oculusCamera.transform.forward);

	}

	public void Main(){

		switch(playerState){
		case e_PLAYER_STATE.DEFAULT:

                droneControll.DroneMain();
				vulcanKnockBackAnim.SetBool("shot",false);
                if (Input.GetButton("MaruP1") || Input.GetButton("ShikakuP1") || Input.GetButton("SankakuP1") || Input.GetButton("BatuP1")){
                    RayInit();
                    ShotBullet();
                    vulcanKnockBackAnim.SetBool("shot", true);
                    if (!vulcanPlaySound)
                    {
                        vulcanPlaySound = true;
                        SoundPlayer.Instance.PlaySoundEffect("Balkan2", 0.5f);
                        StartCoroutine(VulcanSoundInterval(0.1f));
                    }
                }
              
			
			
                if(Input.GetButton("R1P1") || Input.GetButton("R2P1") || Input.GetButton("L1P1") || Input.GetButton("L2P1")){
                    RayInit();
                    RayWarp();
                }

			break;

		case e_PLAYER_STATE.WARP:

			if(!warpEffect.activeWarp){
                droneControll.Init();
				transform.position = raycastHit.collider.transform.position;
                posCorrection = raycastHit.collider.transform.position;
                transform.rotation = raycastHit.collider.transform.rotation;
                droneControll = raycastHit.collider.GetComponent<DroneControll>();
                transform.parent = raycastHit.collider.transform;
                transform.localPosition += posRevision;
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
            hitSound = true;
			enemyDataNew = raycastHit.collider.gameObject.GetComponentInParent<EnemyDataNew>();
			enemyDataNew.EnemyDamage("NormalBullet");
        }
        else if (CheckHitRayWithTag(ray, "Boss", 1.0f))
        {
            hitSound = true;
            bossData = raycastHit.collider.gameObject.GetComponentInParent<BossData>();
            bossData.BossDamage("NormalBullet","3D");
        }
        else
        {
            hitSound = false;
        }
	}

	void RayWarp(){
        if (CheckHitRayWithTag(ray, "Beacon", 3.0f)){
			warpEffect.FadeWhite();
            SoundPlayer.Instance.PlaySoundEffect("warp", 1.0f);
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
    IEnumerator VulcanSoundInterval(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        vulcanPlaySound = false;
    }

    public void PosLoad()
    {
        transform.position = posCorrection;
        transform.localPosition += posRevision;
    }
}
