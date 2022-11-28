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
    [SerializeField] SoundManager soundManager;
    PlayFabManager playFabManager;
    [SerializeField] GameObject volumen;
    [SerializeField] GameObject pausa;
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
    public void ActivateVolume()
    {
        volumen.SetActive(true);
        soundManager.Load();
    }
    public void ActivateFalseVolume()
    {
        volumen.SetActive(false);
        soundManager.Save();
    }
    public void ActivateinGame()
    {
        volumen.SetActive(true);
        pausa.SetActive(false);
        soundManager.Load();
    }
    public void ActivateFalseinGame()
    {
        volumen.SetActive(false);
        pausa.SetActive(true);
        soundManager.Save();
    }
}
