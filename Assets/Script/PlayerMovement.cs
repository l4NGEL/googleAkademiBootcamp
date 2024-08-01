using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;

    //Jump Stuff
    Vector3 velocity;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        rb.freezeRotation = true; // Rigidbody'nin dönmesini engelle
    }

    void Update()
    {
        // Zemin kontrolü
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Daha hýzlý yere inmek için küçük bir negatif deðer
        }

        // Hareket girdisi
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        if (dir.magnitude >= 0.1f)
        {
            animator.SetBool("IsMoving", true);
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.MovePosition(rb.position + moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        // Zýplama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            rb.velocity = new Vector3(rb.velocity.x, velocity.y, rb.velocity.z); // Y hýzýný ayarla
        }

        // Yerçekimi
        velocity.y += gravity * Time.deltaTime;
        rb.velocity = new Vector3(rb.velocity.x, velocity.y, rb.velocity.z);
    }
}
