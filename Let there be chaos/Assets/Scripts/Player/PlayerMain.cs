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
    public int maxHealth;
    private int currentHealth;

    private SpriteRenderer sprite;

    // CHAOS SOULS
    public int chaosSoulsCounter;

    // WEAPONS
    public string weapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth; // To update currentHealth depending on the value written in the editor
    }

    private void Update()
    {
        // Used to damage or heal player using + or - keys
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            modifyPlayerHealth(-1);
        }
        print(currentHealth);
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            modifyPlayerHealth(1);
        }
        print(currentHealth);
    }

    void FixedUpdate()
    {
        // Player movement
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize(); // Normalisation du vecteur pour permettre un mouvement horizontal, vertical et diagonal uniforme.
        moveVelocity = new Vector2(moveInput.x * movementSpeed, moveInput.y * movementSpeed);
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void modifyPlayerHealth(int value)
    {
        // IEnumator is used to create waiting time inside of the function using
        // yield return new WaitForSeconds(time in seconds)
        IEnumerator damagePlayer()
        {
            currentHealth += value;
            sprite.color = new Color(0.9198f, 0.9663f, 1f, 1f);
            yield return new WaitForSeconds(.05f); 
            sprite.color = new Color(0f, 0.5794f, 1f, 1f);
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        IEnumerator healPlayer()
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += value;
            }
            sprite.color = new Color(0.3841906f, 1f, 0.3820f, 1f);
            yield return new WaitForSeconds(.05f);
            sprite.color = new Color(0f, 0.5794f, 1f, 1f);
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        if(value <= 0)
        {
            StartCoroutine(damagePlayer());
        }
        else
        {
            StartCoroutine(healPlayer());
        }
    }
}