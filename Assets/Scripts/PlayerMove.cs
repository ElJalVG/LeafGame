using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Vector2 movement;
    public Animator animator;
    private Vector3 inicialLocateEscale;
    float cX,contador,xSen;
    public float frecuencia, anchoCiclo;
    // Start is called before the first frame update
    void Start()
    {
        inicialLocateEscale=transform.localScale;
     rb=GetComponent<Rigidbody2D>();   
    }
    void FixedUpdate() {
        
        MovePlayer();
    }
    private void MovePlayer()
    {
        if(CheckGround.isGrounded)
        {
contador=contador+(frecuencia/100);
        xSen=Mathf.Sin(contador);
        rb.velocity=new Vector3(transform.position.x,cX+(xSen*anchoCiclo),transform.position.z);
        
        }
        
        /*movement.x=Input.GetAxisRaw("Horizontal");
        spriteRenderer.flipX = movement.x < 0;*/
        if(Input.GetKey("d"))
        {
            rb.velocity=new Vector2(speed,rb.velocity.y);
            transform.localScale=new Vector3(inicialLocateEscale.x,transform.localScale.y,transform.localScale.z);
            animator.SetBool("Caminar",true); 
        }
        else if(Input.GetKey("a"))
        {
            rb.velocity=new Vector2(-speed,rb.velocity.y);
            transform.localScale=new Vector3(-inicialLocateEscale.x,transform.localScale.y,transform.localScale.z);
            animator.SetBool("Caminar",true);
        }
        else
        {
            //quieto
            rb.velocity=new Vector2(0,rb.velocity.y);
            animator.SetBool("Caminar",false);
        }
        if(Input.GetKey("space")&&CheckGround.isGrounded)
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpForce);
            animator.SetBool("Saltar",true);
        }else if(CheckGround.isGrounded)
        {
            animator.SetBool("Saltar",false);
        }
    }
}
