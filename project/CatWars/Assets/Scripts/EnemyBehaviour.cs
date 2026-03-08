using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float damage = 1;
    public float attackSpeed = 1;
    private float currentHp;
    public float timer = 0;
    public bool isAttacking = false;
    public float maxHP = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHP;
        ChangeColor(Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            isAttacking = false;
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
        timer = attackSpeed;
        other.gameObject.GetComponent<PlayerBehaviour>().takeDamage(damage);
    }

    public void missileCollision(Collision other)
    {
        currentHp -= other.gameObject.GetComponent<MissileDamage>().getDamage();

        Destroy(other.gameObject);

        if (currentHp <= maxHP / 2)
        {
            ChangeColor(Color.red);
        }

        if (currentHp <= 0)
        {
            Destroy(gameObject);
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

    public float getDamage()
    {
        return damage;
    }

    public float getTimer() { 
        return timer; 
    }
}
