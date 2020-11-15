using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Initialize variables
    public ObjectPool obstaclePool;

    // Height of spawn
    public float minSpawnY;
    public float maxSpawnY;

    // Left/Right Spawn
    private float leftSpawnX;
    private float rightSpawnX;

    // rate of spawn
    public float spawnRate;

    // Time between spawns
    private float lastSpawnTime;

    void Start ()
    {
        // Look at left/right bounds of camera
        Camera cam = Camera.main;
        float camWidth = (2.0f * cam.orthographicSize) * cam.aspect;

        leftSpawnX = -camWidth/2;
        rightSpawnX = camWidth/2;


    }

    void Update ()
    {
        // If the spawn has hit a certain time, then we spawn a new one.
        if(Time.time - spawnRate >= lastSpawnTime)
        {
            lastSpawnTime = Time.time;
            SpawnObstacle();
        }
    }

    void SpawnObstacle ()
    {
        // get the obstacle and set it to a gameObject
        GameObject obstacle = obstaclePool.GetPooledObject();

        // set its position
        obstacle.transform.position = GetSpawnPosition();

        // set the obstacle's direction to move
        // ternary operator!
        obstacle.GetComponent<Obstacle>().moveDir = 
            new Vector3(obstacle.transform.position.x > 0 ? -1 : 1, 0, 0);
    }

    // return a random position to spawn
    Vector3 GetSpawnPosition ()
    {
        // Range -> min number is inclusive; max number is exclusive
        // will return 0 or 1
        float x = Random.Range(0,2) == 1 ? leftSpawnX : rightSpawnX;
        float y = Random.Range(minSpawnY, maxSpawnY);

        return new Vector3(x,y,0);
    }
}
