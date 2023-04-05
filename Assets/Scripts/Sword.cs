using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float attackDuration = 0.5f;
    private bool isAttacking = false;

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
        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(attackDuration);
        GetComponent<Collider2D>().enabled = false;
        isAttacking = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}