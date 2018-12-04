using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSide : MonoBehaviour {

    public GameObject weaponFire;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponentInParent<PlayerController>().TakeDamage(1);
        }
        if(collision.tag== "Weapon")
        {
            weaponFire.SetActive(true);
        }
    }

}
