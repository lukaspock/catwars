using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    public int price;
    public int upgradePrice;
    public float flySpeed;
    public float missileNumber;
    public float coneAngle; // how far the missiles are spread
    public float reloadTime; // time it takes until mousedown triggers another shot
    public GameObject projectilePrefab;
    protected float missileAngle; // angle for each missile
    public float waves; // number of waves
    public float waveSpeed; // how long it takes for each wave to be shot
    private float waveTimer = 0;
    private bool isShooting = false;
    private int currentWave = 0; // wave counter (more than one wave per shot possible)
    protected float startAngle; // the angle in relation to the player where the first missile spawns
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0)
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
                    waveTimer = waveSpeed;
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
        waveTimer = 0;
        AudioManager.Instance.Play(AudioManager.SoundType.Shoot, transform.position);
    }

    public virtual void fireWave()
    {

        for (int i = 0; i < missileNumber; i++)
        {
            float fireAngle = startAngle + (missileAngle * i);
            Vector3 spawnPos = transform.position + transform.forward * 1f + Vector3.up;
            Quaternion rotation = Quaternion.Euler(0, fireAngle + transform.eulerAngles.y, transform.eulerAngles.z);
            GameObject projectile = Instantiate(projectilePrefab, spawnPos, rotation);
            projectile.GetComponent<MoveForward>().speed = flySpeed;
        }
    }

    public float getReload()
    {
        return reloadTime;
    }

    public void upgradeWeapon()
    {
        projectilePrefab.GetComponent<MissileDamage>().upgradeDamage(5);
    }
}
