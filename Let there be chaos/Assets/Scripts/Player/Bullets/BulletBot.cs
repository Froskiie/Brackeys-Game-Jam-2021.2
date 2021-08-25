using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBot : MonoBehaviour
{

    public GameObject particleEffect;

    public float speed;
    public float damage;
    public float lifeTime;

    private Transform player;
    private Transform self;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        self = GetComponent<Transform>();

        target = new Vector2(player.position.x, player.position.y);





        BaseBot BotStats = GameObject.FindGameObjectWithTag("Bot").GetComponent<BaseBot>();
        speed = BotStats.weaponProjectileSpeed;
        damage = BotStats.weaponDamage;

        
        

        //Vector2 velocity = target - rb.position;
        //velocity.Normalize();
        //rb.velocity = velocity * speed;

        Invoke("DestroyBullet", lifeTime);
    }
   void Update()
    {
        self.position = Vector2.MoveTowards(self.position, target, speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            DestroyBullet();
        }
    }
}
