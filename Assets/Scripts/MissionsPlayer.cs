using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionsPlayer : MonoBehaviour
{
    [SerializeField] NumberFriendsSave numberFriendsSave;
    public Image missionImage;
    public Image waterImage;
    public Text missionText;
    void Update()
    {
        if (numberFriendsSave.Score >= 1)
        {
            missionImage.color = Color.Lerp(Color.white, Color.black, 0.6f);
            missionText.color = Color.Lerp(Color.white, Color.black, 0.6f);
            waterImage.color = Color.Lerp(Color.white, Color.black, 0.6f);
        }
    }
}
