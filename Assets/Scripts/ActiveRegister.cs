using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRegister : MonoBehaviour
{
    [SerializeField] GameObject register;
    [SerializeField] GameObject login;

    public void Register()
    {
        register.SetActive(true);
        login.SetActive(false);
    }
    public void BackLogin()
    {
        register.SetActive(false);
        login.SetActive(true);
    }
}
