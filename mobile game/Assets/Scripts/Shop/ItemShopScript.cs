using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

public class ItemShopScript : MonoBehaviour
{
    public shopScript shopscript;
    public List<shopItem> shopItems = new List<shopItem>();
    public bool speedBoostActive = false;
    public float currentSpeedBoost = 0;
    /*public PlayerMovement playerMovementScript;*/
    // Start is called before the first frame update
    async void Start()
    {

        try
        {
            // Initialize Unity Gaming Services
            await UnityServices.InitializeAsync();
        }
        catch (Exception exception)
        {
            Debug.LogError("an error occured during initialization");
        }


        updateCoinText(); //get ui 

    }

    // Update is called once per frame
    public void BuyItem(int itemIndex)
    {
        shopItem item = shopItems[itemIndex];

        //check if player has enough coins
        if (shopscript.coins >= item.cost)
        {
            shopscript.coins -= item.cost; //deduct cost from coins
            PlayerPrefs.SetInt("totalCoins", shopscript.coins); //save updated coins value
            updateCoinText(); //update ui with new value

            Debug.Log($"purchased {item.itemName} for {item.cost}!!");

            // If this item grants a speed boost, activate the speed boost
            if (item.itemName == "speedboost")
            {
                // Retrieve the current speed from PlayerPrefs (default to 5 if not set)
                float currentSpeed = PlayerPrefs.GetFloat("playerSpeed", 5f);

                // Add the speed boost amount (e.g., 2) to the current speed
                float newSpeed = currentSpeed + item.speedBoostAmount;
                PlayerPrefs.SetFloat("playerSpeed", newSpeed);
                PlayerPrefs.Save();
                Debug.Log($"Speed boost applied. New speed: {newSpeed}");
            }
        }

        else
        {
            Debug.Log("Insufficient Coins D:");
        }
    }
    void updateCoinText()
    {
        shopscript.coinTxt.text = shopscript.coins.ToString();//uipdate coin text

    }
    /*void ApplySpeedBoost(float boostAmount)
    {
        if (playerMovementScript != null)
        {
            playerMovementScript.ApplySpeedBoost(boostAmount);
        }
        else
        {
            Debug.LogWarning("Player movement script not assigned!");
        }
    }*/
}

[Serializable]
public class shopItem
{
    public string itemName;
    public int cost;
    public bool effect; //effect?
    public float speedBoostAmount; //effect multiplier

}