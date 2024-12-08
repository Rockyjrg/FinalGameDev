using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlTwoCharacterMovement : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float airControlFactor = 0.5f;

    [Header("Audio")]

    private Rigidbody2D rb;
    private float moveInput;
    private float verticalInput;
    private bool isGrounded;
    private bool isClimbing = false;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius = 0.2f;
    [SerializeField] LayerMask whatIsGround;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal input(left/right)
        moveInput = Input.GetAxisRaw("Horizontal");

        //flip character sprite left and right based on movement
        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        //check for jump input
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !isClimbing)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //vertical input for ladder climbing
        if (isClimbing)
        {
            verticalInput = Input.GetAxis("Vertical");
        }
    }

    void FixedUpdate()
    {
        float targetSpeed = moveInput * speed;
        float smoothSpeed = Mathf.MoveTowards(rb.velocity.x, targetSpeed, speed * Time.fixedDeltaTime);

        if (isGrounded)
        {
            rb.velocity = new Vector2(smoothSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(smoothSpeed * airControlFactor, rb.velocity.y);
        }

        //check if character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //handling climbing movement
        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }

    }

    //detect when character is near ladder
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }
}
