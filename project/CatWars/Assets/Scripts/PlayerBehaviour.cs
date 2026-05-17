using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using System.IO;


public enum WeaponType
{
    Gun,
    Shotgun,
    Sniper,
    RocketLauncher,
    MachineGun,

}

[System.Serializable]
public class WeaponPrefabs
{
    public WeaponType weaponType;
    public Weapon prefab;

}

public class PlayerBehaviour : MonoBehaviour
{
    private float moveSpeed = 10f, rotateSpeed = 75f;
    private float hInput, vInput;
    private Rigidbody _rb;
    private float jumpVelocity = 5f;
    private bool isOnGround = true;

    private float timer;
    private double soundTimer = 0;

    private float maxHp = 100;
    private float currentHp;

    private Weapon weapon;
    private int killCount = 0;

    public WeaponPrefabs[] allWeaponPrefabs = new WeaponPrefabs[10];
    private WeaponType weaponType;
    public Dictionary<WeaponType, WeaponPrefabs> weaponsDic = new Dictionary<WeaponType, WeaponPrefabs>();

    public Transform startingPosition;
    private int goldCount = 0;

    private GameManager gameManager;

    void Start()
    {
        for (int i = 0; i < allWeaponPrefabs.Length; i++)
        {
            weaponsDic.Add((WeaponType)i, allWeaponPrefabs[i]);
        }

        weaponType = WeaponType.Gun;
        weapon = Instantiate(weaponsDic[weaponType].prefab, startingPosition.position, startingPosition.rotation, startingPosition);


        gameManager = GameObject.FindWithTag("Gamemanager").GetComponent<GameManager>();


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

        if (!(gameManager.isGamePaused()))
        {
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
            isOnGround = true;
        }

    }

    public void takeDamage(float damage)
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Hurt, transform.position);
        this.currentHp -= damage;
        gameManager.GetComponent<GameManager>().UpdateHealthUI(currentHp, maxHp);
        if (currentHp <= 0)
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }

    public void AddGold(int amount)
    {
        goldCount += amount;
    }

    public void decreaseGold(int amount)
    {
        goldCount -= amount;
    }

    public void upgradeWeapon()
    {
        Weapon weapon = weaponsDic[WeaponType.Shotgun].prefab;

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
    }

    public int getKillCount()
    {
        return killCount;
    }

    public void IncreaseMaxHp(int amount)
    {
        maxHp += amount;
        currentHp += amount;
    }

    public void Heal()
    {
        currentHp = maxHp;
    }

    public void IncreaseSpeed(int amount)
    {
        moveSpeed += amount;
    }

    public float getCurrentHp()
    {
        return currentHp;
    }
    public float getMaxHp()
    {
        return maxHp;
    }
     public int getGoldCount()
    {
        return goldCount;
    }
     public WeaponType getWeaponType()
    {
        return weaponType;
    }
     public Weapon getWeapon()
    {
        return weapon;
    }


}
