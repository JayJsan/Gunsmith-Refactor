using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Configuration")]
    public float walkSpeed = 5f;
    [Header("References")]
    public Rigidbody2D rb;
    public Collider col;

    private Vector2 movementInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider>();

        CDL.Log<PlayerMovementController>("Disabling gravity and rotation for player.");
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update() {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        rb.velocity = movementInput.normalized * walkSpeed;
    }
}
