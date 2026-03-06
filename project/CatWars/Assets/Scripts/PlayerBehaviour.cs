using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f, rotateSpeed = 75f;
    private float hInput, vInput;
    private Rigidbody _rb;
    public float jumpVelocity = 5f;
    public bool isOnGround = true;
    public GameObject projectilePrefab;
    //public float attackSpeed = 1f;
    //private float startDelay = 2f;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        //InvokeRepeating("FireMissile", startDelay, 1/attackSpeed);
    }
    void Update()
    {
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireMissile();
        }

    }

    void FireMissile()
    {
        Vector3 spawnPos = transform.position + transform.forward * 1f + Vector3.up * 1.5f;
        Instantiate(projectilePrefab, spawnPos, transform.rotation);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(Vector3.up * hInput * Time.fixedDeltaTime));
    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        isOnGround = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

}