using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoEnemy : MonoBehaviour
{


    // AudioManager

    public AudioManager audioManager;
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
    public Animator animator;


    // Use this for initialization
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        var random = Random.Range(-0.3f, 0.3f);
        transform.localScale += new Vector3(random, random, 0);
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        animator = GetComponentInChildren<Animator>();
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
                animator.SetBool("isRunning", true);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.tag == "PlayerCollider")
        {            
            attackSpeed = StartAttackSpeed;
            Destroy(Instantiate(playerBlood, player.transform.position, Quaternion.identity), 2);
            playerController.TakeDamage(damage);
            Destroy(gameObject);


        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,30);
    }



}
    
