using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 30;
    private float startDelay = 2;
    public float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, 1 / spawnInterval);
    }


    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
        //Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation); // fixed rotation

        float randomY = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(0f, randomY, 0f); // random rotation around the Y-axis

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, randomRotation);
    }
}

