using UnityEngine;
using UnityEngine.Rendering;

public class ShotGun : Weapon
{
    public override void fireWave()
    {
        for (int i = 0; i < missileNumber; i++)
        {
            float fireAngle = startAngle + (missileAngle * i);
            //Debug.Log(transform.position.y);
            Vector3 spawnPos = transform.position + transform.forward * 1f + Vector3.up;
            Quaternion rotation = Quaternion.Euler(0, fireAngle, 0);
            Instantiate(projectilePrefab, spawnPos, getRandomRotation());
        }
    }

    public Quaternion getRandomRotation()
    {
        float randomY = Random.Range(0f, 10f);
        float randomX = Random.Range(-3f, 3f);
        Debug.Log(randomY);
        return Quaternion.Euler(randomX, transform.eulerAngles.y + randomY, 0f);
    }
}
