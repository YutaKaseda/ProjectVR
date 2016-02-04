using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {

    void Awake()
    {
        Destroy(gameObject, 2);
    }
}
