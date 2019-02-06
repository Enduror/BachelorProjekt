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
            var rng = Random.Range(0, randomAchievments.Length - 2);
            layout[1].GetComponent<AchievmentDisplay>().achievment = randomAchievments[rng];
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
            Debug.Log("GotHere");
            var rng = Random.Range(0, randomAchievments.Length - 2);
            layout[1].GetComponent<AchievmentDisplay>().achievment = randomAchievments[rng];

            var  rng2 = Random.Range(0, randomAchievments.Length - 2);
            if (rng2 == rng)
            {
                rng2 = Random.Range(0, randomAchievments.Length - 2);
            }

            layout[0].GetComponent<AchievmentDisplay>().achievment = randomAchievments[rng2];


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
            var rng = Random.Range(0, randomAchievments.Length - 2);
            layout[2].GetComponent<AchievmentDisplay>().achievment = randomAchievments[rng];
            
        }
        else if (secondaryPlayerType == achiever)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = achieverAchievements[0];
        }


        // absicherung falls Typ 0 und 2 oder 0 und 1 sich gleichen dann rerole

        

            if (layout[0].GetComponent<AchievmentDisplay>().achievment.achievementType == layout[2].GetComponent<AchievmentDisplay>().achievment.achievementType || layout[1].GetComponent<AchievmentDisplay>().achievment.achievementType == layout[2].GetComponent<AchievmentDisplay>().achievment.achievementType)
            {
                var rng = Random.Range(0, randomAchievments.Length - 2);
                layout[2].GetComponent<AchievmentDisplay>().achievment = randomAchievments[rng];
            }

      

    }

}
