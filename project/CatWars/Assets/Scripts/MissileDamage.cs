using UnityEngine;
using UnityEngine.Rendering;

public class MissileDamage : MonoBehaviour
{
    public float damage;
    public float initialDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Reset Missile Damage");
        //damage = initialDamage;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getDamage()
    {
        return damage;
    }

    public void upgradeDamage(float amount)
    {
        Debug.Log("damage: " + damage + " bonus: " + amount + "\n new damage: " + (damage + amount));
        damage += amount;
        Debug.Log("Actual new damage: " + damage);

    }
}
