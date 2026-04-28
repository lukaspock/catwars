using System.Threading.Tasks;
using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnRange = 30;
    private float startDelay = 2;
    public float spawnInterval = 1f;
    public float spawnCounter = 0;
    public float noe = 0;
    public float startNoe = 1;
    public float waveCounter = 0;
    public bool waveComplete = false;
    public GameObject[] spawnPoints;

    void Start()
    {
        startWave();
    }

    private void Update()
    {

    }

    public void continueWaves()
    {
        if (waveComplete)
        {
            waveComplete = false;
            increaseDifficulty();
            startWave();
        }
    }



    void SpawnRandomEnemy()
    {
        if (spawnCounter < startNoe)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            //Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 1, Random.Range(-spawnRange, spawnRange));
            //Instantiate(enemyPrefabs[enemyIndex], spawnPos, /*randomRotation*/ transform.rotation);

            Vector3 spawnPoint = getRandomSpawnPoint();
            Instantiate(enemyPrefabs[enemyIndex], spawnPoint, transform.rotation);
            spawnCounter++;
        }
        else
        {
            Debug.Log("All Enemies Spawned");
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                waveComplete = true;
            }
        }
    }

    public void startWave()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, 1 / spawnInterval);
    }

    public void increaseDifficulty()
    {
        spawnCounter = 0;
        spawnInterval *= 1.2f;
        waveCounter++;
        startNoe *= 1.2f;
    }

    public Vector3 getRandomSpawnPoint()
    {
        Vector3 spawnPos;
        int maxAttempts = 10; // falls keine spawnpunkte im erlaubten bereich gefunden werden, wird nach 10 versuchen einfach einer genommen
        int attempts = 0;

        do
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            spawnPos = spawnPoint.transform.position + Vector3.up;
            attempts++;
        } while (Vector3.Distance(spawnPos, Vector3.zero) < 20 && attempts < maxAttempts);

        return spawnPos;
    }

}


