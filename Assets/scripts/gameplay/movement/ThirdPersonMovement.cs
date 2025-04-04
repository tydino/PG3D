using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Rigidbody rb;
    [Header("speeds")]
    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float airSpeed = 8f;
    public float speed = 6f;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    bool readyToJump;
    [Header("turning")]
    public float turnSmoothTime = 0.5f;
    float turnSmoothVelocity;
    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public MoveMentState state;
    public enum MoveMentState
    {
        walking,
        sprinting,
        air
    }
    [Header("ground Check")]
    public float playerHeight;
    public LayerMask whatIGround;
    bool grounded;

    void Start(){readyToJump=true;}

    void checkKeys()
    {
        if (Input.GetKeyDown(sprintKey)==true)
        {
            state=MoveMentState.sprinting;
        }else
        {
            state=MoveMentState.walking;
        }
    }

    void Update()
    {
        checkKeys();
        
        //jump
        if(Input.GetKey(jumpKey) && readyToJump == true && grounded == true)
        {
            readyToJump = false;

            jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        //grounded?
        grounded=Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f+0.2f, whatIGround);
        if (grounded == false){state=MoveMentState.air;}

        //main movement
        if(state==MoveMentState.walking){speed = walkSpeed;}
        if(state==MoveMentState.sprinting){speed = runSpeed;}
        if(state==MoveMentState.air){speed = airSpeed;}

        //get direction
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
    }

    void jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    void ResetJump()
    {
        readyToJump=true;
    }
}
