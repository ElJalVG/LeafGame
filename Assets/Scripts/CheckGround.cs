using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;
    public bool grounded = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            grounded = true;
            //isGrounded = true;
            Debug.Log("Colision");
        }
        if (other.CompareTag("Box"))
        {
            grounded = true;
            //isGrounded = true;
            Debug.Log("Colision");
        }

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            grounded = false;
            //isGrounded = false;
            Debug.Log("SinColision");
        }
        if (other.CompareTag("Box"))
        {
            grounded = false;
            //isGrounded = false;
            Debug.Log("SinColision");
        }
    }
}
