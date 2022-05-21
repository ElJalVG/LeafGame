using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLogin : MonoBehaviour
{
    [SerializeField] private InputField usernameInputField;
    [SerializeField] private InputField passwordInputField;
    public Text coinsText;
    public Text trysText;
    int coins;
    int trys;
    public void OnLogin()
    {
        LoginWithPlayFabRequest request=new LoginWithPlayFabRequest()
        {
            Username=usernameInputField.text.Replace(" "," "),
            Password=passwordInputField.text,
            TitleId=PlayFabSettings.TitleId
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnResultCallback,ErrorCallBack);       

    }
    private void ErrorCallBack(PlayFabError error)
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
        private void OnResultCallback(LoginResult obj)
        {
            PlayerPrefs.SetString("PlayerFabId",obj.PlayFabId);
            SceneManager.LoadScene("Game");
            GetVirtualCurrencies();
            Debug.Log("Inicio de sesion correcto");
        }
        public void GetVirtualCurrencies()
        {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(),OnGetInventorySucces,OnError);
        }
        public void OnGetInventorySucces(GetUserInventoryResult result)
            {
                coins=result.VirtualCurrency["CN"];
                coinsText.text=coins.ToString();

                trys=result.VirtualCurrency["RT"];
                trysText.text=trys.ToString();
            }
        public void OnError(PlayFabError error)
        {
        Debug.Log("Error"+error.ErrorMessage);
        }
}
