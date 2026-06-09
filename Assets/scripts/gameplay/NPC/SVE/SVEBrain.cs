using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVEBrain : NPC
{
    public PatrolGoal patrolGoal;
    public ChaseEnemyGoal chaseGoal;
    public ProceduralSVEGoal proceduralGoal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        patrolGoal.thisNPC = this;
        chaseGoal.thisNPC = this;
        proceduralGoal.thisNPC = this;
    }

    private void Start()
    {
        Goals.addGoal(1, chaseGoal);
        Goals.addGoal(2, proceduralGoal);
        Goals.addGoal(3, patrolGoal);
    }
}
