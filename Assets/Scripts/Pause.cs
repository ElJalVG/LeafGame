using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
