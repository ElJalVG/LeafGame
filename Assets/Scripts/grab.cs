using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance=2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(!grabbed)
            {
                hit=Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);
            }
            else{

            }
        }

        

    }
        
}
