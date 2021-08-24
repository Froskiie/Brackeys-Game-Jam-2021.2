using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingSystem : MonoBehaviour
{

    private float counter;

    private PlayerMain player;

    public Transform firePoint;

    [Header("Bullet types")]
    public GameObject classic;
    public GameObject explosive;
    public GameObject bouncy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMain>();
    }
    void Update()
    {
        // Weapon stats
        if(player.weaponType == "Pistol")
        {
            player.weaponUseTime = 0.2f;
            player.weaponUseProjectile = classic;
            player.weaponDamage = 1f;
            player.weaponUseNormally = true;
        }

        // Weapon use
        counter += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if(counter >= player.weaponUseTime)
            {
                counter = 0;
                if (player.weaponUseNormally)
                {
                    GameObject bullet = Instantiate(player.weaponUseProjectile, firePoint.position, firePoint.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.angularVelocity = rb.rotation;
                }
            }
        }
    }
}
