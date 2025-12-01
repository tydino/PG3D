using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUpOnHit : MonoBehaviour
{
    public GameObject thisObj;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Lifes life = other.gameObject.GetComponent<Lifes>();
            life.Life++;
            Destroy(thisObj);
        }
    }
}
