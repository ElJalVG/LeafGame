using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Remenber : MonoBehaviour
{
    Toggle rememberToggle;

    void Awake()
    {
        rememberToggle = GameObject.Find("Toggle").GetComponent<Toggle>();
        if (rememberToggle.isOn)
        {
            gameObject.GetComponent<InputField>().text = PlayerPrefs.GetString(gameObject.name);
        }
    }
    public void SaveChange()
    {
        if (rememberToggle.isOn)
        {
            PlayerPrefs.SetString(gameObject.name, transform.Find("Text").GetComponent<Text>().text);
        }
    }
}
