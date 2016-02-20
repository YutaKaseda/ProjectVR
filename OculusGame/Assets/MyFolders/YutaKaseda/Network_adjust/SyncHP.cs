using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncHP : NetworkBehaviour
{

    private int health = 400;

    void update()
    {
        Debug.Log(health);
    }

    public void DeductHealth(int dmg)
    {
        health -= dmg;
        CheckHealth();
    }

    void CheckHealth()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}