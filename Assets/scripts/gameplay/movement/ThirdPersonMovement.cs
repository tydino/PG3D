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
    public bool AmWalk;
    [Header("speeds")]
    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float airMultiplier = 1.25f;
    public float speed = 6f;
    [Header("Jumping")]
    public float jumpHeight = 1f;
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
    public KeyCode SpinJump = KeyCode.Q;
    public MoveMentState state;
    public enum MoveMentState
    {
        walking,
        sprinting,
        idle
    }
    [Header("ground Check")]
    public float playerHeight;
    public LayerMask whatIGround;
    bool grounded;

    void checkKeys()
    {
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)){AmWalk=true;}else{AmWalk=false;}
        if (Input.GetKey(sprintKey)==true)
        {
            state=MoveMentState.sprinting;
        }else if(AmWalk)
        {
            state=MoveMentState.walking;
        }else
        {
            state=MoveMentState.idle;
        }
    }

    void Start(){HitBox.SetActive(false);}

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
        if(Input.GetButtonDown("Jump"))
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

        //spinJump
        if(Input.GetKey(SpinJump)) {if (isGrounded){velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);HitBox.SetActive(true);HitBoxOn=true;HitEnemy=false;}}
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
        //jump
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
