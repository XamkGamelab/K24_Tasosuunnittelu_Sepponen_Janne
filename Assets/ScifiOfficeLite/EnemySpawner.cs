using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 2f; // Interval between spawns
    public int maxEnemies = 10; // Maximum number of enemies to spawn
    public float spawnRadius = 5f; // Radius around the spawner within which enemies can appear

    private float timer; // Timer to keep track of spawning
    private int enemyCount; // Current number of spawned enemies

    void Start()
    {
        timer = spawnInterval; // Initialize timer with the spawn interval
    }

    void Update()
    {
        if (enemyCount >= maxEnemies)
        {
            return; // Stop spawning if the max count is reached
        }

        timer -= Time.deltaTime; // Decrement the timer by the time passed since last frame

        if (timer <= 0)
        {
            SpawnEnemy(); // Time to spawn a new enemy
            timer = spawnInterval; // Reset timer
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + transform.position;
        spawnPosition.y = transform.position.y; // Adjust y coordinate if necessary, depending on your game's requirements

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Spawn an enemy at random position
        enemyCount++; // Increase the count of currently spawned enemies
    }
}
