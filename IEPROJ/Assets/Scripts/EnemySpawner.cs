using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float randPosition;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randPosition = Random.Range(0, 4);
            switch (randPosition)
            {
                case 0: whereToSpawn = new Vector2(-10, 3.5f); break; //top left spawn
                case 1: whereToSpawn = new Vector2(10, 3.5f); break; // top right spawn
                case 2: whereToSpawn = new Vector2(-10, -3.5f); break; // bot left
                case 3: whereToSpawn = new Vector2(10, -3.5f); break; // bot right
            }
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
