using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingletonMonobehaviour<GameManager> {

	[SerializeField]
	List<GameObject> initializeObjects;

	void Awake(){

        //シーン更新時に削除されたらゲーム止まるので
        DontDestroyOnLoad(gameObject);

		foreach(GameObject prefab in initializeObjects){
			var obj = Instantiate(prefab) as GameObject;
			obj.transform.parent = transform;
		}
	}
}
