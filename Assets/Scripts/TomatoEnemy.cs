using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoEnemy : MonoBehaviour
{

    //TomatoMove
    public float moveSpeed;
    public float chaseRange;
    public float minChaseRange;
    public GameObject player;
    public PlayerController playerController;
   


    //TomatoAttack
    public GameObject playerBlood;
    public int damage;
    public float attackSpeed;
    public float StartAttackSpeed;



    public Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {      
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DistanceCalculator();
    }

    public void DistanceCalculator()
    {
        if (playerController.isAlive)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > minChaseRange && Vector2.Distance(transform.position, player.transform.position) < chaseRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.tag == "Player")
        {
            attackSpeed = StartAttackSpeed;
            Destroy(Instantiate(playerBlood, player.transform.position, Quaternion.identity), 2);
            playerController.TakeDamage(damage);
            Destroy(gameObject);


        }
    }



}
    
