using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour {
    public string achievementText;
    public bool isDone;
    public string scoreText;

    public int currentScore;
    public int targetScore;

    public float time;

    public string playerType;

    public void Start()
    {
        time = 0;
    }
    public void Update()
    {
        time = Time.time;        
        if (currentScore >= targetScore)
        {
            isDone = true;
        }
    }
}
