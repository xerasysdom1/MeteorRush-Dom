using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    float spawnRate = 4f;
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
            SpawnMeteor();
            nextSpawn = Time.time + spawnRate;
        }
    }

    void SpawnMeteor()
    {
        float spawnX = Random.Range(-3f, 3f);
        Instantiate(meteorPrefab, new Vector3(spawnX, -6f, 0f), Quaternion.Euler(0f, 180f, 0f));
    }
}
