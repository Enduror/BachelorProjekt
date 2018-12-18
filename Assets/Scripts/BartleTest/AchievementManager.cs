using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {
    public Achievement[] achievementArray;
    public Achievement[] currentAchievement;
    public GameObject[] text;
    public GameObject[] slider;

    
	// Use this for initialization
	void Start () {
        for (int i = 0; i < achievementArray.Length; i++)
        {
            var lastLevel = Random.Range(0, achievementArray.Length);
            currentAchievement[i] = achievementArray[lastLevel];
            text[i].GetComponent<Text>().text = currentAchievement[i].achievementText;

        }
	}
    
}
