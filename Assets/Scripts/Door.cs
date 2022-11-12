using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isDoorOpen = false;
    Vector3 doorClosePos;
    Vector3 doorOpenPos;
    public float doorSpeed = 10f;
    public float doorUpY;

    void Awake()
    {
        doorClosePos = transform.position;
        doorOpenPos = new Vector3(transform.position.x, transform.position.y + doorUpY, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDoorOpen)
        {
            OpenDoor();
        }
        if (isDoorOpen == false)
        {
            CloseDoor();
        }
    }
    public void OpenDoor()
    {
        if (transform.position != doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, doorSpeed * Time.deltaTime);
        }
    }
    public void CloseDoor()
    {
        if (transform.position != doorClosePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosePos, doorSpeed * Time.deltaTime);
        }

    }
}
