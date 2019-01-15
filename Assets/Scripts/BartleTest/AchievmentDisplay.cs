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
    
    public int currentProgress;
    public int targetProgress;

    public bool isDone;

    void Start () {
        isDone = false;       
	}
    private void Update()
    {
        if (achievment != null && isDone == false)
        {
            isDone = true;
            SetGui();
        }
    }


    public void OnTomatoKill()
  {
        Debug.Log(achievment.achievementType);
        if (achievment.achievementType == AchievmentType.KILL)
        {
            currentProgress++;
        }
  }

    public void SetGui()
    {
        currentProgress = achievment.currentProgress;
        targetProgress = achievment.targetProgress;

        questText.text = achievment.questText;
        progressText.text = achievment.currentProgress + "/" + achievment.targetProgress;

        image = achievment.picture;
        checkMark = achievment.checkMark;
    }
}
