using UnityEngine;

public class ShotGun : Weapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flySpeed = 20f;
        missileNumber = 12;
        waves = 1;
        coneAngle = 45;
        reloadTime = 1f;
        waveSpeed = 0.1f;
    }

}
