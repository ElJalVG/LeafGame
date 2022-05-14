using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ServerModels;


public class VirtualCurrency : MonoBehaviour
{
    public static VirtualCurrency Instance;
    // Start is called before the first frame update
    void Start()
    {
        AddCurrency(10);//pasarPuntaje
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCurrency(int amount)
    {
        AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest()
        {
            Amount =amount,
            VirtualCurrency="CN",
            PlayFabId=PlayerPrefs.GetString("PlayerFabId")
        };
      PlayFabServerAPI.AddUserVirtualCurrency(request, ResultCallback,ErrorCallback);
    }
    
    private void ErrorCallback(PlayFabError obj){
        Debug.Log(obj.ErrorMessage);
    }
    private void ResultCallback(ModifyUserVirtualCurrencyResult obj){
        Debug.Log("Virtual Currency");
        
    }
    public void ReduceVirtualCurrency()
    {
        SubtractUserVirtualCurrencyRequest request=new SubtractUserVirtualCurrencyRequest()
        {
            Amount =10,
            VirtualCurrency="BS",
            PlayFabId=PlayerPrefs.GetString("PlayerFabId")//PlayerPrefs.GetString("PlayFabId");
        };
        PlayFabServerAPI.SubtractUserVirtualCurrency(request, ResultCallbackVirtual,ErrorCallback);
    }
    
     private void ResultCallbackVirtual(ModifyUserVirtualCurrencyResult obj){
        Debug.Log("CNdescontado, CN actuales"+obj.Balance);
        
    }
}
