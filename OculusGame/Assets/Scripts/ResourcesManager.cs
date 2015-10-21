using UnityEngine;
using System.Collections;

public class ResourcesManager : SingletonMonobehaviour<ResourcesManagerS> {



	class ResourcesInfo{
		public string resourcesName;
		public string name;
		public GameObject obj;

		ResourcesInfo(string resourcesName,string name){
			this.resourcesName = resourcesName;
			this.name = name;
		}
	}

	void Awake(){

		if()

	}

}
