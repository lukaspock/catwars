using System.Threading.Tasks;
using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnRange = 30;
    private float startDelay = 2;
    public Vector3 spawnCenter = new Vector3(590f, 34f, 573f);
    public float spawnInterval = 1f;
    public float spawnCounter = 0;
    public float noe = 0;
    public float startNoe = 1;
    public float waveCounter = 0;
    private bool waitingForInput = false;

    void Start() { }


    void SpawnRandomEnemy()
    {
        if (spawnCounter < startNoe)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            //Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation); // fixed rotation

            //float randomY = Random.Range(0f, 360f);
            //Quaternion randomRotation = Quaternion.Euler(0f, randomY, 0f); // random rotation around the Y-axis

            Vector3 spawnPoint = getRandomSpawnPoint();

            Instantiate(enemyPrefabs[enemyIndex], spawnPoint, /*randomRotation*/ transform.rotation);
            spawnCounter++;
        } else
        {
            Debug.Log("All Enemies Spawned");
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Debug.Log("Wave Complete");
            }
        }
    }

    public void startWave()
    {
        CancelInvoke("SpawnRandomEnemy");
        spawnCounter = 0;
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
        do
        {
          spawnPos = new Vector3(spawnCenter.x + Random.Range(-spawnRange, spawnRange), spawnCenter.y, spawnCenter.z + Random.Range(-spawnRange, spawnRange));
        } while (Vector3.Distance(spawnPos, spawnCenter) < 20);

        return spawnPos;

    }
}


