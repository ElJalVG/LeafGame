using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class Catalogo : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject _item;

    // Start is called before the first frame update
    void Start()
    {
        GetCatalog("Skins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCatalog(string name)
    {
        var request = new GetCatalogItemsRequest()
        {
            CatalogVersion = name
        };
        
        PlayFabClientAPI.GetCatalogItems(request, ResultCallback, ErrorCallback);
    }

    private void ErrorCallback(PlayFabError obj)
    {
        Debug.Log(obj.GenerateErrorReport());
    }

    private void ResultCallback(GetCatalogItemsResult obj)
    {
        foreach (var item in obj.Catalog)
        {
            GameObject newItem = Instantiate(_item, _parent.transform);
            Sprite sprite = Resources.Load<Sprite>(item.ItemImageUrl);
            newItem.GetComponent<ItemCatalogo>().SetData((int)item.VirtualCurrencyPrices["CN"], sprite, item);
        }
    }
}
