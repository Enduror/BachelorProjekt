using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBord : MonoBehaviour {

    public Animator messageBoard;
    public Text messageBoardText;
    public float timer;

	

public void OpenMessage(string text)
    {
        messageBoardText.text = text;
        messageBoard.SetTrigger("open");
    }
    public void CloseMessage()
    {
            messageBoard.SetTrigger("close");

    }
}

