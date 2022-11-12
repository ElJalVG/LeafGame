using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour
{
    public Text coinsText;
    public Text trysText;

    // Update is called once per frame
    void Update()
    {
        coinsText.text=PlayerPrefs.GetInt("Coins").ToString();
        trysText.text=PlayerPrefs.GetInt("Trys").ToString();
    }
}
