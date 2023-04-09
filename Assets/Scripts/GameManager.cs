using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyMovement enemy;
    public PlayerControl player;
    private int waveNumber = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < waveNumber; i++) 
            {
                var enemyInstance = Instantiate(enemy, RandomPosition(), transform.rotation);
                enemyInstance.player = player;
            }
            yield return new WaitForSeconds(4);
            waveNumber++;
        }
    }

    private Vector3 RandomPosition()
    {
        float randomX = Random.Range(-10.0f, 20.0f);
        float randomZ = Random.Range(-18.0f, 16.0f);
        return new Vector3(randomX, 8.0f, randomZ);
    }
}
