using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    Rigidbody2D myBody;
    BoxCollider2D myBodyBox;

    [SerializeField] float enemySpeed = 10f;
    
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBodyBox = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Move();
        Flip();
    }

    void Move()
    {
        if (myBodyBox.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            enemySpeed *= -1;
        }
        Vector2 enemyVelocity = new Vector2 (enemySpeed, myBody.velocity.y);
        myBody.velocity = enemyVelocity;
    }

    void Flip()
    {
        bool isMoving = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;

        if (isMoving)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myBody.velocity.x) * -1, 1f);
        }
    }
}
