using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public SpriteRenderer spriteRenderer;
    public float moveSpeed;
    public float jumpForce;
    public bool activeCharacter;
    private Collider2D turtleHead;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        turtleHead = GameObject.FindWithTag("TurtleHead").GetComponent<Collider2D>();
        turtleHead.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.ResetTrigger("pullLever");
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
            

            if (Input.GetButtonDown("Fire2"))
            {
                //anim.SetTrigger("pullLever");
                anim.Play("Turtle_GrabLever");
                turtleHead.offset = spriteRenderer.flipX ? new Vector2(-1f, 0) : new Vector2(1f, 0);
                turtleHead.enabled = true;
                
            }
            if (Input.GetButtonUp("Fire2"))
            {
                turtleHead.offset = new Vector2(0, 0);
                turtleHead.enabled = false;
            }
        }
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
    }
}