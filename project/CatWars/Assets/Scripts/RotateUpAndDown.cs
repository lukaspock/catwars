using UnityEngine;

public class RotateUpAndDown : MonoBehaviour
{

    public float mouseSensitivity = 2f;
    public float clampAngle = 60f; // max up/down angle
    private float rotationX = 0f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle); // limit rotation

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
