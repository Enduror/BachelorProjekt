using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour {

    public Animator anim;
    public Color pressedColor;
    public bool isPressed;

    public void Start()
    {
     anim=GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            anim.SetTrigger("pop");
            GetComponent<SpriteRenderer>().color = pressedColor;
            isPressed = true;
        }
    }
}
