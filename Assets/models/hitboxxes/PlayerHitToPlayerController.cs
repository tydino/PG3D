using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitToPlayerController : MonoBehaviour
{
    public ThirdPersonMovement tpm;
    public string EnemyTag = "enemy";
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == EnemyTag)
        {
            if(tpm.HitEnemy==false)
            {
                //deduct damage to enemy when enemy script in
                tpm.HitEnemy = true;
                tpm.HitBoxOn = false;
                tpm.HitBox.SetActive(false);
            }
        }
    }
}
