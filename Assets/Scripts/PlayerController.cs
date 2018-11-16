using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    //PlayerMovement
    public bool isAlive;
	public float moveSpeed;
    public Rigidbody2D rb;
    public Vector3 moveVector3;

    //PlayerDirection
    public float offset;
    public GameObject Weapon;

    //PlayerAttacking
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPosition;
    public float range;
    public LayerMask whatIsEnemy;
    public int damage;
    public GameObject dummyBlood;
    public Animator camAnim;
    public Animator playerAnim;
    public bool hasWeapon;

    //Player Health and Status.
    public int health;
    public int startHealth;
    
   

    private void Awake()
    {
        health = startHealth;
    }

    private void Start()
    {
        hasWeapon = false;
        Weapon.SetActive(false);
        
        isAlive = true;
        
    }

    //Physics

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerDirection();
        PlayerAttack();

    }

    private void PlayerMovement()
    {
        if (isAlive)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            transform.Translate(x, y, 0);
            moveVector3 = new Vector3(x, y, 0);
            rb.MovePosition(new Vector2((transform.position.x + moveVector3.x * moveSpeed * Time.deltaTime), (transform.position.y + moveVector3.y * moveSpeed * Time.deltaTime)));
        }
    }


    public void PlayerDirection()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }



    public void PlayerAttack()
    {
        if (isAlive)
        {
            if (timeBtwAttack <= 0)
            {
                if (Input.GetMouseButton(0) && hasWeapon == true)
                {

                    camAnim.SetTrigger("shake");
                    playerAnim.SetTrigger("attack");


                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, range, whatIsEnemy);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponentInParent<HealthSystem>().TakeDamage(damage);
                        Destroy(Instantiate(dummyBlood, enemiesToDamage[i].transform.position, enemiesToDamage[i].transform.rotation), 2);
                    }
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        
    }    

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //GetComponentInChildren<SpriteRenderer>().enabled = false;

            DisableChildrenOnDeath();
            GetComponentInChildren<Rigidbody2D>().simulated = false;

            isAlive = false;
               
        }
    }

    public void DisableChildrenOnDeath()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }



    private void OnDrawGizmosSelected()
    {      
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position,range);
    }

    public void ActivateWeapon()
    {
        hasWeapon = true;
        Weapon.SetActive(true);
    }

   
}
