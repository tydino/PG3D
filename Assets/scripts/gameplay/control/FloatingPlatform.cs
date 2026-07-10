using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    [Header("parenting")]
    public GameObject parentsPlayerToThisObject;
    public bool IsParented;

    [Header("speeds")]
    public float NotParentedSpeed = 0.4f;
    public float ParentedSpeed = 0.25f;
    
    [Header("Place to place handlers")]
    public List<Vector3> positionsToGoBetween;
    public int targetPosition = 0;
    public bool loopsOrBackAndForth;

    [Header("requires SVEs to be killed")]
    public List<GameObject> SVE;
    public bool usesSVE;

    public bool canUse()//NOT IN PROPERLY YET
    {
        if (usesSVE)
        {
            int amountNotGone = 0;
            foreach (GameObject sve in SVE)
            {
                if (sve != null)
                {
                    amountNotGone++;
                }
            }
            if (amountNotGone == 0)
            {
                return true;
            }
            return false;
        }
        return true;
    }

    bool forward = true;
    Rigidbody rb;


    private void Start()
    {
        parentsPlayerToThisObject = gameObject;
        rb = parentsPlayerToThisObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = positionsToGoBetween[targetPosition] - rb.position;
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

        Vector3 nextPosition;

        if (canUse())
        {
            if (IsParented)
            {
                nextPosition = Vector3.MoveTowards(rb.position, positionsToGoBetween[targetPosition], ParentedSpeed * Time.fixedDeltaTime);
            }
            else
            {
                nextPosition = Vector3.MoveTowards(rb.position, positionsToGoBetween[targetPosition], NotParentedSpeed * Time.fixedDeltaTime);
            }
            rb.MovePosition(nextPosition);
        }
    }
}
