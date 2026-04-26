using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 700;
    public float lowerBound = -100;


    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound || transform.position.x > topBound || transform.position.x < lowerBound || transform.position.y > topBound || transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }

}


