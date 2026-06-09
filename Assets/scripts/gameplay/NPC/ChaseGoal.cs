using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChaseEnemyGoal : Goal
{
    public NPC thisNPC;
    public GameObject Enemy;
    public float threasholdBeforeAttack;

    public override bool canUse()
    {
        if(thisNPC.CheckVisionForEnemy(out Enemy) != new Vector3(0, -1000, 0) && Utilities.current.DistanceFrom(thisNPC.gameObject.transform.position, Enemy.transform.position) > threasholdBeforeAttack)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void update()
    {
        //gets placement to look towards
        Vector3 EnemyCenter = Enemy.transform.position;
        EnemyCenter.y = EnemyCenter.y + 0.5f;
        //get direction
        Vector3 direction = EnemyCenter - thisNPC.rb.position;

        //gets and sets rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion nextRotation = Quaternion.RotateTowards(thisNPC.rb.rotation, lookRotation, thisNPC.RotationSpeed * Time.fixedDeltaTime);
        thisNPC.rb.MoveRotation(nextRotation);

        //moves NPC
        Vector3 nextPosition = Vector3.MoveTowards(thisNPC.rb.position, Enemy.transform.position, thisNPC.WalkSpeed * Time.fixedDeltaTime);
        thisNPC.rb.MovePosition(nextPosition);
    }
}
