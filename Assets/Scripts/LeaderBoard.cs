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
    public GameObject rowPrefab;
    public Transform rowsParent;

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
    public void GetLeaderboard()
    {
        var request=new GetLeaderboardAroundPlayerRequest{
            StatisticName="Coins",
            MaxResultsCount=10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request,OnLeaderboardAroundPlayerGet,OnError);
    }    
    public void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in result.Leaderboard)
        {
            GameObject newGo=Instantiate(rowPrefab,rowsParent);
            Text[] texts= newGo.GetComponentsInChildren<Text>();
            texts[0].text=(item.Position+5).ToString();
            texts[1].text=item.DisplayName;
            texts[2].text=item.StatValue.ToString();
        }
    }
    
}
