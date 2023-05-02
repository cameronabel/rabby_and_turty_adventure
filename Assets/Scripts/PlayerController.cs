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

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        }
    }
}