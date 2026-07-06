using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVEBrain : NPC
{
    public override void SetStatus()
    {
        if(settings.isHostile.Enemy == null)
        {
            status = Statusses.List_placeToPlaceTillSeePlayer;
        }
        if (settings.isHostile.Enemy != null && Utilities.current.DistanceFrom(gameObject.transform.position, settings.isHostile.Enemy.transform.position) > settings.isHostile.threasholdBeforeAttack)
        {
            status = Statusses.FollowPlayerToAttckPlayer;
            movement.targetPosition = Utilities.current.ClosestDistanceFromListToInt(movement.positionsToGoBetween, gameObject.transform.position);
        }
        if (settings.isHostile.Enemy != null && Utilities.current.DistanceFrom(gameObject.transform.position, settings.isHostile.Enemy.transform.position) < settings.isHostile.threasholdBeforeAttack)
        {
            status = Statusses.AttackPlayerUntillOutOfRange;
            movement.targetPosition = Utilities.current.ClosestDistanceFromListToInt(movement.positionsToGoBetween, gameObject.transform.position);
        }
    }
}
