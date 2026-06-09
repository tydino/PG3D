using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static Utilities current = new Utilities();
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
}
