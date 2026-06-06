using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRate = 1.5f;
    float minY = 1.5f;
    float maxY = 4f;
    float nextSpawn = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            SpawnEnemy();
            nextSpawn = Time.time + spawnRate;
        }
    }
    void SpawnEnemy()
    {
        bool spawnFromLeft = Random.value > 0.5f;
        float spawnX = spawnFromLeft ? -3f : 3f;
        float spawnY = Random.Range(minY, maxY);
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(spawnX, spawnY, 0f), Quaternion.Euler(0f, 180f, 0f));
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.moveRight = spawnFromLeft;
        }
    }
}
