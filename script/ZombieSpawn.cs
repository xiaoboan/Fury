using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject zombie;
    public int numOfZombies;
    public float timeBetweenSpawn;

    private float nextSpawnTime;
    // Start is called before the first frame update
    void SpawnZombie()
    {
        int randonNumber = Random.Range(0, spawnPoint.Length);
        if (zombie != null)
        {
            Instantiate(zombie, spawnPoint[randonNumber].position, spawnPoint[randonNumber].rotation);
            
        }

        nextSpawnTime = Time.time + timeBetweenSpawn;

    }

    // Update is called once per frame
    void Update()
    {
  
            if (Time.time > nextSpawnTime)
            {
                for (int i = 0; i < numOfZombies; i++)
                {
                    SpawnZombie();
                }
            }
        
    }
}
