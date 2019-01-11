using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum Achievment
{
    KILL,
    SECRETS,
    SPEEDRUN,
}

[CreateAssetMenu(fileName = "New Achievment", menuName = "Achievement")]
public class Achievement: ScriptableObject{


    public string questText;
    public string progressText;

    public int currentProgress;
    public int targetProgress;


    public Image picture;
    public Image checkMark;   

    public Achievment achievement;
   
 




}
