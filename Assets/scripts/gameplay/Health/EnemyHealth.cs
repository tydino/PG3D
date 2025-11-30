using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public int Delay = 1; //in seconds
    public GameObject thisObj;

    public void Update()
    {
        if(health <= 0)
        {
            Destroy(thisObj, Delay);
        }
    }
}
