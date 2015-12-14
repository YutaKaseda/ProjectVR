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

        DontDestroyOnLoad(gameObject);

		allSceneResources = new Dictionary<string, ResourceInfo>();
		sceneResources = new Dictionary<string, ResourceInfo>();
	}

	public void ResourcesLoadAllScene(){
		
		resourcesStuck = Resources.LoadAll<GameObject>("prefabs/AllScene");

		foreach(var obj in resourcesStuck){

			allSceneResources.Add (obj.name,new ResourceInfo(obj.name,obj));

		}
		resourcesStuck = null;
	}

	public void ResourcesLoadScene(string sceneName){

		sceneResources.Clear();

		if(allSceneResources.Count == 0)
			ResourcesLoadAllScene ();

		resourcesStuck = Resources.LoadAll<GameObject>("prefabs/" + sceneName);
		foreach(var obj in resourcesStuck){
			sceneResources.Add (obj.name,new ResourceInfo("prefabs/" + obj.name,obj));
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
			return sceneResources[key].resource;
		else
			Debug.LogError(key + " is nothing");

		return null;

	}

    public void ResourcesUnLoadAll(){

        StartCoroutine(UnLoadSceneAll());

    }

	public void ResourcesUnLoadScene(){

        StartCoroutine(UnLoadScene());

	}

    //シーン特有のリソースの削除
    IEnumerator UnLoadScene()
    {
        foreach(KeyValuePair<string,ResourceInfo> pair in sceneResources){
            Resources.UnloadAsset(pair.Value.resource);
            yield return null;
        }
    }

    //ゲーム全体で使用するリソースの削除、主にゲーム終了時に使うからシーンリソースも削除
    IEnumerator UnLoadSceneAll()
    {
        foreach (KeyValuePair<string, ResourceInfo> pair in allSceneResources)
        {
            Resources.UnloadAsset(pair.Value.resource);
            yield return null;
        }
        StartCoroutine(UnLoadScene());
    }

}
