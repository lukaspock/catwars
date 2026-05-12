using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public enum WeaponType
{
    Gun,
    Shotgun,
    Sniper,
    MachineGun,
    RocketLauner,
}

[System.Serializable]
public class WeaponPrefabs
{
    public WeaponType weaponType;
    public Weapon prefab;

}

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f, rotateSpeed = 75f;
    private float hInput, vInput;
    private Rigidbody _rb;
    public float jumpVelocity = 5f;
    public bool isOnGround = true;
    //public GameObject projectilePrefab;
    private float timer;
    private double soundTimer = 0;

    public float maxHp = 100;
    public float currentHp;
    //public float attackSpeed = 1f;
    //private float startDelay = 2f;
    //
    public Weapon weapon;
    private int killCount = 0;

    public WeaponPrefabs[] allWeaponPrefabs = new WeaponPrefabs[10];
    public WeaponType weaponType;
    public Dictionary<WeaponType, WeaponPrefabs> weaponsDic = new Dictionary<WeaponType, WeaponPrefabs>();

    public Transform startingPosition;
    public int goldCount = 0;

    public int skillPoints = 0;

    void Start()
    {
        for (int i = 0; i < allWeaponPrefabs.Length; i++)
        {
            weaponsDic.Add((WeaponType)i, allWeaponPrefabs[i]);
        }

        weaponType = WeaponType.Gun;
        weapon = Instantiate(weaponsDic[weaponType].prefab, startingPosition.position, startingPosition.rotation, startingPosition);

        //SwitchWeapon(WeaponType.Gun);


        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        currentHp = maxHp;

        //InvokeRepeating("FireMissile", startDelay, 1/attackSpeed);
    }
    void Update()
    {
        timer -= Time.deltaTime;

        hInput = Input.GetAxis("Horizontal") * moveSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        if ((hInput != 0 || vInput != 0) && soundTimer <= 0)
        {
            soundTimer = 0.4;
            AudioManager.Instance.Play(AudioManager.SoundType.Step, transform.position);
        }
        else if (soundTimer >= 0)
        {
            soundTimer -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {
            weapon.shoot();
            timer = weapon.getReload();
        }

        if (timer >= 0)
        {
            //Debug.Log(Mathf.Round(timer*100)/100);
        }
    }

    public void SwitchWeapon(WeaponType weaponType)
    {
        Debug.Log("GUN SWITCH" + weaponType);
        if (!weaponsDic.ContainsKey(weaponType)) return;

        Weapon prefab = weaponsDic[weaponType].prefab;
        Debug.Log(prefab.name);

        if (goldCount < prefab.price) return;

        if (weapon != null)
            Destroy(weapon.gameObject);

        weapon = Instantiate(prefab, startingPosition.position, startingPosition.rotation, startingPosition);
        this.weaponType = weaponType;
        goldCount -= prefab.price;
    }

    void FixedUpdate()
    {
        Vector3 move = transform.forward * vInput + transform.right * hInput;
        _rb.MovePosition(transform.position + move * Time.fixedDeltaTime);
    }

    void Jump()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Jump, transform.position);
        _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        isOnGround = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Landed");
            isOnGround = true;
        }

    }

    public void takeDamage(float damage)
    {
        GameObject manager = GameObject.Find("GameManager");
        AudioManager.Instance.Play(AudioManager.SoundType.Hurt, transform.position);
        this.currentHp -= damage;
        manager.GetComponent<GameManager>().UpdateHealthUI(currentHp, maxHp);
        if (currentHp <= 0)
        {
            manager.GetComponent<GameManager>().GameOver();
        }
    }

    public void AddGold(int amount)
    {
        goldCount += amount;
        Debug.Log($"Added {amount} gold. Total: {goldCount}");
    }

    public void decreaseGold(int amount)
    {
        goldCount -= amount;
    }

    public void upgradeWeapon()
    {
        Weapon weapon = weaponsDic[WeaponType.Shotgun].prefab;
        Debug.Log("UPGRADE WEAPON CALLED");

        if (goldCount >= weapon.upgradePrice)
        {
            Debug.Log($"Upgrading weapon: {weapon.name}");
            weapon.upgradeWeapon(weapon.damageBonusOnUpgradePerMissile);
            goldCount -= weapon.upgradePrice;
        }
    }

    public void AddKillCount()
    {
        killCount++;
        Debug.Log($"Kill count: {killCount}");
    }

    public int getKillCount()
    {
        return killCount;
    }

    public void IncreaseMaxHp(int amount)
    {
        if (skillPoints > 0)
        {
            maxHp += amount;
            skillPoints--;
            currentHp += amount;
        }
    }

    public void Heal()
    {
        if (skillPoints > 0)
        {
            currentHp = maxHp;
            skillPoints--;
        }
    }

    public void IncreaseSpeed(int amount)
    {
        if (skillPoints > 0)
        {
            moveSpeed += amount;
            skillPoints--;
        }
    }

}
