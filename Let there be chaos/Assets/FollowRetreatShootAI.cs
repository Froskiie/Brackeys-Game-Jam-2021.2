using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRetreatShootAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;
    public Transform Self;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


        Self = GetComponent<Transform>(); // ennemy transform
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Self.position, player.position) > stoppingDistance)
        {
            Self.position = Vector2.MoveTowards(Self.position, player.position, speed * Time.deltaTime);
        }
    }
}
