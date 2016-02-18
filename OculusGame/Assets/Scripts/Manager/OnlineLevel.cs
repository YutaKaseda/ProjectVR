using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class OnlineLevel : MonoBehaviour {


	public void VRDeviceEnabled(){

		VRSettings.enabled = true;
		InputTracking.Recenter();

	}
}
