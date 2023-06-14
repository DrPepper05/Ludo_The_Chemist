using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardPlayerMovement  : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    public LayerMask whatIsGround;
    public LayerMask whatIsWall;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    bool grounded; 
    public float groundDrag;
    public float offset;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Economy.money = 10;
        CustomerCounter.customerCount= 0;
        readyToJump = true;
    }
     
    private void Update()
    {
        
        grounded = Physics.Raycast(transform.position, Vector3.down,  0.3f, whatIsGround);
       
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        
        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
       
    }
    private void MovePlayer()
    {
        
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

       
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        /**if(moveDirection ==  Vector3.zero )
        {
            rb.velocity = Vector3.zero;
        }*/
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        // groundDrag = Mathf.Max(rb.velocity.x , rb.velocity.y)+ offset;
        
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }
    private void Jump()
    {

        
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}