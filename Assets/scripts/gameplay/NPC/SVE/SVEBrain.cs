using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVEBrain : MonoBehaviour
{
    Rigidbody rb;
    bool canWalk()
    {
        return false;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (canWalk())
        {
            rb.AddForce(transform.forward * 5f, ForceMode.VelocityChange);
        }
    }
}
