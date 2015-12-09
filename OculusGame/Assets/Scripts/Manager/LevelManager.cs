using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class LevelManager : SingletonMonobehaviour<LevelManager> {

	// Use this for initialization
	void Awake () {

        DontDestroyOnLoad(gameObject);

        ResourcesManager.Instance.ResourcesLoadAllScene();

    }
}
