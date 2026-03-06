using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
    private Transform target;
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = target.TransformPoint(camOffset);
        transform.LookAt(target.position + Vector3.up);
    }

}
