using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
    private Transform target;
    public string targetString = "PlayerHead";
    void Start()
    {
        var go = GameObject.FindWithTag("Head");
        if (go != null)
            target = go.transform;
        else
            Debug.LogWarning("CameraScript: could not find object with tag 'Head'");
    }

    void LateUpdate()
    {
        if (target == null) return;
        transform.position = target.TransformPoint(camOffset);
        transform.LookAt(target.position + Vector3.up);
    }

}
