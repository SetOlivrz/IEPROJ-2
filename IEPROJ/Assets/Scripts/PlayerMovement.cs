using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isPaused;
    public GameObject panel; // panel for pause

    public HealthBar health;
    private int max = 10;

    private float collisionTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPaused = false;
        health.SetMax(max);
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown("escape"))
        {
            if (!isPaused)
            {
                isPaused = true;
                panel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                isPaused = false;
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
            
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
