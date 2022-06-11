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
            LeaderBoard.Instance.SendLeaderboard(10);
            Debug.Log("TodosLosAmigosRescatados");
        }
    }
}
