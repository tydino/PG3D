using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static Utilities current = new Utilities();

    #region distances
    public float DistanceFrom(Vector3 whereTo, Vector3 currentPos)
    {
        return Vector3.Distance(whereTo, currentPos);
    } 

    public float DistanceFromList(List<Vector3> wheres, Vector3 currentPos)
    {
        float lowest = -1f;
        for(int i=0;i< wheres.Count; i++)
        {
            if(DistanceFrom(wheres[i], currentPos) < lowest || lowest == -1f)
            {
                lowest = DistanceFrom(wheres[i], currentPos);
            }
        }
        return lowest;
    }
    
    public int ClosestDistanceFromListToInt(List<Vector3> wheres, Vector3 currentPos)
    {
        float lowest = -1f;
        int currentDistanceInList = -1;
        for (int i = 0; i < wheres.Count; i++)
        {
            if (DistanceFrom(wheres[i], currentPos) < lowest || lowest == -1f)
            {
                currentDistanceInList = i;
                lowest = DistanceFrom(wheres[i], currentPos);
            }
        }
        if (currentDistanceInList == -1)
        {
            Debug.LogError("Something isn't right with something in closest distance in one script, is there something missing from a list?");
        }
        return currentDistanceInList;
    }
    #endregion

    #region Parenting
    public void ParentObjectToAnotherObject(GameObject objectToParent, GameObject parent)
    {
        objectToParent.transform.SetParent(parent.transform);
    }

    public void RemoveObjectFromParent(GameObject removeFromParent)
    {
        removeFromParent.transform.SetParent(null);
    }
    #endregion
}
