using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCapsuleCollider;
    BoxCollider2D myFeet;
    Animator myAnimator;
    float maxJump = 2;

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpPower = 5f;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Flip();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            maxJump = 2;
        }
        
        if (maxJump>0)
        {
            if (value.isPressed)
            {
                myRigidbody.velocity += new Vector2 (0f, jumpPower);
                maxJump--;
            }
        }
        else
        {
            return;
        }
    }
    
    void Run()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) && myRigidbody.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool isMoving = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        
        if (isMoving)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    void Flip()
    {
        bool isMoving = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (isMoving)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}