using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSyncRotation : NetworkBehaviour {

	[SyncVar]	Quaternion	syncPlayerRotation;
	[SyncVar]	Quaternion	syncCamRotation;

	[SerializeField]	Transform	playerTransform;
	[SerializeField]	Transform	camTransform;
	[SerializeField]	float		lerpTime;

	Quaternion	lastPlayerRot;
	Quaternion	lastCamRot;
	float	threshold;

	void Awake () {
		lerpTime	=	15;
		threshold	=	5;
	}
	
	void Update(){

		LerpRotations();

	}

	void FixedUpdate () {

		TransmitRotations();
	}

	void LerpRotations(){

		if(! isLocalPlayer){

			playerTransform.rotation	=	Quaternion.Lerp(playerTransform.rotation,syncPlayerRotation,
			                                           Time.deltaTime * lerpTime);

			camTransform.rotation		=	Quaternion.Lerp(camTransform.rotation,syncCamRotation,
			                                          Time.deltaTime * lerpTime);
		}
	}

	[Command]
	void CmdProvideRotationsToServer(Quaternion playerRot,Quaternion camRot){

		syncPlayerRotation	=	playerRot;
		syncCamRotation		=	camRot;

	}

	[Client]
	void TransmitRotations(){

		if(isLocalPlayer	&&
		   Quaternion.Angle(playerTransform.rotation,lastPlayerRot)	>	threshold	&&
		   Quaternion.Angle(camTransform.rotation	,lastCamRot)	>	threshold){

			CmdProvideRotationsToServer(playerTransform.rotation,camTransform.rotation);

			lastPlayerRot	=	playerTransform.rotation;
			lastCamRot		=	camTransform.rotation;
		
		}

	}
}
