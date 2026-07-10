using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (checkIfPlayer(other.gameObject))
        {
            other.GetComponent<PlayerHealth>().Life = 0;
            other.GetComponent<PlayerHealth>().health = 0;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    bool checkIfPlayer(GameObject checker)
    {
        if(checker.TryGetComponent<ThirdPersonMovement>(out ThirdPersonMovement empty))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
