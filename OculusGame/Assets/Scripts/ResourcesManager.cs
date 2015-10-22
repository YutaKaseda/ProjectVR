using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Serialize;

public class ResourcesManager : SingletonMonobehaviour<ResourcesManager> {

	[SerializeField]
	Dictionary<string,GameObject> resourcesDictionary = new Dictionary<string, GameObject>();

	[SerializeField]
	GameObject prefabResources;
	[SerializeField]
	GameObject textureResources;
	[SerializeField]
	GameObject materialResources;

	void Awake(){
		resourcesDictionary.Add("Prefab",prefabResources);
		resourcesDictionary.Add("Texture",textureResources);
		resourcesDictionary.Add("Material",materialResources);

		var obj = Instantiate(prefabResources);
		obj.transform.parent = transform;

		obj = Instantiate(textureResources);
		obj.transform.parent = transform;

		obj = Instantiate(materialResources);
		obj.transform.parent = transform;
	}

	public GameObject GetResource(string resourceStuckName,string resourceName){

		switch(resourceStuckName){
		case "Prefab":

			return resourcesDictionary[resourceStuckName].GetComponent<PrefabResources>().IResourcesList(resourceName);

			break;
		default:
			break;
		}

		return null;
	}
}
