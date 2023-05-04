using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidBody;
    public bool activeCharacter;

    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    public Collider2D rabbitHead;

    private Animator anim;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rabbitHead = GameObject.FindWithTag("RabbitHead").GetComponent<Collider2D>();
        rabbitHead.enabled = false;
        isGrounded = false;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        if (activeCharacter)
        {
            rigidBody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rigidBody.velocity.y);
            if (isGrounded)
            {
                canDoubleJump = true;
                // reset drag
                rigidBody.drag = 0;
            }
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce * 3);
                        // increase drag for Gliding
                        rigidBody.drag += 20;
                        canDoubleJump = false;
                    }
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                rabbitHead.offset = new Vector2(0, 1.85f);
                rabbitHead.enabled = true;
                anim.SetBool("stretching", true);
                
            }
            if (Input.GetButtonUp("Fire2"))
            {
                rabbitHead.offset = new Vector2(0, 0);
                rabbitHead.enabled = false;
                anim.SetBool("stretching", false);
            }


            // ========================switches direction player is facing based on movement=============================================
            if (rigidBody.velocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (rigidBody.velocity.x > 0)
            {
                spriteRenderer.flipX = false;
            }

            // ================enables running animation when moving horizontally=====================================================
            anim.SetFloat("moveSpeed", Mathf.Abs(rigidBody.velocity.x));
            anim.SetBool("isGrounded", isGrounded);
        }
        anim.SetFloat("moveSpeed", Mathf.Abs(rigidBody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("drag", rigidBody.drag);
    }

    // =============tethers player position to platform once you land on platform========================================================
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }
    // ============removes connection to platform once you jump off=========================================================
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
