using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wubble : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Wuble");
        }
    }
	

	
}
