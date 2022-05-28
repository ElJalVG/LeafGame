using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class BuyStore : MonoBehaviour
{
    public int coinsPrice;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyItem(string itemId, int price)
    {
        var request = new PurchaseItemRequest()
        {
            ItemId = itemId,
            CatalogVersion = "Skins",
            Price = price,
            VirtualCurrency = "CN"
        };
        
        PlayFabClientAPI.PurchaseItem(request, ResultCallback, ErrorCallback);

        // var request=new SubtractUserVirtualCurrencyRequest{
        //     VirtualCurrency="CN",
        //     Amount=coinsPrice
        // };
        // PlayFabClientAPI.SubtractUserVirtualCurrency(request,OnSubtractCoinsSucces,OnError);
    }

    private void ErrorCallback(PlayFabError obj)
    {
        Debug.Log(obj.GenerateErrorReport());
    }

    private void ResultCallback(PurchaseItemResult obj)
    {
        Debug.Log("item comprado");
    }

    void OnSubtractCoinsSucces(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Item Comprado!!"+ itemName);
        CurrencyGame.instance.GetVirtualCurrencies();
    }
    void OnError(PlayFabError error)
    {
        Debug.Log(("Error"+error.ErrorMessage));
    }
}
