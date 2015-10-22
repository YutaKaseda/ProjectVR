using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class PrefabResources : SingletonMonobehaviour<PrefabResources>{

	[SerializeField]
	List<GameObject> inspecterList;

	Dictionary<string,PrefabInfo> prefabs = new Dictionary<string,PrefabInfo>();

	class PrefabInfo{
		public string resourceName;
		public string name;
		public GameObject prefab;

		public PrefabInfo(string resourceName,string name){
			this.resourceName = resourceName;
			this.name = name;
		}
	}

	//
	void Awake(){

		int cnt = 1;

		foreach(GameObject prefab in inspecterList){
			var obj = prefab;
			Debug.Log (obj.name);
			prefabs.Add ("prefab" + cnt,new PrefabInfo(prefab.name,prefab.name));
			cnt++;
		}
		inspecterList = null;
	}

	public void Check(){

		Debug.Log (prefabs.Count);

	}

	public void ResourcesLoadAll(){

		List<string> keyList = new List<string>(prefabs.Keys);

		foreach(string key in keyList){
			prefabs[key].prefab = Resources.Load("Prefabs/" + prefabs[key].resourceName) as GameObject;
		}
	}

	public GameObject IResourcesList(string key){
		if(!prefabs.ContainsKey(key))
			Debug.Log("error!!!");
		return prefabs[key].prefab;
	}

}
