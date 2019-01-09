using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wubble : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {

        GetComponent<Transform>().transform.localScale += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(0, 0.1f), 0);
        anim = GetComponent<Animator>();
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollider")
        {
            anim.SetTrigger("Wuble");
        }
    }
	

	
}
