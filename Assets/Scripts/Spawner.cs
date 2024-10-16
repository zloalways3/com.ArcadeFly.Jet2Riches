using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject[] spherePrefabs;
    
    private const float SpawnInterval = 0.4f; 
    private const int CoinSpawnChance = 50; 

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, SpawnInterval);
    }

    private void SpawnObject()
    {
        if (IsCoinSpawned())
        {
            SpawnCoin();
        }
        else
        {
            SpawnSphere();
        }
    }

    private bool IsCoinSpawned()
    {
        return Random.Range(0, 100) < CoinSpawnChance;
    }

    private void SpawnCoin()
    {
        GameObject coin = Instantiate(coinPrefab, GetRandomPosition(), Quaternion.identity);
        coin.transform.parent = transform.parent;
    }

    private void SpawnSphere()
    {
        GameObject sphere = Instantiate(spherePrefabs[Random.Range(0, spherePrefabs.Length)], GetRandomPosition(), Quaternion.identity);
        sphere.transform.parent = transform.parent;
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        return new Vector3(x, y, 0);
    }
}