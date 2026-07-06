using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //public variables
    public Rigidbody rb;
    public Animator a;
    public Statusses status;
    public GameObject TemporaryObjects;
    public NPC_Settings settings;
    public NPC_Vision vision;
    public NPC_movement movement;

    public enum Statusses
    {
        //only for hostile entities
        List_placeToPlaceTillSeePlayer,
        FollowPlayerToAttckPlayer,
        AttackPlayerUntillOutOfRange
    }

    private void Update()
    {
        SetStatus();
        vision.Update();
        if (settings.isHostile.IsHostile)
        {
            vision.CheckVisionForEnemy(out settings.isHostile.Enemy);
        }
        movement.Update(this);
    }

    public virtual void SetStatus() { }

}
[System.Serializable]
public class IsHostileEntity
{
    public bool IsHostile = false;
    public bool IsABoss = false;
    public int AttackDamage = 1;
    public GameObject Enemy;
    public float threasholdBeforeAttack;
}

[System.Serializable]
public class NPC_Vision
{
    public bool HasEyes = true;
    public bool debugOn = true;
    public Transform eyeFrontPosition;
    public Transform eyeLeftPosition;
    public Transform eyeRightPosition;
    public Transform eyeTopPosition;
    public Transform eyeBottomPosition;
    public float visibilityLength;
    public RaycastHit VisibilityDebug;
    public RaycastHit VisibilityFrontEnemy;
    public RaycastHit VisibilityFrontObstacle;
    public RaycastHit VisibilityLeftEnemy;
    public RaycastHit VisibilityLeftObstacle;
    public RaycastHit VisibilityRightEnemy;
    public RaycastHit VisibilityRightObstacle;
    public RaycastHit VisibilityUpEnemy;
    public RaycastHit VisibilityUpObstacle;
    public RaycastHit VisibilityDownEnemy;
    public RaycastHit VisibilityDownObstacle;
    public LayerMask IfEnemy;
    public LayerMask Obstacle;
    public bool obstaclefront;
    public bool obstacleft;
    public bool obstacright;
    public bool obstacleup;

