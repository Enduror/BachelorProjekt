﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    public int damage = 1;
    public GameObject tomatoBlood;
    public GameObject wallEmiter;

    public Transform tip;
    public Vector2 bloodDirection;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        //anim.SetTrigger("shake");
        if (collision.GetComponentInParent<Transform>().name == "Ground")
        {            
            anim.SetTrigger("shake");
            Destroy(Instantiate(wallEmiter, tip.position, tip.rotation), 10);
        }


        if (collision.GetComponent<Collider2D>().gameObject.layer==LayerMask.NameToLayer("Enemy"))
        {
            anim.SetTrigger("shake");
            collision.GetComponentInParent<HealthSystem>().TakeDamage(damage);
            Vector3 relativePos = collision.GetComponent<Transform>().position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            Destroy(Instantiate(tomatoBlood, collision.transform.position, rotation), 10);            
        }
        
    }
}
