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
        if(collision.tag == "Player"){
            collision.GetComponent<LifeCount>().LoseLife(damage);
        }
    }

    public void Die()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject);
    }
}
