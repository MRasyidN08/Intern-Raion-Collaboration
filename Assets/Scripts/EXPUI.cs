using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPUI : MonoBehaviour
{
    // [SerializeField]
    // public Image Fillimage;
    // public PlayerstatStat Playerstat;
    // public float expAmount=0f;
    // public float maxExp=1f;
    public Image expBar;  // referensi ke komponen Image yang digunakan untuk menampilkan XP bar
    public TextMeshProUGUI levelText;  // referensi ke komponen teks yang digunakan untuk menampilkan level pemain
    public float expAmount;
    public PlayerStat Playerstat;

//     // Update is called once per frame
//     // public void GainExp(int expValue)
//     // {
//     //     currentExp += expValue;

//     //     // Jika pemain telah mencapai jumlah XP yang dibutuhkan untuk naik level
//     //     if (currentExp >= expToLevelUp)
//     //     {
//     //         LevelUp();  // Naik level
//     //     }
//     // }
    
    public void GainExp(float value)
    {
        expAmount += value;
        Fillimage.fillAmount = expAmount/Playerstat.expToLevelUp;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Return))
        GainExp(25);
    }
}

// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class EXPUI : MonoBehaviour
// {
//     public Image expBar;  // referensi ke komponen Image yang digunakan untuk menampilkan XP bar
//     public TextMeshProUGUI levelText;  // referensi ke komponen teks yang digunakan untuk menampilkan level pemain

//     public PlayerStat Playerstat;  // referensi ke komponen Playerstat pada objek pemain

//     void Start()
//     {
//         Playerstat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>();
//         UpdateUI();
//     }

//     // Fungsi ini dipanggil untuk menambahkan nilai XP pada XP bar dan menampilkan level pemain
//     public void GainExp(int expValue)
//     {
//         Playerstat.GainExp(expValue);
//         UpdateUI();
//     }

//     // Fungsi ini dipanggil untuk memperbarui nilai XP bar dan teks level pemain
//     private void UpdateUI()
//     {
//         // float fillAmount = Playerstat.currentExp / Playerstat.expToLevelUp;
//         expBar.fillAmount = Playerstat.currentExp / Playerstat.expToLevelUp;
//         levelText.text = "Level " + Playerstat.level.ToString();
//     }

