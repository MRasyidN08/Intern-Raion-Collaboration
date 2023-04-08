using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeapon : MonoBehaviour
{
    private int riffleBought = 0;
    int rifflePrice = 10;

    void Awake()
    {
        riffleBought = PlayerPrefs.GetInt("riffle");
    }
    
    public void buyWeapon()
    {
        if (PlayerPrefs.GetInt("coinKey") < rifflePrice || riffleBought == 1)
        {
            return;
        }
        int coinsAfter = PlayerPrefs.GetInt("coinKey") - rifflePrice;
        PlayerPrefs.SetInt("coinKey", coinsAfter);
        PlayerPrefs.SetInt("riffle", 1);
    }
}