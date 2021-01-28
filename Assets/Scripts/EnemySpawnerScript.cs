using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public float timeToSpawn;
    public int chanceToSpawnShooting;
    public GameObject enemy1;
    public GameObject enemy2;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + Random.Range(-3.0f, 3.0f));

            System.Random rand = new System.Random();
            int spawnRand = rand.Next(1, 101);
            if(spawnRand <= chanceToSpawnShooting)
            {
                Instantiate(enemy2, newPosition, transform.rotation);
            }
            else
            {
                Instantiate(enemy1, newPosition, transform.rotation);
            }

            
            timer = timeToSpawn;
        }
    }
}
