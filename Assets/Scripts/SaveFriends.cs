using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFriends : MonoBehaviour
{
    /*[SerializeField] LeaderBoard leaderBoard;
    int score;*/
    // Update is called once per frame
    void Update()
    {
        SiguienteEscena();
    }
    public void SiguienteEscena()
    {
        if(transform.childCount==0)
        {
            /*score=100;
            leaderBoard.SendLeaderboard(score);*/
            Debug.Log("TodosLosAmigosRescatados");
        }
    }
}
