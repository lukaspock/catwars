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
    public float startNoe = 10;
    public int waveCounter = 1;
    public bool waveComplete = false;
    public GameObject[] spawnPoints;
    public Transform playerSpawn;
    public GameObject bossPrefab;
    private int bossSpawnInterval = 3;
    public bool shopActive = false;

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
            CancelInvoke("SpawnRandomEnemy");
            increaseDifficulty();
            startWave();
        }
    }



    void SpawnRandomEnemy()
    {
        if (spawnCounter < startNoe)
        {
            if (waveCounter % bossSpawnInterval == 0)
            {
                for (int i = 0; i < waveCounter / bossSpawnInterval; i++)
                {
                    Vector3 spawnPoint = getRandomSpawnPoint();
                    Instantiate(bossPrefab, spawnPoint, transform.rotation);
                }
                spawnCounter = startNoe;
            }
            else
            {
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                //Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 1, Random.Range(-spawnRange, spawnRange));
                //Instantiate(enemyPrefabs[enemyIndex], spawnPos, /*randomRotation*/ transform.rotation);

                Vector3 spawnPoint = getRandomSpawnPoint();
                Instantiate(enemyPrefabs[enemyIndex], spawnPoint, transform.rotation);
                spawnCounter++;
            }

        }
        else
        {
            //Debug.Log("All Enemies Spawned");
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                // Now After all enemies are defeated, activate Upgrade Screen
                shopActive = true;
                //waveComplete = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().skillPoints++;

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
        startNoe *= 1.2f + 1;
        GameObject manager = GameObject.Find("GameManager");
        manager.GetComponent<GameManager>().UpdateWaveCounterUI(waveCounter);
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

    /*void OnEnable()
    {
        startWave();
    }*/

    void OnDisable()
    {
        CancelInvoke("SpawnRandomEnemy");
    }

}
