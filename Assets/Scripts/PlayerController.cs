using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public bool isAlive = true;
    public bool hasWon = false;

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


    AudioSource audio;
    public AudioClip footsteps;
    public AudioClip punch;

    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected ContactFilter2D contactFilter;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        gravity = (-2f * jumpHeight) / (jumpApexTime * jumpApexTime);
        Physics2D.gravity = new Vector2(0f, gravity);
        jumpVelocity = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
    }

    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void playFootstep()
    {
        audio.clip = footsteps;
        audio.Play();
    }

    void playPunch()
    {
        audio.clip = punch;
        audio.Play();
    }

    protected void FixedUpdate()
    {
        base.FixedUpdate();

        // @TODO get all hits, loop through once, check each condition or intentially shot the cast outside itself using bounds?

        // only doing rayast for non physics calculations like win and lose collissions
        // check for forward collissions
        Vector2 dir = new Vector2(rb2d.velocity.x, 0f);
        int count = rb2d.Cast(dir, hitBuffer);
        for (int i = 0; i < count; i++)
        {
            if(!hasWon && hitBuffer[i].collider.tag.Equals("Finish"))
            {
                hasWon = true;
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D collider = collision.GetComponent<Collider2D>();
        
        ContactPoint2D[] contactPoint = new ContactPoint2D[1];
        collision.GetContacts(contactPoint);
        Vector3 center = collider.bounds.center;

        bool right = contactPoint[0].point.x > center.x;
        bool top = contactPoint[0].point.y > center.y;

        if(this.grounded && top)
        {
            this.isAlive = false;
        }
    }

    protected override void ComputeVelocity()
    {
        if (!isAlive || hasWon) return;

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
        velocity = new Vector2(0, 0);
        animator.StopPlayback();
        audio.Stop();
        isAlive = false;
    }
}

