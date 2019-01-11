using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievmentDisplay : MonoBehaviour {

    public Achievement achievment;

    public Text questText;
    public Text progressText;
    public Image image;
    public Image checkMark;
    Achievment myAchievement;




    void Start () {
        questText.text = achievment.questText;
        progressText.text = achievment.currentProgress+"/"+ achievment.targetProgress;

        image = achievment.picture;
        checkMark = achievment.checkMark;
        myAchievement = achievment.achievement;
	}

    public void ProgressFunction()
    {
        switch (myAchievement)
        {
          
        }
       
    
    }
	
}
