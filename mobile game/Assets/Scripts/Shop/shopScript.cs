using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
/*using UnityEditor.PackageManager;*/
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using Unity.Services.Core;

[Serializable]
public class ConsumableItem
{
    public string Name;
    public string Id;
    public string Desc;
    public float price;
}
[Serializable]
public class NonConsumableItem
{
    public string Name;
    public string Id;
    public string Desc;
    public float price;
}
public class shopScript : MonoBehaviour, IDetailedStoreListener
{
    IStoreController storeController;
    public ConsumableItem consItem;
    public NonConsumableItem nonConsItem;


    public TextMeshProUGUI coinTxt;
    public int coins;

    // Start is called before the first frame update
    async void Start()
    {

        try
        {
            // Initialize Unity Gaming Services
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Gaming Services initialized successfully.");
        }
        catch (Exception exception)
        {
            Debug.LogError("Failed to initialize Unity Gaming Services: " + exception.Message);
        }

        coins = PlayerPrefs.GetInt("totalCoins", 0);
        coinTxt.text = coins.ToString();
        SetupBuilder();
    }
    
    public void AddCoins(int amount)
    {
        
        coins += amount;
        PlayerPrefs.SetInt("totalCoins", coins);
        coinTxt.text = coins.ToString();
    }
    void SetupBuilder() //set up builder for IAP data
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(consItem.Id, ProductType.Consumable);
        builder.AddProduct(nonConsItem.Id, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder); //initialize builder (old but still works)
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        print("initialized!");
        storeController = controller;
    }

    public void ConsumablePressed()
    {
        /*AddCoins(50);*/

        storeController.InitiatePurchase(consItem.Id);
        Debug.Log("purchased item!");
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent) //process the purchase
    {
        //get ref of purchased product
        var product = purchaseEvent.purchasedProduct;

        print("transaction complete!" + product.definition.id);

        //distribute rewards of purchase:
        if (product.definition.id == consItem.Id)
        {
            AddCoins(100);
            Debug.Log("Coins added after purchase.");
        }
        else if (product.definition.id == nonConsItem.Id) 
        {
            
        }
         
        return PurchaseProcessingResult.Complete;
    }
    public void NonConsumablePressed()
    {
        /*removeads*/
        
        storeController.InitiatePurchase(consItem.Id);
    }
    //istorelistener callbacks
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        throw new NotImplementedException();
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new NotImplementedException();
    }

    /*public void OnPurchaseFailed(Product product, PurchaseFailureReason error, string message)
    {

    }*/
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {

    }
    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.LogError($"Purchase failed: {failureDescription.productId}, reason: {failureDescription.reason}, message: {failureDescription.message}");
    }

}
