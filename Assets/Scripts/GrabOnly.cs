using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOnly : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public bool holder = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, transform.right * transform.localScale.x, rayDist);
        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (holder == true)
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            if (holder == false)
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
    public void Sujetar()
    {
        holder = true;
    }
    public void Soltar()
    {
        holder = false;
    }

}
