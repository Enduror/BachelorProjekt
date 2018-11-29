﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    public int damage = 1;
    public GameObject tomatoBlood;

    public Transform tip;

    public Vector2 bloodDirection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.layer==LayerMask.NameToLayer("Enemy"))
        {

            collision.GetComponentInParent<HealthSystem>().TakeDamage(damage);
            Vector3 relativePos = collision.GetComponent<Transform>().position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            Destroy(Instantiate(tomatoBlood, collision.transform.position, rotation), 10);
            
        }
        //enemiesToDamage[i].GetComponentInParent<HealthSystem>().TakeDamage(damage);
        //Destroy(Instantiate(dummyBlood, enemiesToDamage[i].transform.position, enemiesToDamage[i].transform.rotation), 2);
    }
}
