using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    public int currentCoins = 0;
    [SerializeField] TextMeshProUGUI coins;

    public void Start() {
        coins.text = currentCoins.ToString();
        currentCoins = PlayerPrefs.GetInt("coinKey");
    }
 
    public void Awake() {
        coins.text = currentCoins.ToString();
        currentCoins = PlayerPrefs.GetInt("coinKey");
    }

    private void Update() {
        coins.text = currentCoins.ToString();
        currentCoins = PlayerPrefs.GetInt("coinKey");
    }

    public void addCoins(int points)
    {
        currentCoins += points;
        PlayerPrefs.SetInt("coinKey", currentCoins);
        coins.text = currentCoins.ToString();
    }

//     public void ProcessPlayerDeath()
//     {
//         if (playerLives > 1)
//         {
//             TakeLife();
//         }
//         else
//         {
//             ResetGameSession();
//         }
//     }

//     void TakeLife()
//     {
//         playerLives--;

//     }

//     void ResetGameSession()
//     {
//         SceneManager.LoadScene(0);
//         Destroy(gameObject);
//     }
}
