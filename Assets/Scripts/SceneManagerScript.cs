using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public GameObject saveData;

    public void LoadFirstLevel()
    {
        if (saveData.GetComponent<PlayerTypeAchievementSave>().primaryType != "")
        {
            DontDestroyOnLoad(saveData);
            SceneManager.LoadScene("Level1");
        }
        else
        {
            Debug.Log("cant load level yet");
        }
    }
    
    public void LoadTest()
    {
        Debug.Log("Test");
        SceneManager.LoadScene("BartleTest");
    }
    public void LoadGame()
    {
        Debug.Log("TutorialScene");
        SceneManager.LoadScene("TutorialScene");
    }

    public void RestartGame()
    {
        Debug.Log("ScreenReload");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
