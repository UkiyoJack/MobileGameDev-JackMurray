using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopScript : MonoBehaviour
{
    public shopScript shopscript;
    public List<shopItem> shopItems = new List<shopItem>();
    // Start is called before the first frame update
    void Start()
    {
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
}
[Serializable]
public class shopItem
{
    public string itemName;
    public int cost;
}