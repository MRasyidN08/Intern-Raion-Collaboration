using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_Boss : MonoBehaviour
{
    [SerializeField] public Image Hp_boss;  // referensi ke komponen Image yang digunakan untuk menampilkan XP bar
    [SerializeField] public int HPBoss;
    [SerializeField] public Boss Bosstat;

    private void Start()
    {
        Bosstat = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    public void UpdateUI(int value)
    {
        Hp_boss.fillAmount = value / 100;
    }
}
