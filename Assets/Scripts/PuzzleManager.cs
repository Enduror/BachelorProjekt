using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {
    public int progress;

    public bool firstPuzzleDone;
    public bool secondPuzzleDone;
    public bool thirdPuzzleDone;

    

    public GameObject pickUp;

    public string puzzle;

    public AudioManager audioManager;

    public PlayerController playerController;
    public void Start()
    {
        progress = 0;
        audioManager = FindObjectOfType<AudioManager>();
        playerController = FindObjectOfType<PlayerController>();
    }


    // Update is called once per frame
    private void Update()
    {
        PuzzleSwitch();
    }
    

    public void PuzzleSwitch()
    {          
        switch (progress)
        {
            case 0:              

                if (Input.GetKeyDown(KeyCode.N))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                    //Play Aha!!  Sound
                }

                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.K))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                 
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }                    
                break;
            case 3:
                // puzzle done, reward with something
                progress++;
                firstPuzzleDone = true;
                audioManager.Play("sound_achievements_done");
                SpawnItem();
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.L))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                 
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.O))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");

                }
                   
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.X))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                  
                break;
            case 7:

                secondPuzzleDone = true;
                progress++;
                audioManager.Play("sound_achievements_done");
                SpawnItem();
                break;
            case 8:

                if (Input.GetKeyDown(KeyCode.T))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                   
                break;
            case 9:
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                  
                break;
            case 10:
                if (Input.GetKeyDown(KeyCode.U))
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                    
                break;
            case 11:
                thirdPuzzleDone = true;
                audioManager.Play("sound_achievements_done");
                SpawnItem();
                progress++;
                // reward ++;
                break;
        }
    }

    public void SpawnItem()
    {
        
        Instantiate(pickUp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+5, 0), Quaternion.identity);        
    }
}


