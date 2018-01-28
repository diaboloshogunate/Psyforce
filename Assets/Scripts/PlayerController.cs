﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    public bool isAlive = true;

    public float maxSpeed = 7f;
    protected float gravity = 0f;
    protected float jumpVelocity = 0f;
    public float jumpHeight = 5f;
    public float jumpApexTime = 0.5f;
    public float jumpRelease = 0.5f;
    public int playerNumber;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isFacingRight = true;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gravity = (-2f * jumpHeight) / (jumpApexTime * jumpApexTime);
        Physics2D.gravity = new Vector2(0f, gravity);
        jumpVelocity =  Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("P" + playerNumber + "_Horizontal");
        

        if (Input.GetButtonDown("P" + playerNumber + "_Jump") && grounded)
        {
            velocity.y = jumpVelocity;
        }
        else if (Input.GetButtonUp("P" + playerNumber + "_Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * jumpRelease;
            }
        }
        
        if((move.x > 0.01f && !isFacingRight) || (move.x < -0.01f && isFacingRight))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            isFacingRight = !isFacingRight;

        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    public void kill()
    {
        isAlive = false;
    }
}

