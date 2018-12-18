using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour {
    public bool isBroken;
    public GameObject shadow;
    public GameObject vaseParticle;
    public Animator vaseAnim;
	// Use this for initialization
	void Start () {
        vaseAnim = GetComponent<Animator>();
        if (isBroken == true)
        {
            vaseAnim.Play("BrokenIdle");
            GetComponent<Collider2D>().enabled = false;
            if (shadow != null) { shadow.SetActive(false); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (isBroken == false && collision.tag == "Player"||collision.tag=="Weapon")
        {
            if (isBroken == false) { Destroy(Instantiate(vaseParticle, transform.position, Quaternion.identity), 2); }
           
            GetComponent<Collider2D>().enabled = false;
            vaseAnim.SetTrigger("Shatter");
            isBroken = true;
            //Destroy(gameObject, 4);
        }
        else if (isBroken == true && collision.tag == "Player")
        {
            vaseAnim.SetTrigger("Schutt");
        }


        if (shadow != null) { shadow.SetActive(false); }

        

        
    }


}
