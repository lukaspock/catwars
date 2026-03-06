using UnityEngine;
using UnityEngine.Rendering;

public abstract class Weapon : MonoBehaviour
{
    protected float flySpeed;
    protected float missileNumber;
    protected float coneAngle;
    protected float reloadTime;
    public GameObject projectilePrefab;
    private float missileAngle;
    protected float waves;
    protected float waveSpeed;
    private float timer = 0;
    private bool isShooting = false;
    private int currentWave = 0;
    protected float startAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                fireWave();
                currentWave++;

                if (currentWave >= waves)
                {
                    isShooting = false;
                    currentWave = 0;
                }
                else
                {
                    timer = waveSpeed;
                }
            }
 
        }

    }

    public void shoot()
    {
        isShooting = true;
        missileAngle = coneAngle / missileNumber;
        startAngle = -(coneAngle / 2) + (missileAngle / 2);
        currentWave = 0;
        timer = 0;
    }

    public void fireWave()
    {
        for (int i = 0; i < missileNumber; i++)
        {
            float fireAngle = startAngle + (missileAngle * i);
            //Debug.Log(transform.position.y);
            Vector3 spawnPos = transform.position + transform.forward * 1f + Vector3.up;
            Quaternion rotation = Quaternion.Euler(0, fireAngle + transform.eulerAngles.y, 0);
            Instantiate(projectilePrefab, spawnPos, rotation);
        }
    }

    public float getReload()
    {
        return reloadTime;
    }
}
