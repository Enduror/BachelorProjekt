using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBord : MonoBehaviour {

    public GameObject messageBoard;
    public Text messageBoardText;

    private void Start()
    {
        messageBoard = GameObject.FindGameObjectWithTag("MessageBox");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        messageBoard.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        messageBoard.SetActive(false);
    }


}

