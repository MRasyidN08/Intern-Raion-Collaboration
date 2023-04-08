using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] public int HP_Enemies;
    [SerializeField] public int expValue = 10;
    private bool dead;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            collision.GetComponent<LifeCount>().LoseLife();
        }
    }

    public void Die()
    {
        // Mendapatkan objek game player dan komponen EXPUI
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStat exp = player.GetComponent<PlayerStat>();

        // Menambahkan nilai XP ke komponen EXPUI
        if (exp != null)
        {
            exp.GainExp(expValue);
        }
        // Menghancurkan objek musuh
        Destroy(gameObject);
    }
}
