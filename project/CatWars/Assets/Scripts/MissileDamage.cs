using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public enum MissileType
{
    Gun,
    Shotgun,
    Sniper,
    Rocket
}

public class MissileDamage : MonoBehaviour
{
    public float damage;
    public float upgradedDamage = 0;
    public MissileType missileType;

    public static Dictionary<MissileType, float> damageBonus = new Dictionary<MissileType, float>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getDamage()
    {
        if (damageBonus.ContainsKey(missileType))
        {
            return damage + damageBonus[missileType];
        }

        return damage;
    }

    public static void upgradeDamage(MissileType type, float amount)
    {
        if (!damageBonus.ContainsKey(type))
        {
            damageBonus[type] = 0f;
        } else
        {
            damageBonus[type] += amount;
        }


    }


    // wenn die scene neu geldaen wird, werden die damage boni resetted
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        damageBonus.Clear();
    }



}
