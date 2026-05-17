using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionRadius = 10f;
    public float explosionDamage = 10f;
    public GameObject particlePrefab;

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
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        Debug.Log("Explosion hit " + hits.Length + " objects.");

        GameObject ps = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(ps, 3f);

        foreach (Collider hit in hits) {
            if (hit.CompareTag("Enemy")) {
                EnemyBehaviour enemy = hit.GetComponent<EnemyBehaviour>();
                if (enemy != null)
                {
                    enemy.takeDamage(explosionDamage);
                    Debug.Log("Enemy hit: " + hit.name);
                }
            }
        }

        Destroy(gameObject);
    }
}
