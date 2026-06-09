using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProceduralSVEGoal : Goal
{
    public SVEBrain thisNPC;

    public override bool canUse()
    {
        if (Utilities.current.DistanceFromList(thisNPC.patrolGoal.positionsToGoBetween, thisNPC.gameObject.transform.position) >= thisNPC.patrolGoal.threasholdForCloseToPatrolTarget && thisNPC.CheckVisionForEnemy(out GameObject None) == new Vector3(0, -1000, 0))
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
        Vector3 closestPatrolPoint = thisNPC.patrolGoal.positionsToGoBetween[Utilities.current.ClosestDistanceFromListToInt(thisNPC.patrolGoal.positionsToGoBetween, thisNPC.gameObject.transform.position)];
        thisNPC.CheckVisionForObstacle();

        //get direction
        Vector3 direction = closestPatrolPoint - thisNPC.rb.position;

        //gets and sets rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion nextRotation = Quaternion.RotateTowards(thisNPC.rb.rotation, lookRotation, thisNPC.RotationSpeed * Time.fixedDeltaTime);
        thisNPC.rb.MoveRotation(nextRotation);

        //moves NPC
        Vector3 nextPosition = Vector3.MoveTowards(thisNPC.rb.position, closestPatrolPoint, thisNPC.WalkSpeed * Time.fixedDeltaTime);
        thisNPC.rb.MovePosition(nextPosition);
    }
}