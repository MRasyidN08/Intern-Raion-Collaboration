using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentSceneIndex = 2;
    
    private void Update() {
        if (currentSceneIndex > 1)
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
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
    
    public void LoadGame()
    {
        SceneManager.LoadScene(2);
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
