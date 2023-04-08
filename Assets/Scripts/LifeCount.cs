using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //decrease the value life
        livesRemaining = Mathf.Clamp(livesRemaining - damage, 0, FullLife);
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

    // public void addLife(int value){
    //     livesRemaining = livesRemaining + value;
    //     for(int i = 0; i<=livesRemaining; i++){
    //         lives[i].enabled = true;
    //     }
    //     // lives[livesRemaining].enabled = true;
    // }

    // public void Respawn(){
    //     Dead = false;
    //     addLife(FullLife);
    //     animasi.ResetTrigger("Die");
    //     animasi.Play("Idle Player");
    //     GetComponent<PlayerMovement>().enabled = true;
    // }

}
