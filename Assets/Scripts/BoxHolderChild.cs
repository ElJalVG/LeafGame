using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHolderChild : MonoBehaviour
{
    public GrabOnly grabOnly;
    public float timerNoSujetar = 2f;
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0 && grabOnly.holder == true)
        {
            Debug.Log("NoHayCaja");
            StartCoroutine(NoSujetar());
            Debug.Log(timerNoSujetar);

        }
        if (transform.childCount > 1)
        {
            grabOnly.holder = true;
        }
    }
    IEnumerator NoSujetar()
    {
        yield return new WaitForSeconds(timerNoSujetar);
        if (transform.childCount == 0 && grabOnly.holder == true)
        {
            grabOnly.holder = false;
        }
    }
    public void SujetarFalso()
    {
        StartCoroutine(NoSujetar());
    }
}
