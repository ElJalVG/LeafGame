using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        SceneManager.LoadScene("WorldOne");
    }
    public void Game()
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
