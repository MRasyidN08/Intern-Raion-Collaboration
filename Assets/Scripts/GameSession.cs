using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    // [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI coins;
    
    // void Awake()
    // {
    //     int numGameSession = FindObjectOfType<GameSession>().Length;
    //     if (numGameSession > 1)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    void Start() {
        coins.text = score.ToString();
    }

    public void addCoins(int points)
    {
        score += points;
        coins.text = score.ToString();
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
