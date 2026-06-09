using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PatrolGoal : Goal
{
    public NPC thisNPC;
    public bool loopsOrBackAndForth;
    bool forward = true;
    public List<Vector3> positionsToGoBetween;
    public float threasholdForCloseToPatrolTarget = 2f;
    public int targetPosition = 0;
    public override bool canUse()
    {
        if (Utilities.current.DistanceFromList(positionsToGoBetween, thisNPC.gameObject.transform.position) <= threasholdForCloseToPatrolTarget && thisNPC.CheckVisionForEnemy(out GameObject None) == new Vector3(0, -1000, 0))
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
        //get direction
        Vector3 direction = positionsToGoBetween[targetPosition] - thisNPC.rb.position;

        //makes sure target position is not directly abovem if it is, it will reroll direction
        if (direction.sqrMagnitude < 0.1f)
        {
            if (loopsOrBackAndForth)
            {
                targetPosition++;

                if (targetPosition > positionsToGoBetween.Count - 1)
                {
                    targetPosition = 0;
                }
            }
            else
            {
                if (forward)
                {
                    targetPosition++;
                    if (targetPosition > positionsToGoBetween.Count - 1)
                    {
                        forward = false;
                        targetPosition--;
                        targetPosition--;
                    }
                }
                else
                {
                    targetPosition--;
                    if (targetPosition < 0)
                    {
                        forward = true;
                        targetPosition++;
                        targetPosition++;
                    }
                }
            }
            direction = positionsToGoBetween[targetPosition] - thisNPC.rb.position;
        }

        //gets and sets rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion nextRotation = Quaternion.RotateTowards(thisNPC.rb.rotation, lookRotation, thisNPC.RotationSpeed * Time.fixedDeltaTime);
        thisNPC.rb.MoveRotation(nextRotation);

        //moves NPC
        Vector3 nextPosition = Vector3.MoveTowards(thisNPC.rb.position, positionsToGoBetween[targetPosition], thisNPC.WalkSpeed * Time.fixedDeltaTime);
        thisNPC.rb.MovePosition(nextPosition);
    }
}
