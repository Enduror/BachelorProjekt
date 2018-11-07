 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {
    public string messageToDisplay;
    public MessageBord messageBoard;
	// Use this for initialization
	void Start () {
        messageBoard = FindObjectOfType<MessageBord>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            messageBoard.OpenMessage(messageToDisplay);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            messageBoard.CloseMessage();
        }
    }
}
