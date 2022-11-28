using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;

public class Shop : MonoBehaviour
{
    [SerializeField] Text txtWater, txtTries;
    PlayFabManager playFabManager;
    [SerializeField] UIGameScript iugamescript;
    private int waterAmount = 0;
    private int levelTrie = 1;
    // Start is called before the first frame update
    void Awake()
    {
        playFabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
        txtWater.text = playFabManager.PlayerWater.ToString();
        txtTries.text = playFabManager.PlayerTries.ToString();

    }
    public void LeafMexico()
    {
        if (playFabManager.PlayerWater >= 10)
        {
            playFabManager.PlayerWater -= 10;
            txtWater.text = playFabManager.PlayerWater.ToString();
            //PlayFab Sync Data
            PlayerDataTitle("skin", "leafMexico");
            waterAmount = 10;
            SubstractVCWater(waterAmount);
            iugamescript.UpdateWater();
        }
        else
        {
            playFabManager.LoadingMessage("Not enough coins...");
            playFabManager.LoadingHide();
        }
    }
    public void LeafFitnes()
    {
        if (playFabManager.PlayerWater >= 10)
        {
            playFabManager.PlayerWater -= 10;
            txtWater.text = playFabManager.PlayerWater.ToString();
            //PlayFab Sync Data
            PlayerDataTitle("skin", "leafFitnes");
            waterAmount = 10;
            SubstractVCWater(waterAmount);
            iugamescript.UpdateWater();
        }
        else
        {
            playFabManager.LoadingMessage("Not enough coins...");
            playFabManager.LoadingHide();
        }
    }
    public void BuyFiveTries()
    {
        if (playFabManager.PlayerWater >= 50)
        {
            playFabManager.PlayerWater -= 50;
            txtWater.text = playFabManager.PlayerWater.ToString();
            //PlayFab Sync Data
            waterAmount = 50;
            SubstractVCWater(waterAmount);
            iugamescript.UpdateWater();
            iugamescript.Tries += 5;
            iugamescript.UpdateTries();
        }
        else
        {
            playFabManager.LoadingMessage("Not enough coins...");
            playFabManager.LoadingHide();
        }
    }
    public void BuyTenTries()
    {
        if (playFabManager.PlayerWater >= 100)
        {
            playFabManager.PlayerWater -= 100;
            txtWater.text = playFabManager.PlayerWater.ToString();
            //PlayFab Sync Data
            waterAmount = 100;
            SubstractVCWater(waterAmount);
            iugamescript.UpdateWater();
            iugamescript.Tries += 10;
            iugamescript.UpdateTries();
        }
        else
        {
            playFabManager.LoadingMessage("Not enough coins...");
            playFabManager.LoadingHide();
        }
    }

    public void PlayerDataTitle(string key, string keyValue)
    {
        playFabManager.PlayerSkin = keyValue;
        var request = new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {key, keyValue}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, DataSuccess, DataError);
    }
    private void DataSuccess(UpdateUserDataResult result)
    {
        playFabManager.LoadingMessage("Updating Skin Data...");
        playFabManager.LoadingHide();
        //SubstractVCWater(waterAmount);
    }

    private void DataError(PlayFabError error)
    {
        playFabManager.LoadingMessage(error.ErrorMessage);
        playFabManager.LoadingHide();
    }
    public void Home()
    {

        iugamescript.UpdateWater();
        iugamescript.UpdateTries();
        SceneManager.LoadScene("Menu");

    }
    public void SubstractVCWater(int ammount)
    {
        var request = new SubtractUserVirtualCurrencyRequest()
        {
            VirtualCurrency = "WT",
            Amount = ammount
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, SuccesSubtracWater, ErrorSubtract);
    }
    public void SubstractVCTries(int ammount)
    {
        var request = new SubtractUserVirtualCurrencyRequest()
        {
            VirtualCurrency = "TR",
            Amount = ammount
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, SuccesSubtracTries, ErrorSubtract);
    }
    private void SuccesSubtracWater(ModifyUserVirtualCurrencyResult result)
    {
        playFabManager.PlayerWater = result.Balance;
        txtWater.text = playFabManager.PlayerWater.ToString();
        playFabManager.LoadingMessage("Updating Virtual Currency Water...");
        playFabManager.LoadingHide();
    }
    private void SuccesSubtracTries(ModifyUserVirtualCurrencyResult result)
    {
        playFabManager.PlayerTries = result.Balance;
        txtTries.text = playFabManager.PlayerTries.ToString();
        playFabManager.LoadingMessage("Updating Trie Currency...");
        playFabManager.LoadingHide();
    }
    private void ErrorSubtract(PlayFabError error)
    {
        playFabManager.LoadingMessage(error.ErrorMessage);
        playFabManager.LoadingHide();
    }
    public void Game()
    {
        SceneManager.LoadScene("Game");
        if (playFabManager.PlayerTries > 0)
        {
            playFabManager.PlayerTries -= 1;
            txtTries.text = playFabManager.PlayerTries.ToString();
            levelTrie = 1;
            SubstractVCTries(levelTrie);
            iugamescript.UpdateTries();
            SceneManager.LoadScene("Game");
        }
        if (playFabManager.PlayerTries == 0)
        {
            playFabManager.LoadingMessage("You don't have more tries");
            playFabManager.LoadingHide();
        }

    }

}
