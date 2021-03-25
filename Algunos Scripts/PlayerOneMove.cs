using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMove : MonoBehaviour
{

    public float runSpeed=2;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;

    private bool canDoubleJump;

    Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public bool betterJump = false;
    
    public float fallMultiplayer = 0.5f;
    public float lowJumpMultiplayer = 1f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }



    public  void Update()
    {
        //Debug.LogError("ASD");
        if (Input.GetKey("space"))
        {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
                animator.SetBool("Jump", true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                if (canDoubleJump)
                {
 
                    animator.SetBool("DoubleJump",true);
                    rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                    canDoubleJump = false;
             
                    }          
                  
            }
        }
            
        }
   

        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("Falling", true);

        }
        else
        {
            if (rb2D.velocity.y >= 0 )
            {
                animator.SetBool("Falling", false);
            }
        }

     

    }


    // Update is called once per frame
    public void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            spriteRenderer.flipX = false;
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
           
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("left"))
        {
            spriteRenderer.flipX = true;
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            animator.SetBool("Run",true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        

        if (betterJump)
        {
            if (rb2D.velocity.y < 0 )
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
            }
        }

        if (rb2D.velocity.y == 0 && rb2D.velocity.x == 0)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Jump", false);
           
        }
    }
}
