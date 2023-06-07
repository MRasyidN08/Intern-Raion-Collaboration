using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int FullLife = 4;
    public int livesRemaining;
    private Animator animasi;
    private bool Dead;

    private void Awake()
    {
        livesRemaining = FullLife;
        animasi = GetComponent<Animator>();
    }

    public void LoseLife(int damage)
    {
        livesRemaining = Mathf.Clamp(livesRemaining - damage, 0, FullLife);
        lives[livesRemaining].enabled = false;
        if(livesRemaining > 0){
            animasi.SetTrigger("hurt");
        } else{
            if(!Dead){
                animasi.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                Dead = true;
                StartCoroutine(LoadLoseScene());
            }
        }
    }

    IEnumerator LoadLoseScene()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(9);
    }
}
