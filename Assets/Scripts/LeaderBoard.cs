using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{
    public static LeaderBoard Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error en su cuenta");
        Debug.Log(error.GenerateErrorReport());
    }   
    public void SendLeaderboard(int score)
    {
        var request=new UpdatePlayerStatisticsRequest{
            Statistics =new List<StatisticUpdate>{
                new StatisticUpdate {
                    StatisticName="Coins",
                    Value=score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnleaderboardUpdate,OnError);
    }
    void OnleaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard Enviado");
    }
}
