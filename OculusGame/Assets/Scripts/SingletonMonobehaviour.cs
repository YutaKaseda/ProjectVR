using UnityEngine;
using System.Collections;

public class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour{

    static T instance = null;

	void Awake(){

		if (instance != null){
			Destroy(this);
		}

	}

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }

            return instance;
        }
    }
}
