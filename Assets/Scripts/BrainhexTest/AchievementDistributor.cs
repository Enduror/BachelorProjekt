using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementDistributor : MonoBehaviour {

    public GameObject[] layout;


    public Achievement[] randomAchievments;

    public Achievement[] seekerAchievements;
    public Achievement[] survivorAchievements;
    public Achievement[] daredevilAchievements;
    public Achievement[] mastermindAchievements;
    public Achievement[] conquerorAchievements;
    public Achievement[] socializerAchievements;
    public Achievement[] achieverAchievements;

    public string primaryPlayerType;
    public string secondaryPlayerType;

    public string seeker;
    public string survivor;
    public string daredevil;
    public string mastermind;
    public string conqueror;
    public string socializer;
    public string achiever;
    public string random;

    void Start()
    {
        try
        {
            primaryPlayerType = GameObject.FindGameObjectWithTag("PlayerType").GetComponent<PlayerTypeAchievementSave>().primaryType;
            secondaryPlayerType = GameObject.FindGameObjectWithTag("PlayerType").GetComponent<PlayerTypeAchievementSave>().secondaryType;
            SetLayout();
        }
        catch{
            primaryPlayerType = random;
            secondaryPlayerType = random;
           
        }
        
    }




    public void SetLayout()
    {
        
        if (primaryPlayerType == seeker)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = seekerAchievements[0];            
            layout[1].GetComponent<AchievmentDisplay>().achievment = seekerAchievements[1];
        }
        else if (primaryPlayerType == survivor)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = survivorAchievements[0];
            layout[1].GetComponent<AchievmentDisplay>().achievment = survivorAchievements[1];
        }
        else if (primaryPlayerType == daredevil)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = daredevilAchievements[0];
            layout[1].GetComponent<AchievmentDisplay>().achievment = daredevilAchievements[1];
        }
        else if (primaryPlayerType == mastermind)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = mastermindAchievements[0];           
            layout[1].GetComponent<AchievmentDisplay>().achievment = mastermindAchievements[1];
        }
        else if (primaryPlayerType == conqueror)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = conquerorAchievements[0];
            layout[1].GetComponent<AchievmentDisplay>().achievment = conquerorAchievements[1];
        }
        else if (primaryPlayerType == socializer)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = socializerAchievements[0];
            layout[1].GetComponent<AchievmentDisplay>().achievment = socializerAchievements[1];
        }
        else if (primaryPlayerType == achiever)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = achieverAchievements[0];
            layout[1].GetComponent<AchievmentDisplay>().achievment = achieverAchievements[1];
        }
        //SecondaryType

        if (secondaryPlayerType == seeker)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = seekerAchievements[0];            
        }

        else if (secondaryPlayerType == survivor)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = survivorAchievements[0];
        }

        else if (secondaryPlayerType == daredevil)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = daredevilAchievements[0];
        }
        else if (secondaryPlayerType == mastermind)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = mastermindAchievements[0];
        }
        else if (secondaryPlayerType == conqueror)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = conquerorAchievements[0];
        }
        else if (secondaryPlayerType == socializer)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = socializerAchievements[0];
        }
        else if (secondaryPlayerType == achiever)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = achieverAchievements[0];
        }
        


      


    }

}
