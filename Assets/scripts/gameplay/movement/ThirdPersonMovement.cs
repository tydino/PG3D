using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Rigidbody rb;
    public bool PlayerHit;//controlled externally
    public bool HitEnemy;
    public bool HitBoxOn;
    public GameObject HitBox;
    public int health = 3;
    [Header("speeds")]
    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float airMultiplier = 1.25f;
    public float speed = 6f;
    [Header("Jumping")]
    public float jumpHeight = 10f;
    public float gravity = -9.81f;
    public Vector3 velocity;
    public bool isGrounded;
    public bool canDoubleJump = false;
    [Header("turning")]
    public float turnSmoothTime = 0.5f;
    float turnSmoothVelocity;
    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode SpinJump = KeyCode.Q;//figure out how to do, or ask for help.
    public MoveMentState state;
    public enum MoveMentState
    {
        walking,
        sprinting
    }
    [Header("ground Check")]
    public float playerHeight;
    public LayerMask whatIGround;
    bool grounded;

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
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            canDoubleJump=true;
        }
        
        //jump
        if(Input.GetKey(jumpKey) && grounded == true)
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else if (canDoubleJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                canDoubleJump = false;
            }
            
        }

        //grounded?
        grounded=Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f+0.2f, whatIGround);

        //main movement
        if(state==MoveMentState.walking){speed = walkSpeed;}
        if(state==MoveMentState.sprinting){speed = runSpeed;}

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
            if (grounded==true){controller.Move(moveDir * speed * Time.deltaTime);}
            if (grounded==false){controller.Move(moveDir * speed * airMultiplier * Time.deltaTime);}
            
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
