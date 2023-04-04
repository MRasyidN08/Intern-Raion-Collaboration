using System;
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
    int currentWeapon;

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    
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
        Trapped();
        jumpAnimation();
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
            myAnimator.SetBool("isJumpUp", false);
            myAnimator.SetBool("isJumpDown", false);
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
    
    void OnFire(InputValue value)
    {
        myAnimator.SetTrigger("Attack");
        Instantiate(bullet, gun.position, transform.rotation);
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

    void Trapped()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Trap")))
        {
            //health --
            myRigidbody.velocity = new Vector2 (0f, 0f);
            myAnimator.SetBool("isRunning", false);
        }
    }

    void jumpAnimation()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) || myRigidbody.velocity.y == 0)
        {
            myAnimator.SetBool("isJumpUp", false);
            myAnimator.SetBool("isJumpDown", false);
            return;
        }
        if (myRigidbody.velocity.y > 0)
        {
            myAnimator.SetBool("isJumpUp", true);
            myAnimator.SetBool("isRunning", false);
        }
        else if (myRigidbody.velocity.y < 0 || !myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            // myAnimator.SetBool("isJumpUp", false);
            myAnimator.SetBool("isJumpDown", true);
            myAnimator.SetBool("isRunning", false);
        }
    }

    void OnChangeWeapon()
    {
        if (currentWeapon == 0)
        {
            currentWeapon +=1;
            myAnimator.SetLayerWeight(currentWeapon - 1, 0);
            myAnimator.SetLayerWeight(currentWeapon, 1);
        }
        else
        {
            currentWeapon -=1;
            myAnimator.SetLayerWeight(currentWeapon + 1, 0);
            myAnimator.SetLayerWeight(currentWeapon - 1, 0);
        }
    }
}