    public void Update()
    {
        if (HasEyes && debugOn)
        {//this renders the debug sights
            /// FRONT //
            if (Physics.Raycast(eyeFrontPosition.position, eyeFrontPosition.TransformDirection(Vector3.forward), out VisibilityDebug, visibilityLength))
            {
                Debug.DrawRay(eyeFrontPosition.position, eyeFrontPosition.TransformDirection(Vector3.forward) * VisibilityDebug.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(eyeFrontPosition.position, eyeFrontPosition.TransformDirection(Vector3.forward) * visibilityLength, Color.red);
            }
            /// LEFT ///
            if (Physics.Raycast(eyeLeftPosition.position, eyeLeftPosition.TransformDirection(Vector3.forward), out VisibilityDebug, visibilityLength))
            {
                Debug.DrawRay(eyeLeftPosition.position, eyeLeftPosition.TransformDirection(Vector3.forward) * VisibilityDebug.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(eyeLeftPosition.position, eyeLeftPosition.TransformDirection(Vector3.forward) * visibilityLength, Color.red);
            }
            /// RIGHT ///
            if (Physics.Raycast(eyeRightPosition.position, eyeRightPosition.TransformDirection(Vector3.forward), out VisibilityDebug, visibilityLength))
            {
                Debug.DrawRay(eyeRightPosition.position, eyeRightPosition.TransformDirection(Vector3.forward) * VisibilityDebug.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(eyeRightPosition.position, eyeRightPosition.TransformDirection(Vector3.forward) * visibilityLength, Color.red);
            }
            /// TOP ///
            if (Physics.Raycast(eyeTopPosition.position, eyeTopPosition.TransformDirection(Vector3.forward), out VisibilityDebug, visibilityLength))
            {
                Debug.DrawRay(eyeTopPosition.position, eyeTopPosition.TransformDirection(Vector3.forward) * VisibilityDebug.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(eyeTopPosition.position, eyeTopPosition.TransformDirection(Vector3.forward) * visibilityLength, Color.red);
            }
            /// BOTTOM ///
            if (Physics.Raycast(eyeBottomPosition.position, eyeBottomPosition.TransformDirection(Vector3.forward), out VisibilityDebug, visibilityLength))
            {
                Debug.DrawRay(eyeBottomPosition.position, eyeBottomPosition.TransformDirection(Vector3.forward) * VisibilityDebug.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(eyeBottomPosition.position, eyeBottomPosition.TransformDirection(Vector3.forward) * visibilityLength, Color.red);
            }
        }
    }
    public Vector3 CheckVisionForEnemy(out GameObject Enemy)
    {
        Physics.Raycast(eyeFrontPosition.position, eyeFrontPosition.TransformDirection(Vector3.forward), out VisibilityFrontEnemy, visibilityLength, IfEnemy);
        Physics.Raycast(eyeLeftPosition.position, eyeLeftPosition.TransformDirection(Vector3.forward), out VisibilityLeftEnemy, visibilityLength, IfEnemy);
        Physics.Raycast(eyeRightPosition.position, eyeRightPosition.TransformDirection(Vector3.forward), out VisibilityRightEnemy, visibilityLength, IfEnemy);
        Physics.Raycast(eyeTopPosition.position, eyeTopPosition.TransformDirection(Vector3.forward), out VisibilityUpEnemy, visibilityLength, IfEnemy);
        Physics.Raycast(eyeBottomPosition.position, eyeBottomPosition.TransformDirection(Vector3.forward), out VisibilityDownEnemy, visibilityLength, IfEnemy);

        if (VisibilityFrontEnemy.collider != null)
        {
            Enemy = VisibilityFrontEnemy.collider.gameObject;
            return VisibilityFrontEnemy.collider.gameObject.transform.position;
        }
        else if (VisibilityLeftEnemy.collider != null)
        {
            Enemy = VisibilityLeftEnemy.collider.gameObject;
            return VisibilityLeftEnemy.collider.gameObject.transform.position;
        }
        else if (VisibilityRightEnemy.collider != null)
        {
            Enemy = VisibilityRightEnemy.collider.gameObject;
            return VisibilityRightEnemy.collider.gameObject.transform.position;
        }
        else if (VisibilityUpEnemy.collider != null)
        {
            Enemy = VisibilityUpEnemy.collider.gameObject;
            return VisibilityUpEnemy.collider.gameObject.transform.position;
        }
        else if (VisibilityDownEnemy.collider != null)
        {
            Enemy = VisibilityDownEnemy.collider.gameObject;
            return VisibilityDownEnemy.collider.gameObject.transform.position;
        }
        Enemy = null;
        return new Vector3(0, -1000, 0);
    }

    public Vector3 CheckVisionForObstacle()
    {
        Physics.Raycast(eyeFrontPosition.position, eyeFrontPosition.TransformDirection(Vector3.forward), out VisibilityFrontObstacle, visibilityLength, IfEnemy);
        Physics.Raycast(eyeLeftPosition.position, eyeLeftPosition.TransformDirection(Vector3.forward), out VisibilityLeftObstacle, visibilityLength, IfEnemy);
        Physics.Raycast(eyeRightPosition.position, eyeRightPosition.TransformDirection(Vector3.forward), out VisibilityRightObstacle, visibilityLength, IfEnemy);
        Physics.Raycast(eyeTopPosition.position, eyeTopPosition.TransformDirection(Vector3.forward), out VisibilityUpObstacle, visibilityLength, IfEnemy);
        Physics.Raycast(eyeBottomPosition.position, eyeBottomPosition.TransformDirection(Vector3.forward), out VisibilityDownObstacle, visibilityLength, IfEnemy);

        if (VisibilityFrontObstacle.collider != null)
        {
            return VisibilityFrontObstacle.collider.gameObject.transform.position;
        }
        else if (VisibilityLeftObstacle.collider != null)
        {
            return VisibilityLeftObstacle.collider.gameObject.transform.position;
        }
        else if (VisibilityRightObstacle.collider != null)
        {
            return VisibilityRightObstacle.collider.gameObject.transform.position;
        }
        else if (VisibilityUpObstacle.collider != null)
        {
            return VisibilityUpObstacle.collider.gameObject.transform.position;
        }
        else if (VisibilityDownObstacle.collider != null)
        {
            return VisibilityDownObstacle.collider.gameObject.transform.position;
        }
        return new Vector3(0, -1000, 0);
    }

    public bool obstacledown()
    {
        Physics.Raycast(eyeBottomPosition.position, eyeBottomPosition.TransformDirection(Vector3.forward), out VisibilityDownObstacle, visibilityLength, IfEnemy);
        if (VisibilityDownObstacle.collider != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

[System.Serializable]
public class NPC_Settings
{
    public Health health;
    public IsHostileEntity isHostile;
    public List<NPC.Statusses> AvailableStatussesForThisNPC;
}

[System.Serializable]
public class NPC_movement
{
    [Header("Movement basis:")]
    public float WalkSpeed = 0.25f;
    public float RotationSpeed = 80f;
    [Header("If it is a List_pathToPath user:")]
    public List<Vector3> positionsToGoBetween;
    public int targetPosition = 0;
    public bool loopsOrBackAndForth;
    public float distanceBeforeGoingBackToList_pathToPath;
    bool forward = true;

    public void Update(NPC npc)
    {
        if (npc.status == NPC.Statusses.List_placeToPlaceTillSeePlayer)
        {
            List_placeToPlace(npc.rb);
        }
        if(npc.status == NPC.Statusses.FollowPlayerToAttckPlayer)
        {
            FollowPlayerToAttckPlayer(npc);
        }
    }

    #region HostilePathfinders
    public void List_placeToPlace(Rigidbody rb)
    {
        //get direction
        Vector3 direction = positionsToGoBetween[targetPosition] - rb.position;

        //makes sure target position is not directly abovem if it is, it will reroll direction
        if (direction.sqrMagnitude < 0.1f)
        {
            if (!loopsOrBackAndForth)
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
            direction = positionsToGoBetween[targetPosition] - rb.position;
        }

        //gets and sets rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion nextRotation = Quaternion.RotateTowards(rb.rotation, lookRotation, RotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(nextRotation);

        //moves NPC
        Vector3 nextPosition = Vector3.MoveTowards(rb.position, positionsToGoBetween[targetPosition], WalkSpeed * Time.fixedDeltaTime);
        rb.MovePosition(nextPosition);

    }
    public void FollowPlayerToAttckPlayer(NPC npc)
    {
        if (npc.vision.obstacledown()) {
            //gets placement to look towards
            Vector3 EnemyCenter = npc.settings.isHostile.Enemy.transform.position;
            EnemyCenter.y = EnemyCenter.y + 0.5f;
            //get direction
            Vector3 direction = EnemyCenter - npc.rb.position;

            //gets and sets rotation
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion nextRotation = Quaternion.RotateTowards(npc.rb.rotation, lookRotation, RotationSpeed * Time.fixedDeltaTime);
            npc.rb.MoveRotation(nextRotation);

            //moves NPC
            Vector3 nextPosition = Vector3.MoveTowards(npc.rb.position, npc.settings.isHostile.Enemy.transform.position, WalkSpeed * Time.fixedDeltaTime);
            npc.rb.MovePosition(nextPosition);
        }
    }
    #endregion
}
