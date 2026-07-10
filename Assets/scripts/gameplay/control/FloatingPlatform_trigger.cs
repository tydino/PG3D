using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform_trigger : MonoBehaviour
{
    public FloatingPlatform reportsTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            reportsTo.IsParented = true;
            Utilities.current.ParentObjectToAnotherObject(other.gameObject, reportsTo.parentsPlayerToThisObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            reportsTo.IsParented = false;
            Utilities.current.RemoveObjectFromParent(other.gameObject);
        }
    }
}
