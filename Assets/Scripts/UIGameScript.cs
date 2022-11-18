using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class UIGameScript : MonoBehaviour
{
    [SerializeField] Text texWater, texTries;
    PlayFabManager playFabManager;
    private int InitWater, InitTries;
    private int water;
    public int Water
    {
        get { return water; }
        set
        {
            water = value;
            texWater.text = water.ToString();
        }
    }
    private int tries;
    public int Tries
    {
        get { return tries; }
        set
        {
            tries = value;
            texTries.text = tries.ToString();
        }
    }
    void Awake()
    {
        playFabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
        Water = playFabManager.PlayerWater;
        Tries = playFabManager.PlayerTries;
        InitWater = Water;
        InitTries = Tries;
    }
    //actualizar INFORMACION 
    public void UpdatePlayFabManagerInfo()
    {
        playFabManager.PlayerWater = Water;//ACTUALIZAR WATER
        playFabManager.PlayerTries = Tries;
    }
    //-----------
    /*public void Home()
    {
        //Update Score
        playFabManager.LoadingMessage("Updating data...");
        UpdatePlayFabManagerInfo();
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate{StatisticName="water", Value=Water}
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, SuccesUpdate, ErrorUpdate);
    }*/

    private void SuccesUpdate(UpdatePlayerStatisticsResult result)
    {
        UpdateWater();
    }
    private void ErrorUpdate(PlayFabError error)
    {
        playFabManager.LoadingMessage(error.ErrorMessage);
        playFabManager.LoadingHide();
    }
    //ACTULIZAR WATER
    public void UpdateWater()
    {
        AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest();
        request.VirtualCurrency = "WT";
        request.Amount = Water - InitWater;
        PlayFabClientAPI.AddUserVirtualCurrency(request, UpdateWaterSuccess, UpdateCoinsError);
    }
    public void UpdateTries()
    {
        AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest();
        request.VirtualCurrency = "TR";
        request.Amount = Tries - InitTries;
        PlayFabClientAPI.AddUserVirtualCurrency(request, UpdateTriesSuccess, UpdateCoinsError);
    }

    private void UpdateCoinsError(PlayFabError error)
    {
        playFabManager.LoadingMessage(error.ErrorMessage);
        playFabManager.LoadingHide();

    }
    private void UpdateWaterSuccess(ModifyUserVirtualCurrencyResult result)
    {
        playFabManager.LoadingMessage("Update Water");
        playFabManager.LoadingHide();
        UpdatePlayFabManagerInfo();
    }
    private void UpdateTriesSuccess(ModifyUserVirtualCurrencyResult result)
    {
        playFabManager.LoadingMessage("Update Tries");
        playFabManager.LoadingHide();
        UpdatePlayFabManagerInfo();
    }
    //----------------------------------
}
