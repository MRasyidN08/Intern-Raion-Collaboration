using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private int pointsForCoin = 1;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameSession>().addCoins(pointsForCoin);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
