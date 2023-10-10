using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 8f;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        { 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if ( IsGrounded() )
        {
            if (dirX > 0f)
            {
                anim.Play("Player_running");
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                anim.Play("Player_running");
                sprite.flipX = true;
            }
            else
            {
                anim.Play("Player_idle");
            }
        }
        else
        {

            if (dirX > 0f)
            {
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                sprite.flipX = true;
            }

            if (rb.velocity.y > .1f)
            {
                anim.Play("Player_jump");
            }
            else if (rb.velocity.y < -.1f)
            {
                anim.Play("Player_falling");
            }
        }
//        anim.SetInteger("state", (int)state);
    }
  
    private bool IsGrounded()
    {
       // return true;
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}