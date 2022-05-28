using System.Collections;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class ItemCatalogo : MonoBehaviour
{
    private CatalogItem _currentItem;
    [SerializeField] private Text _priceText;
    [SerializeField] private Image _previewImage;
    private BuyStore _buyStore;
    
    public void SetData(int price, Sprite preview, CatalogItem item)
    {
        _priceText.text = price.ToString();
        _previewImage.sprite = preview;
        _currentItem = item;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _buyStore = GetComponent<BuyStore>();
    }

    public void BuyThisItem()
    {
        _buyStore.BuyItem(_currentItem.ItemId, (int)_currentItem.VirtualCurrencyPrices["CN"]);
    }
}
