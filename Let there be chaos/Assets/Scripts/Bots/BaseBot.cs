using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBot : MonoBehaviour
{
    [Header("Stats")]
    // MOVEMENT
    public float movementSpeed;
    public float stoppingDistance;
    public float retreatDistance;

    // HEALTH
    public int maxHealth;
    public int currentHealth;

    private SpriteRenderer sprite;

    // CHAOS SOULS
    public int SoulsNumber;

    // WEAPONS
    [Header("Weapons")]
    public string weaponType;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;

    public float weaponProjectileSpeed;
    public float weaponDamage;
    public bool weaponUseNormally;
    public GameObject weaponUseProjectile;

    

    //POSITIONS

    [HideInInspector] public Transform player;
    private Transform SelfPosition;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SelfPosition = GetComponent<Transform>();

        timeBetweenShots = startTimeBetweenShots;

    }

    // Update is called once per frame
    void Update()
    {
        //mouvement de base
        if(Vector2.Distance(SelfPosition.position, player.position) > stoppingDistance)
        {
            SelfPosition.position = Vector2.MoveTowards(SelfPosition.position, player.position, movementSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(SelfPosition.position, player.position) < stoppingDistance && Vector2.Distance(SelfPosition.position, player.position) > retreatDistance)
        {
            SelfPosition.position = this.SelfPosition.position;
        }
        else if (Vector2.Distance(SelfPosition.position, player.position) < retreatDistance)
        {
            SelfPosition.position = Vector2.MoveTowards(SelfPosition.position, player.position, -movementSpeed * Time.deltaTime);
        }

        //attaque
        if(timeBetweenShots <= 0)
        {
            Instantiate(projectile, SelfPosition.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;

        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }
}
