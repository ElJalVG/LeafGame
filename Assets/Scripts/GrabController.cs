using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    private bool _grab;
    public float dropForce;
    private GameObject curretObj;
    public Animator animator;
    
    private void Update() {
        GrabObj();
        
    }
    private void GrabObj()
    {
        if(curretObj != null&&_grab&&Input.GetKeyDown(KeyCode.Q))
        {
            
            curretObj.transform.parent=null;
            curretObj.GetComponent<Rigidbody2D>().isKinematic=false;
            _grab=false;
            Vector2 dir = transform.right*transform.localScale.x + transform.up;
            Debug.Log(dir*dropForce);
            curretObj.GetComponent<Rigidbody2D>().AddForce(dir*dropForce, ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.E)&&curretObj!=null)
        {
            Debug.Log("Press E");
            _grab =!_grab;
            if(_grab)
            {
                //Sujetar
                animator.SetBool("Sujetar",true);
                curretObj.transform.parent=boxHolder;
                curretObj.transform.position=boxHolder.position;
                curretObj.GetComponent<Rigidbody2D>().isKinematic=true;
            }
            else
            {
                animator.SetBool("Sujetar",false);
                curretObj.transform.parent=null;
                curretObj.GetComponent<Rigidbody2D>().isKinematic=false;
            }
        }

        RaycastHit2D grabCheck=Physics2D.Raycast(grabDetect.position,transform.right*transform.localScale.x,rayDist);

        if(grabCheck.collider!=null&&grabCheck.collider.tag=="Box")
        {
          curretObj=grabCheck.collider.gameObject;       
            Debug.Log("BOX");
            
        }
        else{
            curretObj=null;
        }
    }
}
