using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Achievment", menuName = "Achievement")]
public class Achievement: ScriptableObject{


    public string questText;
    public string progressText;

    public int currentProgress;
    public int targetProgress;


    public Image picture;
    public Image checkMark;

    public void Awake()
    {
        progressText = currentProgress + " / " + targetProgress;
        checkMark.enabled = false;
    }
    public void AchievmentDone()
    {
        checkMark.enabled = true;
        progressText = " ";
    }
    public void UpdateScore()
    {
        progressText = currentProgress + " / " + targetProgress;
        if (currentProgress <= targetProgress)
        {
            AchievmentDone();
        }
    }




}
