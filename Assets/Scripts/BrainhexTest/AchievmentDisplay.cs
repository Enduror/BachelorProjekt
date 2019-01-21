using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievmentDisplay : MonoBehaviour {

    public Achievement achievment;

    public AudioManager audioManager;

    public PuzzleManager puzzleManager;
    
    public Text questText;
    public Text progressText;
    public Image image;
    public Image checkMark;
    
    public int currentProgress;
    public int targetProgress;

    public bool isDone;

    void Start () {
        audioManager = FindObjectOfType<AudioManager>();
        isDone = false;
        puzzleManager = FindObjectOfType<PuzzleManager>();
        isDone = false;
	}

    // The first part activates the Gui and is off after that! 
    private void Update()
    {
        if (achievment != null && isDone == false)
        {
            isDone = true;
            Debug.Log("stuffhappens");
            SetGui();
        }
        
          //  PuzzleSolver();
       
    }  
    // sets the Guian the beginning
    public void SetGui()
    {
        
        currentProgress = achievment.currentProgress;
        targetProgress = achievment.targetProgress;

        questText.text = achievment.questText;
        progressText.text = achievment.currentProgress + "/" + achievment.targetProgress;

        image = achievment.picture;
        checkMark = achievment.checkMark;
    }


    // checks if the current puzzle is solved

    //PuzzleSolver MAstermind1

    public void PuzzleSolver()
    {
        Debug.Log(achievment.achievementType);
            if (achievment.achievementType == AchievmentType.SOLVEPUZZLES)
            {
                if (puzzleManager.firstPuzzleDone)
                {
                    puzzleManager.firstPuzzleDone = false;
                    currentProgress++;
                    UpdateGUI();

                }
                if (puzzleManager.secondPuzzleDone)
                {
                    puzzleManager.secondPuzzleDone = false;
                    currentProgress++;
                    UpdateGUI();
                }
                if (puzzleManager.thirdPuzzleDone)
                {
                    puzzleManager.thirdPuzzleDone = false;
                    currentProgress++;
                    UpdateGUI();
                }
            }
        
    }
    public void UpdateGUI()
    {        
        progressText.text= achievment.currentProgress + "/" + achievment.targetProgress;
    }

    public void CheckForProgress()
    {
        if (currentProgress >= targetProgress)
        {
            progressText.text = "";
            checkMark.enabled = true;
            audioManager.Play("sound_achievements_done");
            // Play 
        }
    }
}
