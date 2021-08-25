using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    private Vector2 mousePosition;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public Camera cam;
    
    [HideInInspector] public Rigidbody2D rb;

    [Header("Stats")]
    // MOVEMENT
    public float movementSpeed;

    // HEALTH
    public int maxHealth;
    public int currentHealth;

    private SpriteRenderer sprite;

    // CHAOS SOULS
    public int chaosSoulsCounter;

    // WEAPONS
    [Header("Weapons")]
    public string weaponType;

    public float weaponProjectileSpeed;
    public float weaponUseTime;
    public float weaponDamage;

    public bool weaponUseNormally;
    
    public GameObject weaponUseProjectile;

    [HideInInspector] public Transform firePoint;

    void Start()
    {
        firePoint = GetComponentInChildren<Transform>();
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
        //print(currentHealth);
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            modifyPlayerHealth(1);
        }
        //print(currentHealth);

        // Display weapon name
        if (weaponType == "")
        {
            weaponType = "No weapon";
        }
    }

    void FixedUpdate()
    {
        // Player movement
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize(); // Normalisation du vecteur pour permettre un mouvement horizontal, vertical et diagonal uniforme.
        moveVelocity = new Vector2(moveInput.x * movementSpeed, moveInput.y * movementSpeed);
        rb.velocity = moveVelocity;

        // Player Rotation
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.x, lookDirection.y) * -Mathf.Rad2Deg;
        rb.rotation = angle;
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