using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    Vector2 moveInput;
    CapsuleCollider2D myCapsuleCollider;
    BoxCollider2D myFeet;
    Animator myAnimator;
    float maxJump = 2;
    int currentWeapon;
    BuyWeapon buy;
    Vector2 playerResPost;
    private bool damaged = false;

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] GameObject sword;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        playerResPost = transform.position;
    }

    void Update()
    {
        Run();
        Flip();
        if (!damaged)
        {
            StartCoroutine(Trapped());   
        }
        jumpAnimation();
        Checkpoint();
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
        if (currentWeapon == 0)
        {
            Instantiate(sword, gun.position, transform.rotation);
        }
        else
        {
            Instantiate(bullet, gun.position, transform.rotation);
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

    IEnumerator Trapped()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Trap")))
        {
            damaged = true;
            transform.position = playerResPost;
            FindObjectOfType<LifeCount>().LoseLife(1);
            yield return new WaitForSeconds(2f);
            damaged = false;
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
        if (PlayerPrefs.GetInt("riffle") ==  0)
        {
            return;
        }
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

    void OnEnterShop(InputValue input)
    {
        if(myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Shop")))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void Checkpoint() {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Checkpoint")))
        {
            playerResPost = transform.position;
        }
    }
}