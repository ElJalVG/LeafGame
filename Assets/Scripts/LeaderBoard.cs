using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] GameObject Number, Name, Levels;
    PlayFabManager playFabManager;
    void Awake()
    {
        playFabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
        playFabManager.LoadingMessage("Loading Leaderboard...");
        ReadLeaderboard();
    }
    void ReadLeaderboard()
    {
        var request = new GetLeaderboardRequest()
        {
            StatisticName = "water",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, LeaderboardSuccess, LeaderboardError);
    }
    private void LeaderboardError(PlayFabError error)
    {
        playFabManager.LoadingMessage(error.ErrorMessage);
        playFabManager.LoadingHide();
    }
    private void LeaderboardSuccess(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject PrefabNumber = Instantiate(Number, this.transform);
            PrefabNumber.GetComponent<Text>().text = (item.Position + 1).ToString();

            GameObject PrefabName = Instantiate(Name, this.transform);
            PrefabName.GetComponent<Text>().text = item.DisplayName;

            GameObject PrefaLevels = Instantiate(Levels, this.transform);
            PrefaLevels.GetComponent<Text>().text = item.StatValue.ToString();
        }
        playFabManager.LoadingHide();
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");

    }
}
