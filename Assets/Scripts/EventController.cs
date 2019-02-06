﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventController : MonoBehaviour {


   public bool menueIsOpen;
    public AudioManager audioManager;
    public Texture2D cursorTexture;
    private Vector2 cursorHotspot;

    public int dummyCounter;
    public int dummyQuest;

    public int pressedPlatesCounter;
    public int trainingRoomQuest;

  
    public GameObject TrainingRoomExit;
    public GameObject WeaponExit;
    public GameObject weaponPodium;
    public MessageBord messageBoard;
    
    public GameObject[] player;
    public PlayerController playerController;
    public GameObject finalBoss;
    public GameObject replayAllButton;
    public CanvasManager canvasManager;
    public GameObject achievments;

    public bool playerIsReal;

    private void Awake()
    {
        achievments = GameObject.FindGameObjectWithTag("Achievements");
        audioManager = FindObjectOfType<AudioManager>();
        player = GameObject.FindGameObjectsWithTag("Player");
        
        foreach (GameObject i in player)
        {
            if (i.name == "Player")
            {
                playerIsReal = true;
                playerController = player[0].GetComponent<PlayerController>();
                
            }

        }
        if (playerIsReal == true)
        {
            foreach (GameObject i in player)
            {
                if (i.name == "Player 1")
                {
                    Debug.Log("Gefunden");
                    Destroy(i);
                }

            }
        }
    }
       
    

    public void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        menueIsOpen = false;

        canvasManager.menuePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menueIsOpen = !menueIsOpen;
            canvasManager.menuePanel.SetActive(menueIsOpen);
            if (menueIsOpen)
            {
                Time.timeScale = 0;
                audioManager.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                audioManager.enabled = true;
            }
        }
    }

  

    public void AwakeWeapon()
    {
        playerController.ActivateWeapon();
    }

    public void RestartGame()
    {
        DataToSaveScript.NumberOfRestarts_SaveValue++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        audioManager.RestartAll();
        playerController.ActivateChildrenOnStart();
        Time.timeScale = 1;
        audioManager.enabled = true;
        
    }    

    public void ReplayAll()
    {
        DontDestroyOnLoad(achievments);
        SceneManager.LoadScene("Level1");
    }


    public void EndGame()
    {
        Application.Quit();
    }

    


    public void MouseScript()
    {
        // initialize mouse with a new texture with the
        // hotspot set to the middle of the texture
        // (don't forget to set the texture in the inspector
        
            
       

        // To check where your mouse is really pointing
        // track the mouse position in you update function
                
            Vector3 currentMouse = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(currentMouse);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            Debug.DrawLine(ray.origin, hit.point);
            
}

}
