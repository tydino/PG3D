using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHitBox_player : MonoBehaviour
{
    [Header("main")]
    public ThirdPersonMovement tpm;
    public Animator animMain;
    public string WalkAnim;
    public string RunAnim;
    public string JumpAnim;
    public string AttackAnim;
    public string FallAnim;
    [Header("eyes")]
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
        //reset animations
        animEye.SetBool(ForwardEye, false);
        animEye.SetBool(LeftEye, false);
        animEye.SetBool(RightEye, false);
        animEye.SetBool("moving", true);
        animEye.SetBool("hit", false);
        animEye.SetBool("dizzy", false);
        //calculate blinks
        int vel = Mathf.CeilToInt(tpm.velocity.y);
        //eye movement
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
        }
        else if (Input.GetKey(leftKey))
        {
            animEye.SetBool(LeftEye, true);
        }
        else if (Input.GetKey(rightKey))
        {
            animEye.SetBool(RightEye, true);
        }
        else
        {
            animEye.SetBool("moving", false);
        }
    }

    void blinkVoid(){if(canBlink==false){blink.blinking = true; canBlink = true;}}

    void playerAnim()
    {
        animMain.SetBool(WalkAnim, false);
        animMain.SetBool(RunAnim, false);
        animMain.SetBool(JumpAnim, false);
        animMain.SetBool(AttackAnim, false);
        animMain.SetBool(FallAnim, false);
        if(tpm.AmWalk)
        {
            if(tpm.state == ThirdPersonMovement.MoveMentState.walking) {animMain.SetBool(WalkAnim, true);}
            else if(tpm.state == ThirdPersonMovement.MoveMentState.sprinting) {animMain.SetBool(RunAnim, true);}
        }
        if(Input.GetButtonDown("Jump")){animMain.SetBool(JumpAnim, true);}
        if(Input.GetKey(KeyCode.Q)) {animMain.SetBool(AttackAnim, true);}
        if(!tpm.isGrounded){animMain.SetBool(FallAnim, true);}
    }
    public void CancelHitBox(){tpm.HitBox.SetActive(false); tpm.HitBoxOn = false;}

    void Update()
    {
        Eyes();
        playerAnim();
        if(canBlink == true){canBlink = false; float Time = Random.Range(10f, 20f); Invoke("blinkVoid", Time);}
    }
}