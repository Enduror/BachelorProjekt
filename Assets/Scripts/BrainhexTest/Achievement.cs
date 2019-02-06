using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum AchievmentType
{    
    SOLVEPUZZLES,
    COLLECTHAT,
    DESTROYVASES,    
    HITTHEWALL,
    FINDSECRETS,
    SPEEDRUN,
    MASSOCHIST,
    GATHERHEALTH,
    DONTDIE,
    KILLBOSSWITHOUTWEAPON,
    SECONDLAP, 
    HOTFORK,
    TEST1,
    

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
