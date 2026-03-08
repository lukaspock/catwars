using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float damage = 1;
    public float attackSpeed = 1;
    public float hp = 1;
    public float timer = 0;
    public bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
            isAttacking = true;
            timer = attackSpeed;
            other.gameObject.GetComponent<PlayerBehaviour>().takeDamage(damage);
        }

        if (other.gameObject.CompareTag("Missile"))
        {
            hp -= other.gameObject.GetComponent<MissileDamage>().getDamage();

            Destroy(other.gameObject);

            if (hp <= 0) {
                Destroy(gameObject);
            }
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
