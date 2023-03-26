using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
   public Image[] lives;
   public int livesRemaining;

   public void LoseLife()
   {
        //if livesRemaining 0 do nothing
        if(livesRemaining==0)
            return;
        //decrease the value life
        livesRemaining--;
        //hiding one image of life count
        lives[livesRemaining].enabled = false;

        //if we run out the lives
        if(livesRemaining == 0){
            Debug.Log("You Lost");
        }
   }

   private void Update()
   {
        if(Input.GetKeyDown(KeyCode.Return))
            LoseLife();
   }
}
