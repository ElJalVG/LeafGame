using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class User : MonoBehaviour
{
    [SerializeField] InputField email, password, username;
    [SerializeField] PlayFabManager playFabManager;
    public void RegisterPlayer()
    {
        playFabManager.LoadingMessage("Conecting server...");
        var request = new RegisterPlayFabUserRequest()
        {
            Email = email.text,
            Password = password.text,
            Username = username.text,
            DisplayName = username.text

        };
        PlayFabClientAPI.RegisterPlayFabUser(request, ResultCallBack, ErrorCallback);
    }
    private void ResultCallBack(RegisterPlayFabUserResult result)
    {
        playFabManager.LoadingMessage("Register Successfull...");
        InitStat();

    }
    //CREAR STATISTIC
    private void InitStat()
    {
        var request = new UpdatePlayerStatisticsRequest()
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate{StatisticName="tries", Value=0}
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, InitSuccess, ErrorCallback);
    }
    //------------------------------------

    private void InitSuccess(UpdatePlayerStatisticsResult result)
    {
        playFabManager.LoadingMessage("Register Successfull...");
        playFabManager.LoadingHide();
    }

    private void LoginResultCallBack(LoginResult success)
    {
        playFabManager.LoadingMessage("Login Successfull");
        playFabManager.Player_ID = success.PlayFabId;
        playFabManager.LoadingHide();
        //Get Display Name
        GetPlayerName();
    }
    void GetPlayerName()
    {
        playFabManager.LoadingMessage("Loading Display...");
        var request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, InfoSuccess, ErrorCallback);
        GetBalanceWater();
        GetBalanceTries();
    }

    private void InfoSuccess(GetAccountInfoResult result)
    {
        playFabManager.DisplayName = result.AccountInfo.Username;
        //Other Data
        playFabManager.LoadingHide();
        //Read Statistics score
        //ReadStatScore();
    }

    private void ErrorCallback(PlayFabError obj)
    {
        playFabManager.LoadingMessage(obj.ErrorMessage);
        playFabManager.LoadingHide();
    }
    public void PlayerLogin()
    {
        playFabManager.LoadingMessage("Conecting server...");
        var request = new LoginWithEmailAddressRequest()
        {
            Password = password.text,
            Email = email.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginResultCallBack, ErrorCallback);
    }
    public void ReadStatScore()
    {
        playFabManager.LoadingMessage("Loading Statistics...");
        var request = new GetPlayerStatisticsRequest();
        PlayFabClientAPI.GetPlayerStatistics(request, SuccesStat, ErrorCallback);
    }
    private void SuccesStat(GetPlayerStatisticsResult result)
    {
        playFabManager.PlayerTries = result.Statistics[0].Value;
        playFabManager.LoadingMessage("Loading Profil SuccessFull...");
    }
    //VIRTUAL CURRENCY WATER
    public void GetBalanceWater()
    {
        var request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request, InvetorySuccesWater, InventoryError);
    }
    private void InvetorySuccesWater(GetUserInventoryResult result)
    {
        foreach (var item in result.VirtualCurrency)
        {
            if (item.Key == "WT")
            {
                playFabManager.PlayerWater = item.Value;
            }
        }
        playFabManager.LoadingMessage("Loading water successfull");
        playFabManager.LoadingHide();
        LoadMenu();
        GetSkin();
    }
    //-----------------------------
    // VIRTUAL CURRENCY TRIES
    public void GetBalanceTries()
    {
        var request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request, InvetorySuccesTries, InventoryError);
    }
    private void InvetorySuccesTries(GetUserInventoryResult result)
    {
        foreach (var item in result.VirtualCurrency)
        {
            if (item.Key == "TR")
            {
                playFabManager.PlayerTries = item.Value;
            }
        }
        playFabManager.LoadingMessage("Loading Tries successfull");
        playFabManager.LoadingHide();
        LoadMenu();
        GetSkin();
    }
    //-----------------------------
    private void InventoryError(PlayFabError error)
    {
        playFabManager.LoadingMessage(error.ErrorMessage);
        playFabManager.LoadingHide();
    }

    //--------------------------
    public void GetSkin()
    {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, SuccessSkin, ErrorSkin);
    }

    private void ErrorSkin(PlayFabError error)
    {
        playFabManager.LoadingMessage(error.ErrorMessage);
        playFabManager.LoadingHide();
    }
    private void SuccessSkin(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("skin"))
        {
            playFabManager.LoadingMessage("Login Successfull");
            playFabManager.LoadingHide();
            playFabManager.PlayerSkin = "leafBigote";
            LoadMenu();
        }
        else if (result.Data.ContainsKey("skin"))
        {
            playFabManager.PlayerSkin = result.Data["skin"].Value;
            playFabManager.LoadingMessage("Login Successfull...");
            LoadMenu();
        }
    }
    public void LoadMenu()
    {
        playFabManager.LoadingHide();
        SceneManager.LoadScene("Menu");
    }
}
