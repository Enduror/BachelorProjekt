using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

    // hearthContainers
    public GameObject hearthContrainer;
    public Transform spawnHealthPoint;
    public Vector3 currentLocation;
    public PlayerController player;
   

    // achievmentPanel 
    public Animator anim;
    public GameObject achievementPanel;


    public GameObject restartButton;
    public GameObject QuitButton;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public GameObject transitionScreen;
    private void Awake()
    {
        transitionScreen.SetActive(true);
    }
    public void Start()
    {
        //achievementPanel.SetActiv(true);
    }

    private void Update()
    {
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
            restartButton.SetActive(true);
            QuitButton.SetActive(true);
        }

    }

    public void AchievementPanel()
    {
        anim.SetTrigger("Panel");
    }

    
}
