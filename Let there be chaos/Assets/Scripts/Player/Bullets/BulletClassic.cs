using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClassic : MonoBehaviour
{

    public GameObject particleEffect;

    public float speed;
    public float damage;

    public float lifeTime;
    
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        PlayerMain player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMain>();
        speed = player.weaponProjectileSpeed;
        damage = player.weaponDamage;

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 velocity = mousePosition - rb.position;
        velocity.Normalize();
        rb.velocity = velocity * speed;

        Invoke("DestroyBullet", lifeTime);
    }

   void DestroyBullet()
    {
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            DestroyBullet();
        }
    }
}
