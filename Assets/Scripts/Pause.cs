using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject opcionsPanel;
    public void PanelesOpciones()
    {
        Time.timeScale = 0;//Para el tiempo
        opcionsPanel.SetActive(true);
    }
    public void Return()
    {
        Time.timeScale = 1;
        opcionsPanel.SetActive(false);
    }
    public void BackToWorlds()
    {
        SceneManager.LoadScene("Worlds");
    }
}
