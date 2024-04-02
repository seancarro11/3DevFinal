using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerZach : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    // Leftover code from Clinic 2
    //public KeyCode punchKey = KeyCode.E;
    //public KeyCode crouchKey = KeyCode.LeftControl;
    //public KeyCode runKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    private Animator playerAnimation;
    public bool isRunning;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        playerAnimation = GetComponent<Animator>();
        isRunning = false;
    }

    void Update()
    {
        playerInput();
        speedControl();
        // Sprint function also from Clinic 2
        //run();

        //grounded check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //handles drag, then handles Animator grounded boolean. Ended up not needing the grounded boolean within animator, but kept the code just in case
        if (grounded)
        {
            rb.drag = groundDrag;
            //playerAnimation.SetBool("grounded", true);
        }
        else
        {
            rb.drag = 0;
            //playerAnimation.SetBool("grounded", false);
        }

        Vector3 playerVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        playerAnimation.SetFloat("move_speed", playerVelocity.magnitude);
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void playerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //handles when player is able to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            jump();
            //playerAnimation.SetTrigger("jump_trigger");
            Invoke(nameof(resetJump), jumpCooldown);
        }

        //if (Input.GetKey(punchKey) && grounded)
        //{
        //    playerAnimation.SetTrigger("punch_trigger");
        //}

        //if (Input.GetKey(crouchKey) && grounded)
        //{
        //    playerAnimation.SetTrigger("crouch_trigger");
        //}
    }

    private void movePlayer()
    {
        //calculates movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        //in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void speedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //velocity limiter
        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void jump()
    {
        //resets y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        readyToJump = true;
    }

    //private void run()
    //{
    //    if (Input.GetKey(runKey) && grounded)
    //    {
    //        isRunning = true;
    //    }
    //    else
    //    {
    //        isRunning = false;
    //    }

    //    if (isRunning == true)
    //    {
    //        moveSpeed = runSpeed;
    //    }
    //    else
    //    {
    //        moveSpeed = walkSpeed;
    //    }
    //}
}
