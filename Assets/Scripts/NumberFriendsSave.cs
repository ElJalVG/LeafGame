using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberFriendsSave : MonoBehaviour
{
    public int Score;
    public int HighScore;
    public string scoretxt;
    public string highscoretxt;

    public void AddScore()
    {
        Score++;
    }
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("Highscore");
        Score = HighScore;
    }
    void Update()
    {
        scoretxt = Score.ToString();
        highscoretxt = HighScore.ToString();
        if (Score > HighScore)
        {
            PlayerPrefs.SetInt("Highscore", Score);
        }
    }
    public void ResetScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }


}
