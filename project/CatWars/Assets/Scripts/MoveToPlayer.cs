using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private GameObject[] players;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            float targetAngle = getRotationToNearestTag("Player");
            float angle = transform.rotation.eulerAngles.y;

            transform.Rotate(0f, targetAngle - angle + 180, 0f);
            //Debug.Log(angle);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        catch
        {
            Debug.Log("ERROR MOVE TO PLAYER");
        }

    }


    public float getRotationToNearestTag(string tag)
    {
        float angle = 0;
        GameObject target = findNearest(tag);
        if (target != null)
        {
            float xdist = gameObject.transform.position.x - target.transform.position.x;
            float ydist = gameObject.transform.position.z - target.transform.position.z;
            angle = getAngle(xdist, ydist);
        }
        return angle;
    }

    public GameObject findNearest(string tag)
    {
        players = GameObject.FindGameObjectsWithTag(tag);
        //Debug.Log(players.Length);

        return players[0];

    }

    public float getAngle(float xdist, float zdist)
    {
        float a = xdist;
        float b = zdist;
        float c = a * a + b * b;
        float angle = Mathf.Atan2(a, b) * Mathf.Rad2Deg;
        return angle;
    }
}
