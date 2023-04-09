using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Unit
{
    public Rigidbody playerRigidbody;
    public ProjectilePooler projectilePooler;

    void Start()
    {
        speed = 20;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Shoot();
    }

    protected override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontalInput);
        playerRigidbody.AddRelativeForce(Vector3.forward * verticalInput * speed);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Projectile projectile = projectilePooler.GetPooledProjectile();
            if (projectile is not null)
            {
                float spawnDistance = 2.0f;
                projectile.gameObject.SetActive(true);
                projectile.projectileRigidbody.velocity *= 0f;
                projectile.projectileRigidbody.angularVelocity *= 0f;
                projectile.transform.position = transform.position + transform.forward * spawnDistance;

                projectile.projectileRigidbody.AddForce(transform.forward * 100.0f, ForceMode.Impulse);
            }
        }
    }
}
