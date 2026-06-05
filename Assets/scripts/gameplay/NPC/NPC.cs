using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Types type;
    public float WalkSpeed = 0.5f;
    public float FollowRange;
    public float AttackDamage;
    public float MaxHealth = 1f;
    public float JumpStrength = 1f;

    public enum Types
    {
        Hostile,
        Passive,
        Boss
    }
}
