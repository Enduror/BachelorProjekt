using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingRoomPressurePlate : MonoBehaviour {

    public EventController EC;
    public Color PressedButtonColor;
    public SpriteRenderer childSprite;


    public bool isPressed;


    public BoxCollider2D pressurePlate;

    public void Start()
    {
        EC = FindObjectOfType<EventController>();        
        childSprite = GetComponentInChildren<SpriteRenderer>();
        pressurePlate = GetComponent<BoxCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {            
            childSprite.color = PressedButtonColor;
            EC.pressedPlatesCounter++;
            pressurePlate.enabled = false;
        }

    }
}
