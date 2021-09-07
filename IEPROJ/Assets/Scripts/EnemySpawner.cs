using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float randPosition;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    public float totalSpawn = 15;
    private int spawnCount = 0;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn && spawnCount < totalSpawn)
        {
            spawnCount++;
            nextSpawn = Time.time + spawnRate;
            randPosition = Random.Range(0, 4);
            switch (randPosition)
            {
                case 0: whereToSpawn = new Vector2(-20, 3.5f); break; //top left spawn
                case 1: whereToSpawn = new Vector2(20, 3.5f); break; // top right spawn
                case 2: whereToSpawn = new Vector2(-20, -3.5f); break; // bot left
                case 3: whereToSpawn = new Vector2(20, -3.5f); break; // bot right
            }
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
        else if(spawnCount == totalSpawn)
        {
            StartCoroutine("Spawner");
        }
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(3);
        spawnCount = 0;
    }
}
