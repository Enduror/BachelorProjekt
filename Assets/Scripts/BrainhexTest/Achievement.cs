using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum AchievmentType
{    
    SOLVEPUZZLES,
    COLLECTHAT,
    DESTROYVASES,
    KILLTOMATOS,
    HITTHEWALL,
    FINDSECRETS,
    SPEEDRUN,
    MASSOCHIST,
    TEST1,
    TEST2,
    TEST3,

}

[CreateAssetMenu(fileName = "New Achievment", menuName = "Achievement")]
public class Achievement: ScriptableObject{

    public string questText;
    public string progressText;

    public int currentProgress;
    public int targetProgress;

    public bool inUse;


    public Image picture;
    public Image checkMark;   

    public AchievmentType achievementType;   

}
