using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CronometroLevel : MonoBehaviour
{
    bool timerActive=false;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime=startMinutes*60;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive==true)
        {
            currentTime=currentTime-Time.deltaTime;
        }
        currentTimeText.text=currentTime.ToString();
        if(Input.GetKeyDown(KeyCode.T))
        {
            StarTimer();
        }
        if(currentTime<=0)
        {
            timerActive=false;//TiempoLimite
        }
        Debug.Log(currentTime);
    }
    public void StarTimer()
    {
        timerActive=true;
    }
    public void StopTimer()
    {
        timerActive=false;
    }
}
