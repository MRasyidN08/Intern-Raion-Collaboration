using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private int damage=1;
    [SerializeField] public int HP_Enemies;
    [SerializeField] public int expValue = 10;
    private bool dead;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Memberikan damage ke player
        if(collision.tag == "Player"){
            collision.GetComponent<LifeCount>().LoseLife(damage);
        }
    }

    public void Die()
    {
        // Mendapatkan objek game player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStat exp = player.GetComponent<PlayerStat>();

        // Menambahkan nilai XP
        exp.GainExp(expValue);
        
        // Menghancurkan objek musuh
        Destroy(gameObject);
    }
}
