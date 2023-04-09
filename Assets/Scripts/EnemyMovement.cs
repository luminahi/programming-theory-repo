using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Unit
{
    public PlayerControl player;
    public Rigidbody enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(direction * speed);
    }
}
