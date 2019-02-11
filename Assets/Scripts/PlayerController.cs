using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance;

    // AUdioManager
    public AudioManager audioManager;
    //PlayerMovement
    public bool isAlive;
	public float moveSpeed;
    public Rigidbody2D rb;
    public Vector3 moveVector3;
    public Animator realPlayerAnim;
    private Vector2 playerDirection2D;
    private GameObject spawnPoint;


    //Hats

    public GameObject hat_Crown;
    public GameObject hat_StrawHat;
    public GameObject sunglases;

    //achievements

    public AchievmentDisplay achievmentDisplay;


    //particles
    public GameObject fireParticles;

    //PlayerDirection
    public float offset;
    public GameObject Weapon;
    
    //PlayerAttack
    
    public bool hasWeapon;

    //Player Health and Status.
    public int health;
    public int startHealth;
    public GameObject playerBlood;



    
    public int levelCounter;

    //MastermindS


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        health = startHealth;
        audioManager = FindObjectOfType<AudioManager>();
        
    }

    private void Start()
    {
        levelCounter = 1;
        hasWeapon = false;
        fireParticles.GetComponent<FireWeapon>().CheckForWeapon();
        Weapon.SetActive(false);
        DataToSaveScript.PerfectRun_SaveValue = true;
       

       

        isAlive = true;
        //audioManager.Play("sound_player_idle");
       
    }

    //Physics

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerDirection();     

    }
    private void Update()
    {
        if (achievmentDisplay == null&& levelCounter<2)
        {
            try
            {
                achievmentDisplay = GameObject.FindGameObjectWithTag("StepOnTrapsAchievement").GetComponent<AchievmentDisplay>();
            }
            catch
            {

            }
        }

        if (spawnPoint == null) { 
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
         }
        

    }


    private void PlayerMovement()
    {
        if (isAlive)
        {
            
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            if (x != 0 || y != 0)
            {               
                realPlayerAnim.SetBool("isRunning",true);
                audioManager.Play("sound_player_idle");

            }
            else
            {               
                realPlayerAnim.SetBool("isRunning", false);
                audioManager.Play("sound_player_running");
                DataToSaveScript.IdleTime_SaveValue += Time.deltaTime;
                
            }
            transform.Translate(x, y, 0);
            moveVector3 = new Vector3(x, y, 0);
            playerDirection2D = new Vector2((transform.position.x + moveVector3.x * moveSpeed * Time.deltaTime), (transform.position.y + moveVector3.y * moveSpeed * Time.deltaTime));
            rb.MovePosition(playerDirection2D);
        }
    }


    public void PlayerDirection()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotZ+offset);
    }

  

    //public void PlayerAttack()
    //{
    //    if (isAlive)
    //    {
    //        if (timeBtwAttack <= 0)
    //        {
    //            if (Input.GetMouseButton(0) && hasWeapon == true)
    //            {

    //                camAnim.SetTrigger("shake");
    //                playerAnim.SetTrigger("attack");


    //                //Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, range, whatIsEnemy);
    //                //for (int i = 0; i < enemiesToDamage.Length; i++)
    //                //{
    //                //    enemiesToDamage[i].GetComponentInParent<HealthSystem>().TakeDamage(damage);
    //                //    Destroy(Instantiate(dummyBlood, enemiesToDamage[i].transform.position, enemiesToDamage[i].transform.rotation), 2);
    //                //}
    //                timeBtwAttack = startTimeBtwAttack;
    //            }
    //        }
    //        else
    //        {
    //            timeBtwAttack -= Time.deltaTime;
    //        }
    //    }
        
    //}    

    public void TakeDamage(int damage)
    {

        health -= damage;
        Destroy(Instantiate(playerBlood, transform.position, transform.rotation), 2);

        DataToSaveScript.DamageReceived_SaveValue += damage;

        if (health <= 0)
        {

            DataToSaveScript.LevelPlayerDied_SaveValue.Add(SceneManager.GetActiveScene().name);
            DataToSaveScript.PlayerDeathCounter_SaveValue ++;
            DataToSaveScript.PerfectRun_SaveValue = false;
            
            audioManager.StopAll();

            audioManager.Play("sound_player_death");
            //GetComponentInChildren<SpriteRenderer>().enabled = false;

            try
            {
                achievmentDisplay.playerDiedRecently = true;                
            }
            catch
            {
            }
           
            
            DisableChildrenOnDeath();
                        
        }
        else
        {
            audioManager.Play("sound_player_hurt");
        }
        
    }

    public void DisableChildrenOnDeath()
    {
        GetComponentInChildren<Rigidbody2D>().simulated = false;
        isAlive = false;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }  
    public void ActivateChildrenOnStart()
    {
        GetComponentInChildren<Rigidbody2D>().simulated = true;
        isAlive = true;
        foreach (Transform child in transform)
        {
            
                child.gameObject.SetActive(true);
            
            
        }
        transform.position = spawnPoint.transform.position;
        health = startHealth;
        if (levelCounter <= 5)
        {
            hasWeapon = false;
            fireParticles.GetComponent<FireWeapon>().CheckForWeapon();
            Weapon.SetActive(false);
        }
        
    }

    public void ActivateWeapon()
    {
        hasWeapon = true;
        fireParticles.GetComponent<FireWeapon>().CheckForWeapon();
        Weapon.SetActive(true);
    }

    public void ActivateCrownMode()
    {
        hat_Crown.SetActive(true);
        hat_StrawHat.SetActive(false);

    }
    public void ActivateStrawHatMode()
    {
        hat_StrawHat.SetActive(true);
        hat_Crown.SetActive(false);
    }

    public void ActivateSunglases()
    {
        sunglases.SetActive(true);
    }

   
}
