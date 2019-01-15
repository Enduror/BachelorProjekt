using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementDistributor : MonoBehaviour {

    public GameObject[] layout;

    public Achievement[] playerType1Achievments;
    public Achievement[] playerType2Achievments;
    public Achievement[] playerType3Achievments;

    public string primaryPlayerType;
    public string secondaryPlayerType;

    public string playerType1;
    public string playerType2;
    public string playerType3;

    void Start()
    {        
        primaryPlayerType = GameObject.FindGameObjectWithTag("PlayerType").GetComponent<PlayerTypeAchievementSave>().primaryType;
        secondaryPlayerType = GameObject.FindGameObjectWithTag("PlayerType").GetComponent<PlayerTypeAchievementSave>().secondaryType;
        SetLayout();
    }




    public void SetLayout()
    {
        if (primaryPlayerType == playerType1)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = playerType1Achievments[0];
            Debug.Log(layout[0].GetComponent<AchievmentDisplay>().achievment);
            layout[1].GetComponent<AchievmentDisplay>().achievment = playerType1Achievments[1];
        }
        else if (primaryPlayerType == playerType2)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = playerType2Achievments[0];
            layout[1].GetComponent<AchievmentDisplay>().achievment = playerType2Achievments[1];
        }
        else if (primaryPlayerType == playerType3)
        {
            layout[0].GetComponent<AchievmentDisplay>().achievment = playerType3Achievments[0];
            layout[1].GetComponent<AchievmentDisplay>().achievment = playerType3Achievments[1];
        }
        //SecondaryType

        if (secondaryPlayerType == playerType1)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = playerType1Achievments[0];            
        }

        else if (secondaryPlayerType == playerType2)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = playerType2Achievments[1];
        }

        else if (secondaryPlayerType == playerType3)
        {
            layout[2].GetComponent<AchievmentDisplay>().achievment = playerType3Achievments[2];
        }
    }

}
