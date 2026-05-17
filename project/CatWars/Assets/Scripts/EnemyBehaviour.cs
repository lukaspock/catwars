using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int goldOnDeath;
    private PlayerBehaviour player;
    public float damage = 1;
    public float attackSpeed = 1;
    private float currentHp;
    private float meleeTimer = 0;
    private float weaponTimer = 0;
    private bool isAttacking = false;
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

        // for future upgrades with enemies with weapons
        if (weapon != null && weaponTimer <= 0)
        {
            Debug.Log("Shot" + weaponTimer);
            weapon.shoot();
            weaponTimer = weapon.getReload();
        }
    }

    // decides between colliding with players or bullets
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

    // player takes damage
    public void playerCollision(Collision other)
    {
        isAttacking = true;
        meleeTimer = attackSpeed;
        other.gameObject.GetComponent<PlayerBehaviour>().takeDamage(damage);
    }

    // enemy takes damage on missile collission
    public void missileCollision(Collision other)
    {

        float missileDamage = other.gameObject.GetComponent<MissileDamage>().getDamage();
        takeDamage(missileDamage);

        //  missile gets destroyed
        Destroy(other.gameObject);

        AudioManager.Instance.Play(AudioManager.SoundType.EnemyDeath, gameObject.transform.position);

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

    public float getDamage()
    {
        return damage;
    }

    public float getMeleeTimer()
    {
        return meleeTimer;
    }
}
