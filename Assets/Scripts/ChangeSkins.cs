using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkins : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerOne()
    {
        PlayerPrefs.SetString("PlayerSelecionado", "Player1");
        ResetPlayerSkin();
    }
    public void SetPlayerTwo()
    {
        PlayerPrefs.SetString("PlayerSelecionado", "Player2");
        ResetPlayerSkin();
    }
    public void SetPlayerThree()
    {
        PlayerPrefs.SetString("PlayerSelecionado", "Player3");
        ResetPlayerSkin();
    }
    public void SetPlayerFour()
    {
        PlayerPrefs.SetString("PlayerSelecionado", "Player4");
        ResetPlayerSkin();
    }
    public void SetPlayerFive()
    {
        PlayerPrefs.SetString("PlayerSelecionado", "Player5");
        ResetPlayerSkin();
    }
    void ResetPlayerSkin()
    {
        player.GetComponent<PlayerSelect>().ChangeSkins();
    }

}
