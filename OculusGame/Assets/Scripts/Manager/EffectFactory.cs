using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectFactory : SingletonMonobehaviour<EffectFactory> {

	public void Create(string effectName,Vector3 instTransform,Quaternion instRotation){

		GameObject effResource = ResourcesManager.Instance.GetResourceScene(effectName);

		effResource = Instantiate(effResource,instTransform,instRotation) as GameObject;
		//effResource.AddComponent<EffectLifeTimer>();
	}

}
