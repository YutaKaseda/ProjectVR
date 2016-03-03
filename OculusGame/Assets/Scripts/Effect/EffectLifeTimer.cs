using UnityEngine;
using System.Collections;

public class EffectLifeTimer : MonoBehaviour {

    ParticleSystem particleSystem;

    public float lifeTime;

    void Awake(){
        particleSystem = GetComponent<ParticleSystem>();
        StartCoroutine("ParticleLife");
    }

    
    IEnumerator ParticleLife(){
        if (particleSystem.loop)
        {
            lifeTime += Time.deltaTime;
            while (lifeTime > 0)
            {
                lifeTime -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }

        }

        else
        {
            while (particleSystem.IsAlive())
            {
                yield return new WaitForSeconds(0.1f);
            }
        }

        Destroy(gameObject);

    }

    void OnDestroy(){

        Destroy(particleSystem);

    }
	
}
