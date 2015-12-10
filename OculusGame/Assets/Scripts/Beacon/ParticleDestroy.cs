using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {

    [SerializeField]
    int destroyCnt;

    void Awake()
    {
        Destroy(gameObject, destroyCnt);
    }
}
