using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVEBrain : NPC
{
    public PatrolGoal patrolGoal;
    public ChaseEnemyGoal chaseGoal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        patrolGoal.thisNPC = this;
        chaseGoal.thisNPC = this;
    }

    private void Start()
    {
        Goals.addGoal(1, chaseGoal);
        Goals.addGoal(2, patrolGoal);
    }
}
