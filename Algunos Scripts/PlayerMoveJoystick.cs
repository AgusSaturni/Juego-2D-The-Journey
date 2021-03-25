using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{

    private float horizontalMove = 0f;              //Para movimiento de joystick
    private float verticalMove = 0f;
    public Joystick joystick;



    public float runSpeedHorizontal = 2;

    public float runSpeed = 1.25f;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;

    private bool canDoubleJump;

    Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;


    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }



    public void Update()
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        { 
            animator.SetBool("Run", false);
        }



        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("Falling", true);

        }
        else
        {
            if (rb2D.velocity.y >= 0)
            {
                animator.SetBool("Falling", false);
            }
        }



    }


    // Update is called once per frame
    public void FixedUpdate()
    {

        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;


   

        if (rb2D.velocity.y == 0 && rb2D.velocity.x == 0)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Jump", false);

        }
    }

    public void Jump()
    {

        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            animator.SetBool("Jump", true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);

        }
        else
        {
            if (canDoubleJump)
            {

                animator.SetBool("DoubleJump", true);
                rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;

            }


        }
    }
}
