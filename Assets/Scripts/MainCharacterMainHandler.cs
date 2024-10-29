using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainCharacterMainHandler : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] int health = 5;
    [SerializeField] float speed = 3f;
    [SerializeField] int gold = 0;
    [SerializeField] float jumpForce = 5f;


    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI goldCounterText;
    [SerializeField] TextMeshProUGUI healthCounterText;

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

        UpdateUI();
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
        //apply velocity for horizontal movement
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

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

    public void AddGold(int amount)
    {
        gold += amount;
        //make script for UI for gold
        UpdateUI();
    }

    private void UpdateUI()
    {
        goldCounterText.text = gold.ToString();
        // TODO: healthCounterText.text = health.ToString();
    }
}
