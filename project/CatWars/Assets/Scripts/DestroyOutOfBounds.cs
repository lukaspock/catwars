using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 50;
    public float lowerBound = -50;


    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound || transform.position.x > topBound || transform.position.x < lowerBound || transform.position.y > topBound || transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }

}


