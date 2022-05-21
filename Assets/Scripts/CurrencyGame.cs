using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine.UI;

public class CurrencyGame : MonoBehaviour
{
    public static CurrencyGame instance;
    public Text coinsText;
    public Text trysText;
    private void Awake() {
        instance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(),OnGetInventorySucces,OnError);
    }
    public void OnGetInventorySucces(GetUserInventoryResult result)
    {
        int coins=result.VirtualCurrency["CN"];
        coinsText.text=coins.ToString();

        int trys=result.VirtualCurrency["RT"];
        trysText.text=trys.ToString();
    }
    public void OnError(PlayFabError error)
    {
        Debug.Log("Error"+error.ErrorMessage);
    }
}
