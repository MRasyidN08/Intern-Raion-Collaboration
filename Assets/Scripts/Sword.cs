using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] float attackDuration = 0.1f;
    private bool isAttacking = false;

    void Start() {

    }
    
    void Update()
    {
        if (!isAttacking)
        {
            StartCoroutine(PerformMeleeAttack());
        }
    }

    IEnumerator PerformMeleeAttack()
    {
        isAttacking = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(attackDuration);
        GetComponent<CapsuleCollider2D>().enabled = false;
        Destroy(gameObject);
        isAttacking = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyStat>().Die();
        }
        if (other.tag == "Boss")
        {
            other.GetComponent<Boss>().takeDamage(10);
        }
    }
}