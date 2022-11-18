using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager instance = null;
    Text txtMessage;
    GameObject panel;
    [SerializeField] int timeLoading;
    public string Player_ID, DisplayName, PlayerSkin;
    public int PlayerWater, PlayerTries;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        panel = transform.Find("CanvasLoading").Find("Panel").gameObject;
        txtMessage = panel.GetComponentInChildren<Text>();
    }
    public void LoadingShow()
    {
        if (!panel.activeInHierarchy)
        {
            panel.SetActive(true);
        }
    }
    public void LoadingHide()
    {
        StartCoroutine(Timer());
        //OcultarPanelDeCarga
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeLoading);
        panel.SetActive(false);
    }
    public void LoadingMessage(string msg)
    {
        LoadingShow();
        txtMessage.text = msg;
    }
}
