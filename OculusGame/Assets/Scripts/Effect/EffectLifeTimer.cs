using UnityEngine;
using System.Collections;

public class EffectLifeTimer : MonoBehaviour {

    ParticleSystem particleSystem;

    void Awake(){
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update(){
        if (!particleSystem.IsAlive()){
            Destroy(gameObject);
        }
    }

    void OnDestroy(){

        Destroy(particleSystem);

    }
	
}
