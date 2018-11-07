using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour {

    
    public Color pressedColor;
    public bool isPressed;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = pressedColor;
            isPressed = true;
        }
    }
}
