using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {
    
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
