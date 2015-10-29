using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesManager : SingletonMonobehaviour<ResourcesManager> {
	
	GameObject[] resourcesStuck;

	Dictionary<string,ResourceInfo> allSceneResources;
	Dictionary<string,ResourceInfo> sceneResources;

	class ResourceInfo{
		public string resourcesName;
		public GameObject resource;

		public ResourceInfo(string name,GameObject resource){
			resourcesName = name;
			this.resource = resource;
		}
	}
	
	void Awake(){
		allSceneResources = new Dictionary<string, ResourceInfo>();
		sceneResources = new Dictionary<string, ResourceInfo>();
	}

	void ResourcesLoadAllScene(){
		Debug.Log ("ResourcesLoadAllScene");

		resourcesStuck = Resources.LoadAll<GameObject>("prefabs/AllScene");

		foreach(var obj in resourcesStuck){

			allSceneResources.Add (obj.name,new ResourceInfo(obj.name,obj));

			Debug.Log ("Progress : AllScene.Resource->" + obj.name + " is Complete");

		}
		resourcesStuck = null;
	}

	public void ResourcesLoadScene(string sceneName){

		sceneResources.Clear();

		Debug.Log ("resourcesloadscene");

		if(allSceneResources.Count == 0)
			ResourcesLoadAllScene ();

		resourcesStuck = Resources.LoadAll<GameObject>(sceneName);
		foreach(var obj in resourcesStuck){
			sceneResources.Add (obj.name,new ResourceInfo("prefabs/" + obj.name,obj));
			Debug.Log ("Progress : " + sceneName +".Resource->" + obj.name + " is Complete");
		}

		resourcesStuck = null;
	}

	public GameObject GetResourceAllScene(string key){
		if(allSceneResources.ContainsKey(key))
			return allSceneResources[key].resource;
		else
			Debug.LogError(key + " is nothing");

		return null;

	}

	public GameObject GetResourceScene(string key){
		if(sceneResources.ContainsKey(key))
			return allSceneResources[key].resource;
		else
			Debug.LogError(key + " is nothing");

		return null;

	}

	public void ResourcesUnLoadAll(){
		sceneResources = null;
		allSceneResources = null;
		resourcesStuck = null;
		Destroy (gameObject);
	}
}
