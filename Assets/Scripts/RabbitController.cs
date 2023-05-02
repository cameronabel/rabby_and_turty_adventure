using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public SpriteRenderer spriteRenderer;
    public float moveSpeed;
    public float jumpForce;
    public bool activeCharacter;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        if (activeCharacter)
        {
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
            if (theRB.velocity.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (theRB.velocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
        }
    }
}