using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{
    public List<Projectile> pooledProjectiles;
    public Projectile projectileToPool;
    public int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
        pooledProjectiles = new List<Projectile>(amountToPool);
        for (int i = 0; i < amountToPool; i++)
        {
            Projectile projectile = Instantiate<Projectile>(projectileToPool);
            projectile.gameObject.SetActive(false);
            projectile.transform.SetParent(gameObject.transform);
            pooledProjectiles.Add(projectile);
        }
    }

    public Projectile GetPooledProjectile()
    {
        for (int i = 0; i < pooledProjectiles.Count; i++)
        {
            if (!pooledProjectiles[i].gameObject.activeInHierarchy)
            {
                return pooledProjectiles[i];
            }
        }
        return null;
    }
}
