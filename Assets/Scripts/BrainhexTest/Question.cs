using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question:MonoBehaviour{
    public TestManager testmanager;

    public Answer[] answerArray;
    //public string answer1;
    //public string answer2;
    //public string answer3;
    public string questionText;

    public void Start()
    {
        testmanager = FindObjectOfType<TestManager>();
    }

    public void CheckThisOut()
    {
        foreach (Answer i in answerArray)
        {
            if (i.isChecked)
            {
                if (i.playerType == "Achiever")
                {
                    testmanager.achieverScore++;
                }
                if (i.playerType == "Killer")
                {
                    testmanager.killerScore++;
                }
                if (i.playerType == "Explorer")
                {
                    testmanager.explorerScore++;
                }
            }
        }
    }

}
