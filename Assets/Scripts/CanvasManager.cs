using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{

    // hearthContainers
    public GameObject hearthContrainer;
    public PlayerController player;
    public Button SaveAllDataButton;


    // achievmentPanel 
    public Animator anim;


    public GameObject menuePanel;
    public GameObject restartButton;
    public GameObject QuitButton;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;



   

    public GameObject transitionScreen;
    private void Awake()
    {
        // transitionScreen.SetActive(true);
    }
    public void Start()
    {

        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (player != null) {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (!player.isAlive)
        {
            menuePanel.SetActive(true);
        }

        }
        else
        {
            player = FindObjectOfType<PlayerController>();
        }
    }

}
