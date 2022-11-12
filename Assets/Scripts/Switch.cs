using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] bool isDoorOpenSwitch;
    [SerializeField] bool isDoorCloseSwitch;
    float switchSizeY;
    Vector3 switchUpPos;
    Vector3 switchDownPos;
    float switchSpeed = 1f;
    float switchDelay = 0.2f;
    bool isPressingSwitch = false;
    void Awake()
    {
        /*switchSizeY = transform.localScale.y / 2;
        switchUpPos = transform.position;
        switchDownPos = new Vector3(transform.position.x, transform.position.y - switchSizeY, transform.position.z);*/
    }
    // Update is called once per frame
    /*void Update()
    {
        if (isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else if (!isPressingSwitch)
        {
            MoveSwitchUp();
        }
    }
    public void MoveSwitchDown()
    {
        if (transform.position != switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, switchDownPos, switchSpeed * Time.deltaTime);
        }
    }
    public void MoveSwitchUp()
    {
        if (transform.position != switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, switchUpPos, switchSpeed * Time.deltaTime);
        }
    }*/
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            isPressingSwitch = !isPressingSwitch;
            if (isDoorOpenSwitch && !door.isDoorOpen)
            {
                door.isDoorOpen = !door.isDoorOpen;
            }
            else if (isDoorCloseSwitch && door.isDoorOpen)
            {
                door.isDoorOpen = !door.isDoorOpen;
            }
        }
    }*/
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            door.isDoorOpen = false;
            Debug.Log("Cerrado");
            StartCoroutine(SwitchUpDelay(switchDelay));
        }
    }
    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isPressingSwitch = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            door.isDoorOpen = true;
            Debug.Log("Abierto");
        }
    }
}
