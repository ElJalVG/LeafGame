using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFriends : MonoBehaviour
{
    void Update()
    {
        SiguienteEscena();
    }
    public void SiguienteEscena()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("TodosLosAmigosRescatados");
            SceneManager.LoadScene("Menu");

        }
    }
}
