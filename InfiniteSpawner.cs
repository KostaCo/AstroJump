using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : MonoBehaviour
{
    public Transform player;
    [SerializeField] GameObject[] asteroidPrefabs;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    [SerializeField] float spawnDistance = 15f;  
    [SerializeField] float despawnDistance = 5f; 
    [SerializeField] int spawnThreshold = 5;      

    private List<GameObject> spawnedAsteroids = new List<GameObject>();
    private float lastSpawnY = 0f;

    void Update()
    {
        if (player.position.y >= Mathf.Max(10, ScoreUpdate.scoreValue) && player.position.y >= lastSpawnY + 10)
        {
            Debug.Log("if 1");
            float spawnY = player.position.y + spawnDistance;
            Vector3 position = new Vector3(Random.Range(minTras + player.position.x, maxTras + player.position.x), spawnY, 0);

            GameObject asteroid = Instantiate(
                asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)],
                position,
                Quaternion.Euler(0, 0, Random.Range(0f, 360f))
            );

            spawnedAsteroids.Add(asteroid);

            position = new Vector3(Random.Range(minTras + player.position.x, maxTras + player.position.x), spawnY + 3, 0);

            asteroid = Instantiate(
                asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)],
                position,
                Quaternion.Euler(0, 0, Random.Range(0f, 360f))
            );

            spawnedAsteroids.Add(asteroid);

            position = new Vector3(Random.Range(minTras - 15 + player.position.x, maxTras + player.position.x - 15), spawnY + 3, 0);

            asteroid = Instantiate(
                asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)],
                position,
                Quaternion.Euler(0, 0, Random.Range(0f, 360f))
            );

            spawnedAsteroids.Add(asteroid);

            position = new Vector3(Random.Range(minTras - 15 + player.position.x, maxTras + player.position.x - 15), spawnY, 0);

            asteroid = Instantiate(
                asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)],
                position,
                Quaternion.Euler(0, 0, Random.Range(0f, 360f))
            );

            spawnedAsteroids.Add(asteroid);

            position = new Vector3(Random.Range(minTras + 15 + player.position.x, maxTras + player.position.x + 15), spawnY + 3, 0);

            asteroid = Instantiate(
                asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)],
                position,
                Quaternion.Euler(0, 0, Random.Range(0f, 360f))
            );

            spawnedAsteroids.Add(asteroid);

            position = new Vector3(Random.Range(minTras + 15 + player.position.x, maxTras + player.position.x + 15), spawnY, 0);

            asteroid = Instantiate(
                asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)],
                position,
                Quaternion.Euler(0, 0, Random.Range(0f, 360f))
            );

            spawnedAsteroids.Add(asteroid);
        }

        for (int i = spawnedAsteroids.Count - 1; i >= 0; i--)
        {
            if (spawnedAsteroids[i] == null) continue;

            if (player.position.y - spawnedAsteroids[i].transform.position.y > despawnDistance)
            {
                Destroy(spawnedAsteroids[i]);
                spawnedAsteroids.RemoveAt(i);
            }
        }
        if (lastSpawnY + 10 < player.position.y)
        {
            lastSpawnY = player.position.y;
        }
    }
}
