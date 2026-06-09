using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
