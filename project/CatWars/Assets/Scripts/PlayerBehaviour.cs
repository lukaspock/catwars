using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public enum WeaponType
{
    Gun,
    Shotgun,
    //Sniper,
    MachineGun,
    //RocketLauner
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

    public WeaponPrefabs[] allWeaponPrefabs = new WeaponPrefabs[10];
    public WeaponType weaponType;
    public Dictionary<WeaponType, WeaponPrefabs> weaponsDic = new Dictionary<WeaponType, WeaponPrefabs>();

    public Transform startingPosition;
    public int goldCount = 0;

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
        if (weaponsDic.ContainsKey(weaponType))
        {
            Destroy(weapon.gameObject);
            weapon = Instantiate(weaponsDic[weaponType].prefab, startingPosition.position, startingPosition.rotation, startingPosition);
            this.weaponType = weaponType;
        }
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
        AudioManager.Instance.Play(AudioManager.SoundType.Hurt, transform.position);
        this.currentHp -= damage;
        if (currentHp <= 0)
        {
            UIManager.instance.ShowGameOver();
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
            weapon.upgradeWeapon();
            goldCount -= weapon.upgradePrice;
        }
    }

    public void switchToShotgun()
    {
        Weapon weapon = weaponsDic[WeaponType.Shotgun].prefab;
        Debug.Log("Switch WEAPON CALLED");

        if (goldCount >= weapon.price)
        {
            Debug.Log($"Switching to shotgun: {weapon.name}");
            SwitchWeapon(WeaponType.Shotgun);
            goldCount -= weapon.price;
        }
    }

    public void switchToPistol()
    {
        Weapon weapon = weaponsDic[WeaponType.Gun].prefab;
        Debug.Log("Switch WEAPON CALLED");

        if (goldCount >= weapon.price)
        {
            Debug.Log($"Switching to pistol: {weapon.name}");
            SwitchWeapon(WeaponType.Gun);
            goldCount -= weapon.price;
        }
    }
}
