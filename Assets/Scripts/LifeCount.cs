using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    public PlayerStat player;
    private Animator animasi;
    private bool Dead;

    private void Awake()
    {
        animasi = GetComponent<Animator>();
    }

    public void LoseLife()
    {
        //decrease the value life
        livesRemaining--;
        //hiding one image of life count
        lives[livesRemaining].enabled = false;
        //if we run out the lives
        if(livesRemaining > 0){
            animasi.SetTrigger("hurt");
        } else{
            if(!Dead){
            animasi.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
            Dead = true;
            }
        }
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Enemy")
    //     {
    //         LoseLife();
            
    //     }
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)){
            LoseLife();
        }
    }

}
