using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownTime : MonoBehaviour
{
    public Timer time;
    public Text textDownNum;
    public Text textDown;
    public int changeColor;

    void Start()
    {
        //textDown = GetComponent<Text>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            time.currentTime -= 10;
            textDownNum.color = Color.red;
            textDownNum.fontSize = 35;
            textDown.color = Color.red;
            textDown.fontSize = 35;
            NormalColor();
            //Destroy(other.gameObject);
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(changeColor);
        textDownNum.color = Color.white;
        textDownNum.fontSize = 27;
        textDown.color = Color.white;
        textDown.fontSize = 27;
    }
    public void NormalColor()
    {
        StartCoroutine(Timer());
        //OcultarPanelDeCarga
    }
}
