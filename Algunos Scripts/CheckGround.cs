using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    public static bool isGrounded;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.CompareTag("Platform"))
        {
            isGrounded = true;
            player.transform.parent = collision.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (collision.CompareTag("Platform"))
        {
            isGrounded = false;
            player.transform.parent = null;
        }
    }
 

}
