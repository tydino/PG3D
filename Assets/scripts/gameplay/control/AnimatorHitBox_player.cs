using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHitBox_player : MonoBehaviour
{
    public ThirdPersonMovement tpm;
    public Animator animMain;
    public Animator animEye;
    public string ForwardEye;
    KeyCode leftKey = KeyCode.A;
    public string LeftEye;
    KeyCode rightKey = KeyCode.D;
    public string RightEye;
    public Blink blink;
    bool canBlink = true;

    void Eyes()
    {
        animEye.SetBool(ForwardEye, false);
        animEye.SetBool(LeftEye, false);
        animEye.SetBool(RightEye, false);
        animEye.SetBool("moving", true);
        animEye.SetBool("hit", false);
        animEye.SetBool("dizzy", false);
        int vel = Mathf.CeilToInt(tpm.velocity.y);
        if(tpm.PlayerHit == true)
        {
            tpm.PlayerHit = false;
            animEye.SetBool("hit", true);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            animEye.SetBool("dizzy", true);
        }
        else if(vel > 0)
        {
            animEye.SetBool(ForwardEye, true);
            animEye.SetBool(LeftEye, false);
            animEye.SetBool(RightEye, false);
        }
        else if (Input.GetKey(leftKey))
        {
            animEye.SetBool(ForwardEye, false);
            animEye.SetBool(LeftEye, true);
            animEye.SetBool(RightEye, false);
        }
        else if (Input.GetKey(rightKey))
        {
            animEye.SetBool(ForwardEye, false);
            animEye.SetBool(LeftEye, false);
            animEye.SetBool(RightEye, true);
        }
        else
        {
            animEye.SetBool("moving", false);
        }
    }

    void blinkVoid(){if(canBlink==false){blink.blinking = true; canBlink = true;}}

    void Update()
    {
        Eyes();
        float Time = Random.Range(10f, 20f);
        if(canBlink == true){canBlink = false; Invoke("blinkVoid", Time);}
    }
}