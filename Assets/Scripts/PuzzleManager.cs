using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {
    public int progress;

    public bool firstPuzzleDone;
    public bool secondPuzzleDone;
    public bool thirdPuzzleDone;

    

    public GameObject[] pickUp;

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

                if (Input.GetKeyDown(KeyCode.N)&& playerController.levelCounter == 4)
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                    //Play Aha!!  Sound
                }

                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.K) && playerController.levelCounter == 4)
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                 
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.P) && playerController.levelCounter == 4)
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
                DataToSaveScript.PuzzlesSolvedCounter_SaveValue++;
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.L) && playerController.levelCounter == 9)
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                 
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.O) && playerController.levelCounter == 9)
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");

                }
                   
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.X) && playerController.levelCounter == 9)
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
                DataToSaveScript.PuzzlesSolvedCounter_SaveValue++;
                break;
            case 8:

                if (Input.GetKeyDown(KeyCode.T) && playerController.levelCounter >= 12)
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                   
                break;
            case 9:
                if (Input.GetKeyDown(KeyCode.Z) && playerController.levelCounter >= 12)
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                  
                break;
            case 10:
                if (Input.GetKeyDown(KeyCode.U) && playerController.levelCounter >= 12)
                {
                    progress++;
                    audioManager.Play("sound_achievements_ohh");
                }
                    
                break;
            case 11:
                thirdPuzzleDone = true;
                audioManager.Play("sound_achievements_done");
                Instantiate(pickUp[2], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, 0), Quaternion.identity);
                progress++;
                DataToSaveScript.PuzzlesSolvedCounter_SaveValue++;
                DataToSaveScript.AllPuzzlesSolved_SaveValue=true;
                // reward ++;
                break;
        }
        if (progress >= 12 && playerController.levelCounter == 1)
        {
            progress = 0;
        }

        if (playerController.levelCounter == 9)
        {
            if (progress >= 4)
            {
                return;
            }
            else
            {
                progress = 4;
            }
        }
        if (playerController.levelCounter == 12)
        {
            if (progress >= 8)
            {
                return;
            }
            else
            {
                progress = 8;
            }
        }
    }

    public void SpawnItem()
    {
        var rng = Random.Range(0, 1);
        Instantiate(pickUp[rng], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+5, 0), Quaternion.identity);        
    }
}


