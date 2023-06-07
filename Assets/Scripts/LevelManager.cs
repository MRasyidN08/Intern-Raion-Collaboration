using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentSceneIndex = 3;
    
    // private void Update() {
    //     if (SceneManager.GetActiveScene().buildIndex > 1)
    //     {
    //         currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     }
    // }

    void Start() {
        if (SceneManager.GetActiveScene().buildIndex >= 3 && SceneManager.GetActiveScene().buildIndex < 8)
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("scene", currentSceneIndex);
        }
    }

    public void LoadScene() {
        SceneManager.LoadScene(PlayerPrefs.GetInt("scene"));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(2);
    }
    
    public void SkipCutscene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(6);
    }
    
    public void GoToShop()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }
}
