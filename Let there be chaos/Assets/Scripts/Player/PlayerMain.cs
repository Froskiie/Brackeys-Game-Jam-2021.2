using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    // MOVEMENT
    public float movementSpeed;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    private Rigidbody2D rb;

    // HEALTH
    public float maxHealth;
    private float currentHealth;

    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize(); // Normalisation du vecteur pour permettre un mouvement horizontal, vertical et diagonal uniforme.
        moveVelocity = new Vector2(moveInput.x * movementSpeed, moveInput.y * movementSpeed);
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

}