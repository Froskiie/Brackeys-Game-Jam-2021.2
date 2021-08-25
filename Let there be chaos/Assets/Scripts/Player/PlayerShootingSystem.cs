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
            player.weaponUseTime = 0.4f;
            player.weaponUseProjectile = classic;
            player.weaponUseNormally = true;

            player.weaponProjectileSpeed = 100f;
            player.weaponDamage = 1f;
        } else if (player.weaponType == "Rifle")
        {
            player.weaponUseTime = 0.15f;
            player.weaponUseProjectile = classic;
            player.weaponUseNormally = true;

            player.weaponProjectileSpeed = 100f;
            player.weaponDamage = 0.5f;
        }
        else if (player.weaponType == "Machinegun")
        {
            player.weaponUseTime = 0.05f;
            player.weaponUseProjectile = classic;
            player.weaponUseNormally = true;

            player.weaponProjectileSpeed = 100f;
            player.weaponDamage = 0.05f;
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
                    Instantiate(player.weaponUseProjectile, firePoint.position, firePoint.rotation);
                }
            }
        }
    }
}
