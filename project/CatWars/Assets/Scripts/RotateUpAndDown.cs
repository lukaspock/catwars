using UnityEngine;

public class RotateUpAndDown : MonoBehaviour
{

    public float mouseSensitivity = 2f;
    public float clampUpAngle = 60f;
    public float clampDownAngle = -60f;
    private float rotationX = 0f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, clampUpAngle, clampDownAngle); // limit rotation

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
