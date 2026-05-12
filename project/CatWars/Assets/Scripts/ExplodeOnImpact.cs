using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionRadius = 50f;
    public float explosionDamage = 20f;

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

        foreach (Collider hit in hits) {
            EnemyBehaviour enemy = hit.GetComponent<EnemyBehaviour>();
            if (enemy != null) {
                enemy.takeDamage(explosionDamage);
            }
        }

    }
}
