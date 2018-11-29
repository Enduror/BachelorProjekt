using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSide : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().TakeDamage(1);
        }
        if(collision.tag== "Weapon")
        {
           // collision.GetComponent<WeaponScript>().Ignite();
        }
    }

}
