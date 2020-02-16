using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public Animator animator;
    public float jumpForce = 0f;
    public float moveSpeed = 2f;
    //public float meleeAttackDelay = 0.3f;
    /*public float runFastTime = 3f;
    public float boostTime = 0f;
    public int health = 100;
    public int point = 0;
    public Text pointScoreBoard;
    public Text boostTimeBoard;*/
    //public Transform MagicStandPos;
    //public GameObject MagicLeft;
    //public GameObject MagicRight;
    /*bool jump = false;
    bool right = true;
    bool grounded = true;
    bool crouch = false;
    bool onAir = false;

    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;

    public UnityEvent OnLandEvent;

    private void Awake()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    void Update()
    {
        animator.SetFloat("MoveSpeed", Mathf.Abs(moveSpeed));

        if (Input.GetKeyUp(KeyCode.Space))
            jumpForce = 0;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            moveSpeed = 8;
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            moveSpeed = -8;
        else
            moveSpeed = 0;


        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jumpForce = 150;*/
            /*if (jumpForce < 150)
                jumpForce += 30f;
            else
                jumpForce = 0;*/
        /*    jump = true;
        }

        if (grounded)
            onAir = false;

        if (grounded || onAir)
        {
            bool wasCrouching = crouch;
            // If crouching
            if (crouch)
            {
                if (!wasCrouching)
                {
                    wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }*/

                // Reduce the speed by the crouchSpeed multiplier
                //moveSpeed *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                //if (m_CrouchDisableCollider != null)
                //    m_CrouchDisableCollider.enabled = false;
                /*if (!crouch)
                {
                    // If the character has a ceiling preventing them from standing up, keep them crouching
                    if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                    {
                        crouch = true;
                    }
                }*/
            /*}
            else
            {
                // Enable the collider when not crouching
                //if (m_CrouchDisableCollider != null)
                //    m_CrouchDisableCollider.enabled = true;

                if (wasCrouching)
                {
                    wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);

            if (moveSpeed > 0 && !right)
            {
                Flip();
            }

            else if (moveSpeed < 0 && right)
            {
                Flip();
            }
        }

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }
    }

    void FixedUpdate()
    {
        jump = false;
    }

    private void Flip()
    {
        right = !right;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        Vector2 offsetCol = GetComponent<BoxCollider2D>().offset;
        offsetCol.x *= -1;
        GetComponent<BoxCollider2D>().offset = offsetCol;
    }*/
}
