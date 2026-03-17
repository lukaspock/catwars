using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("Missile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

