using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class OnlineLevel : SingletonMonobehaviour<OnlineLevel> {


	public void VRDeviceEnabled(){

  
		VRSettings.enabled = true;
		InputTracking.Recenter();

	}
}
