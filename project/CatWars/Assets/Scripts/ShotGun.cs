using UnityEngine;

public class ShotGun : Weapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flySpeed = 20f;
        missileNumber = 20;
        waves = 5;
        coneAngle = 45;
        reloadTime = 2f;
        waveSpeed = 0.1f;

}

}
