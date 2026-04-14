using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f, rotateSpeed = 75f;
    private float hInput, vInput;
    private Rigidbody _rb;
    public float jumpVelocity = 5f;
    public bool isOnGround = true;
    //public GameObject projectilePrefab;
    private float timer;
    public Weapon weapon;
    public float maxHp = 100;
    public float currentHp;
    //public float attackSpeed = 1f;
    //private float startDelay = 2f;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        weapon = GetComponentInChildren<Weapon>();
        currentHp = maxHp;
        //InvokeRepeating("FireMissile", startDelay, 1/attackSpeed);
    }
    void Update()
    {
        timer -= Time.deltaTime;

        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {
            weapon.shoot();
            timer = weapon.getReload();
        }

        if (timer >= 0)
        {
            //Debug.Log(Mathf.Round(timer*100)/100);
        }

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
       if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Landed");
            isOnGround = true;
        }

    }

    public void takeDamage(float damage)
    {
        this.currentHp -= damage;
        if (currentHp <= 0)
        {
            Debug.Log("GameOver");
        }
    }

}