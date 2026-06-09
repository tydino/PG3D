using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Rigidbody rb;
    public GoalSelector Goals;
    public Types type;
    public float WalkSpeed = 0.25f;
    public float RotationSpeed = 80f;
    public float FollowRange;
    public float AttackDamage;
    public float JumpStrength = 1f;
    public NPC_Vision vision;
    public Health health;
    public int MaxHealth;

    public enum Types
    {
        Hostile,
        Passive,
        Boss
    }

    private void Update()
    {
        vision.Update();
        Goals.tickOnUpdate();
    }

    private void Start()
    {
        health.health = MaxHealth;
    }

    public Vector3 CheckVisionForEnemy(out GameObject Enemy)
    {
        Physics.Raycast(vision.eyeFrontPosition.position, vision.eyeFrontPosition.TransformDirection(Vector3.forward), out vision.VisibilityFrontEnemy, vision.visibilityLength, vision.IfEnemy);
        Physics.Raycast(vision.eyeLeftPosition.position, vision.eyeLeftPosition.TransformDirection(Vector3.forward), out vision.VisibilityLeftEnemy, vision.visibilityLength, vision.IfEnemy);
        Physics.Raycast(vision.eyeRightPosition.position, vision.eyeRightPosition.TransformDirection(Vector3.forward), out vision.VisibilityRightEnemy, vision.visibilityLength, vision.IfEnemy);
        Physics.Raycast(vision.eyeTopPosition.position, vision.eyeTopPosition.TransformDirection(Vector3.forward), out vision.VisibilityUpEnemy, vision.visibilityLength, vision.IfEnemy);
        Physics.Raycast(vision.eyeBottomPosition.position, vision.eyeBottomPosition.TransformDirection(Vector3.forward), out vision.VisibilityDownEnemy, vision.visibilityLength, vision.IfEnemy);

        if(vision.VisibilityFrontEnemy.collider != null)
        {
            Enemy = vision.VisibilityFrontEnemy.collider.gameObject;
            return vision.VisibilityFrontEnemy.collider.gameObject.transform.position;
        }
        else if (vision.VisibilityLeftEnemy.collider != null)
        {
            Enemy = vision.VisibilityLeftEnemy.collider.gameObject;
            return vision.VisibilityLeftEnemy.collider.gameObject.transform.position;
        }
        else if (vision.VisibilityRightEnemy.collider != null)
        {
            Enemy = vision.VisibilityRightEnemy.collider.gameObject;
            return vision.VisibilityRightEnemy.collider.gameObject.transform.position;
        }
        else if (vision.VisibilityUpEnemy.collider != null)
        {
            Enemy = vision.VisibilityUpEnemy.collider.gameObject;
            return vision.VisibilityUpEnemy.collider.gameObject.transform.position;
        }
        else if (vision.VisibilityDownEnemy.collider != null)
        {
            Enemy = vision.VisibilityDownEnemy.collider.gameObject;
            return vision.VisibilityDownEnemy.collider.gameObject.transform.position;
        }
        Enemy = null;
        return new Vector3(0, -1000, 0);
    }

    public Vector3 CheckVisionForObstacle()
    {
        Physics.Raycast(vision.eyeFrontPosition.position, vision.eyeFrontPosition.TransformDirection(Vector3.forward), out vision.VisibilityFrontObstacle, vision.visibilityLength, vision.IfEnemy);
        Physics.Raycast(vision.eyeLeftPosition.position, vision.eyeLeftPosition.TransformDirection(Vector3.forward), out vision.VisibilityLeftObstacle, vision.visibilityLength, vision.IfEnemy);
        Physics.Raycast(vision.eyeRightPosition.position, vision.eyeRightPosition.TransformDirection(Vector3.forward), out vision.VisibilityRightObstacle, vision.visibilityLength, vision.IfEnemy);
        Physics.Raycast(vision.eyeTopPosition.position, vision.eyeTopPosition.TransformDirection(Vector3.forward), out vision.VisibilityUpObstacle, vision.visibilityLength, vision.IfEnemy);
        Physics.Raycast(vision.eyeBottomPosition.position, vision.eyeBottomPosition.TransformDirection(Vector3.forward), out vision.VisibilityDownObstacle, vision.visibilityLength, vision.IfEnemy);

        if (vision.VisibilityFrontObstacle.collider != null)
        {
            return vision.VisibilityFrontObstacle.collider.gameObject.transform.position;
        }
        else if (vision.VisibilityLeftObstacle.collider != null)
        {
            return vision.VisibilityLeftObstacle.collider.gameObject.transform.position;
        }
        else if (vision.VisibilityRightObstacle.collider != null)
        {
            return vision.VisibilityRightObstacle.collider.gameObject.transform.position;
        }
        else if (vision.VisibilityUpObstacle.collider != null)
        {
            return vision.VisibilityUpObstacle.collider.gameObject.transform.position;
        }
        else if (vision.VisibilityDownObstacle.collider != null)
        {
            return vision.VisibilityDownObstacle.collider.gameObject.transform.position;
        }
        return new Vector3(0, -1000, 0);
    }
}
