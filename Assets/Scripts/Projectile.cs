using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody projectileRigidbody;
    private float currentTime = 1.0f;
    private float totalTime = 1.0f;

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0f) 
        {
            gameObject.SetActive(false);
            currentTime = totalTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            Destroy(enemy.gameObject);
        }
    }
}
