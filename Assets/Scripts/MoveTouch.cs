using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouch : MonoBehaviour
{
    //[SerializeField] float moveSpeed=5f;
    Rigidbody2D rb;
    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving=false;
    float previousDistanceToTouchPos, currentDistanceToTouchPos;
    void Start() {
        rb=GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        if (isMoving)
        {
            currentDistanceToTouchPos=(touchPosition-transform.position).magnitude;
        }
    }
}
