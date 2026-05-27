using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVEBrain : NPC
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public GoalSelector Goal;
}
