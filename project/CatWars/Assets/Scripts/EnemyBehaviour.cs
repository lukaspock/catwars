using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int goldOnDeath;
    public PlayerBehaviour player;
    public float damage = 1;
    public float attackSpeed = 1;
    private float currentHp;
    public float meleeTimer = 0;
    public float weaponTimer = 0;
    public bool isAttacking = false;
    public float maxHP = 1;
    public Weapon weapon = null;
    private bool dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
        currentHp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        weaponTimer -= Time.deltaTime;
        if (isAttacking)
        {
            meleeTimer -= Time.deltaTime;
        }

        if (meleeTimer <= 0)
        {
            isAttacking = false;
        }

        if (weapon != null && weaponTimer <= 0)
        {
            Debug.Log("Shot" + weaponTimer);
            weapon.shoot();
            weaponTimer = weapon.getReload();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !isAttacking)
        {
            playerCollision(other);
        }

        if (other.gameObject.CompareTag("Missile"))
        {
            missileCollision(other);
        }
    }

    public void playerCollision(Collision other)
    {
        isAttacking = true;
        meleeTimer = attackSpeed;
        other.gameObject.GetComponent<PlayerBehaviour>().takeDamage(damage);
    }

    public void missileCollision(Collision other)
    {

        float missileDamage = other.gameObject.GetComponent<MissileDamage>().getDamage();
        takeDamage(missileDamage);

        Destroy(other.gameObject);

        AudioManager.Instance.Play(AudioManager.SoundType.EnemyDeath, gameObject.transform.position);

        if (currentHp <= 0)
        {
            if (!dead)
            {
                dead = true;
                AudioManager.Instance.Play(AudioManager.SoundType.EnemyDeath, gameObject.transform.position);
                Destroy(gameObject);
                player.AddGold(goldOnDeath);
                player.AddKillCount();
            }

        }
    }

    public void ChangeColor(Color color)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in renderers)
        {
            rend.material.color = color;
        }
    }

    public void takeDamage(float damage)
    {
        currentHp -= damage;
    }

    public float getDamage()
    {
        return damage;
    }

    public float getMeleeTimer()
    {
        return meleeTimer;
    }
}
