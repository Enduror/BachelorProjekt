using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievmentDisplay : MonoBehaviour {

    public Achievement achievment;

    public AudioManager audioManager;

    public PuzzleManager puzzleManager;

    public int wallHitCount;
    
    public Text questText;
    public Text progressText;
    public Image image;
    public Image checkMark;
    public Image xMark;
    
    public int currentProgress;
    public int targetProgress;

    public bool achievementIsDone;
    public bool isDone;

    public PlayerController player;

    public float timer;
    public float currentTime;

    // needs to be reset after game;

    public bool playerDiedRecently;

    public bool hitTheBoss;
    

    void Start () {
        audioManager = FindObjectOfType<AudioManager>();
        isDone = false;
        puzzleManager = FindObjectOfType<PuzzleManager>();
        achievementIsDone = false;

        player = FindObjectOfType <PlayerController>();
        playerDiedRecently = false;

        checkMark.enabled = false;
        xMark.enabled = false;
    



    }

    // The first part activates the Gui and is off after that! 
    private void Update()
    {
        if (achievment != null && isDone == false)
        {
            isDone = true;
           
            SetGui();

            //Sets Tags for this Achievement depending on the type
            if (achievment.achievementType == AchievmentType.HITTHEWALL)
            {
                gameObject.tag = "HitTheWallAchievement";
            }
            if (achievment.achievementType == AchievmentType.DESTROYVASES)
            {
                gameObject.tag = "DestroyVasesAchievement";
            }
            if (achievment.achievementType == AchievmentType.FINDSECRETS)
            {
                gameObject.tag = "FindSecretsAchievement";
            }
            if (achievment.achievementType == AchievmentType.MASSOCHIST)
            {
                gameObject.tag = "StepOnTrapsAchievement";
            }
            if (achievment.achievementType == AchievmentType.COLLECTHAT)
            {
                gameObject.tag = "CollectAHatAchievement";
            }
            if (achievment.achievementType == AchievmentType.SECONDLAP)
            {
                gameObject.tag = "SecondLap";
            }
            if (achievment.achievementType == AchievmentType.SPEEDRUN)                
            {
                gameObject.tag = "SpeedRun";
            }
            if (achievment.achievementType == AchievmentType.KILLBOSSWITHOUTWEAPON)
            {
                gameObject.tag = "NoWeaponAchievement";
            }
            if (achievment.achievementType == AchievmentType.HOTFORK)
            {
                gameObject.tag = "HotFork";
            }
        }

        if (!achievementIsDone)
        {
            //PuzzleSolveQuest called to often
            PuzzleSolver();

            //GatherHealthQuest called to often
            GatherHealth();
        }
    }  
    // sets the Guian the beginning
    public void SetGui()
    {
        currentProgress = achievment.currentProgress;
        targetProgress = achievment.targetProgress;

        questText.text = achievment.questText;
        progressText.text = achievment.currentProgress + "/" + achievment.targetProgress;       
    }


    // checks if the current puzzle is solved

    //PuzzleSolver MAstermind1

    public void PuzzleSolver()
    {
        if (achievment != null)
        {

        if (achievementIsDone == false)
        {
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
                CheckForProgress();
            }
        }
        
        }
    }

    // just updates the text
    public void UpdateGUI()
    {
        if (achievementIsDone == false)
        {            
            progressText.text = currentProgress + "/" + targetProgress;
            
        }       
    }

    public void CheckForProgress()
    {
        if (currentProgress >= targetProgress && achievementIsDone==false)
        {
            achievementIsDone = true;
            progressText.text = "";            
            audioManager.Play("sound_achievements_done");
            checkMark.enabled = true;
            
        }
    }


    //Hit the Wall Achievement  is called in weapon script
    public void WallHitCounter()
    {       
        if (achievment.achievementType == AchievmentType.HITTHEWALL)
        {           
                currentProgress++;
                UpdateGUI();
                CheckForProgress();
            
        }
    }

    //Kill Tomato Script is called in tomato/tomate healthsystem script
    public void KillVaseCounter()
    {
        if (achievment.achievementType == AchievmentType.DESTROYVASES) 
        {            
            currentProgress++;
            UpdateGUI();
            CheckForProgress();
        }
    }


    //Gather Health Function

    public void GatherHealth()
    {
        if (achievment != null)
        {

        if (achievment.achievementType == AchievmentType.GATHERHEALTH)
        {
            if (currentTime <= 0)
            {
                // no need to ask for max health cause its in the achievement class

                currentProgress = player.health;
                currentTime = timer;
                UpdateGUI();
                CheckForProgress();
            }
            currentTime -= Time.deltaTime;
        }
        }
    }
    //FindSecrets Achievement
    public void FindSecret()
    {
        if (achievment.achievementType == AchievmentType.FINDSECRETS)
        {
            currentProgress++;
            UpdateGUI();
            CheckForProgress();
        }
    }

    public void SteppedOnSpike()
    {
        if (achievment.achievementType == AchievmentType.MASSOCHIST)
        {
            if (playerDiedRecently == true)
            {
                currentProgress = 0;
                UpdateGUI();
                playerDiedRecently = false;
            }
            else
            {
                currentProgress++;
                UpdateGUI();
                CheckForProgress();
            }
        }
    }

    public void FoundSecretLevel()
    {
        if (achievment.achievementType == AchievmentType.COLLECTHAT)
        {           
            currentProgress++;            
            UpdateGUI();
            CheckForProgress();
        }
    }
    public void SecondLap()
    {
        if (achievment.achievementType == AchievmentType.SECONDLAP)
        {
            currentProgress++;
            UpdateGUI();
            CheckForProgress();
        }
    }
    public void UnderAMinute()
    {
        if (achievment.achievementType == AchievmentType.SPEEDRUN)
        {
            currentProgress++;
            UpdateGUI();
            CheckForProgress();
        }
    }

    public void NoWeaponBoss()
    {
        if(achievment.achievementType== AchievmentType.KILLBOSSWITHOUTWEAPON)
        {
            if (!hitTheBoss)
            {
                currentProgress++;
                UpdateGUI();
                CheckForProgress();
            }else
            {
                xMark.enabled = true;
            }
        }
    }

    public void HotFork()
    {
        if (achievment.achievementType == AchievmentType.HOTFORK)
        {
            currentProgress++;
            UpdateGUI();
            CheckForProgress();
        }
    }
}
