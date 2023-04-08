using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public int currentExp = 0;  // XP saat ini yang dimiliki pemain
    public int expToLevelUp = 100;  // XP yang dibutuhkan untuk naik level
    public int level = 1;  // level saat ini dari pemain

    // Fungsi ini akan dipanggil ketika pemain mendapatkan XP dari musuh yang mati
    public void GainExp(int expValue)
    {
        currentExp += expValue;
        Debug.Log(currentExp);
        // Jika pemain telah mencapai jumlah XP yang dibutuhkan untuk naik level
        if (currentExp >= expToLevelUp)
        {
            LevelUp();  // Naik level
        }
    }

    // Fungsi ini akan dipanggil ketika pemain naik level
    void LevelUp()
    {
        level++;
        currentExp -= expToLevelUp;
        expToLevelUp *= 2;  // Naikkan jumlah XP yang dibutuhkan untuk naik level
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Return))
        GainExp(25);
    }
}
