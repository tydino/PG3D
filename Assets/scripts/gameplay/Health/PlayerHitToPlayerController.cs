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
                Health eh = other.gameObject.GetComponent<NPC>().health;
                eh.health--;
                tpm.HitEnemy = true;
                tpm.HitBoxOn = false;
                tpm.HitBox.SetActive(false);
                Debug.Log("hit enemy");
            }
        }
    }
}
