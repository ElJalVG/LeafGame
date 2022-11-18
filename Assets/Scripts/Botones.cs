using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.Advertisements;

public class Botones : MonoBehaviour
{
    PlayFabManager playFabManager;
    private void Awake()
    {
        playFabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }
    public void Worlds()
    {
        SceneManager.LoadScene("Worlds");
    }
    public void WorldOne()
    {
        SceneManager.LoadScene("Game");
    }
    public void Missions()
    {
        SceneManager.LoadScene("Missions");
    }
    public void Inventary()
    {
        SceneManager.LoadScene("Inventary");
    }
    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void WorldOneGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("WorldOne");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
