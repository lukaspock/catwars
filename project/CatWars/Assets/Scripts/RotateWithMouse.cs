using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public Transform playerHead;

    [Header("Einstellungen")]
    public float sensitivity = 2f; //how fast the head turns
    public float minAngle = -60f; //how far the head turns
    public float maxAngle = 60f; //how far the head turns

    private float currentXRotation = 0f; //

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; // 
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;


        transform.Rotate(Vector3.up * mouseX); //player turns left and right


        currentXRotation -= mouseY; //head turns up and down
        currentXRotation = Mathf.Clamp(currentXRotation, minAngle, maxAngle);
        playerHead.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
    }
}
