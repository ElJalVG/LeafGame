using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class RegistroPlayer : MonoBehaviour
{
    [SerializeField] private InputField usernameInputField;
    [SerializeField] private InputField emailInputField;
    [SerializeField] private InputField passwordInputField;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnRegistro()
    {
        RegisterPlayFabUserRequest request =new RegisterPlayFabUserRequest()
        {
            Email=emailInputField.text,
            Username=usernameInputField.text.Replace(" "," "),
            Password=passwordInputField.text,
            TitleId=PlayFabSettings.TitleId,
            DisplayName=usernameInputField.text

        };
        PlayFabClientAPI.RegisterPlayFabUser(request,ResultCallBack,ErrorCallBack);     
        //PlayFabClientAPI.UpdateUserData();
    }
    private void ErrorCallBack(PlayFabError error) {
        {
            Debug.LogError("Here's some debug information:");
            Debug.LogError(error.GenerateErrorReport());
            string message = "";
            if (error.ErrorDetails != null)
 {
    foreach (var i in error.ErrorDetails)
    {
        foreach (var j in i.Value)
        {
            if (j.Contains("Username contains invalid characters"))
            {
                message = message + "El Usuario contiene caracteres inválidos" + "\n";
            }
            else if (j.Contains("Username must be between 3 and 20 characters"))
            {
                message = message + "El Usuario debe tener entre 3 y 20 caracteres" + "\n";
            }
            else if (j.Contains("User name already exists"))
            {
                message = message + "El Usuario no está disponible" + "\n";
            }
            else if (j.Contains("Email address is not valid"))
            {
                message = message + "El Correo no es válido" + "\n";
            }
            else if (j.Contains("Email address already exists"))
            {
                message = message + "El Correo no está disponible" + "\n";
            }
            else if (j.Contains("Password must be between 6 and 100 characters"))
            {
                message = message + "La contraseña debe tener entre 6 y 100 caracteres" + "\n";
            }
            else if (j.Contains("User not found"))
            {
                message = message + "Usuario no encontrado" + "\n";
            }
            Debug.Log("********" + j);
        }
    }
 }
            if (message == "")
             {
               message = "Verifica que todos tus datos esten debidamente llenados e intenta de nuevo";
             }

             //NotificationPanel.Instance.ShowNotification(message);
            
            
        }
    }
    private void ResultCallBack(RegisterPlayFabUserResult result) {
        {
            Debug.Log("registrado");
            //SetUserData();
        }
    }
    /*public void SetUserData()
    {
        //Data extra
        UpdateUserDataRequest request=new UpdateUserDataRequest()
        {
            Data=new Dictionary<string, string>()
            {
                {"Age", ageInputField.text},
                {"City", cityInputField.text}
            }
        };
        PlayFabClientAPI.UpdateUserData(request,ResultCallback,ErrorCallBack);
    }*/

    private void ErrorCallback (PlayFabError obj)
    {
        Debug.Log("Datos NO actualizados");
        //throw new System.NotImplementedException();

    }
    private void ResultCallback(UpdateUserDataResult obj)
    {
        Debug.Log("Datos actualizados");
        //throw new System.NotImplementedException();
    }
}
