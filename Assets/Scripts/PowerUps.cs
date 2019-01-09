using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    private PlayerController player;
    public GameObject weapon;
    public AudioManager audioManager;
    public bool pickedUp;
   
    public int type;  // Type 0 Health  Type 1= Speed  //Typ 2=Power
   
	// Use this for initialization
	void Start () {

        player = FindObjectOfType<PlayerController>();
        weapon=GameObject.FindGameObjectWithTag("Weapon");
        audioManager = FindObjectOfType<AudioManager>();
       
    }

    public void PickUp()
    {
        if (pickedUp == false) { 
        pickedUp = true;
        if (type == 0)
        {
            player.health += 1;
            player.startHealth += 1;

        }
        if (type == 1)
        {
            player.moveSpeed += 2;
        }
        if (type == 2)
        {
            if (weapon.transform.localScale.x <= 1)
            {
                weapon.transform.localScale *= 1.3f;
            }
        }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollider")
        {
            audioManager.Play("sound_player_wow");
            PickUp();
            GetComponent<SpriteRenderer>().enabled=false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject,1);
        }
    }

}
