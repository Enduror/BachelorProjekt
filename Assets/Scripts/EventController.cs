using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventController : MonoBehaviour {

  
    public int dummyCounter;
    public int dummyQuest;

    public int pressedPlatesCounter;
    public int trainingRoomQuest;

    public PlayerController player;
    public GameObject TrainingRoomExit;
    public GameObject WeaponExit;
    public GameObject weaponPodium;
    public MessageBord messageBoard;
    public SpriteMask devMask;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        Destroy(devMask);
    }

    void Update()
    {
        CheckForEvents();
    }

    public void CheckForEvents()
    {
        if (dummyCounter == dummyQuest)
        {           
            Destroy(WeaponExit);
           
        }

        if (pressedPlatesCounter == trainingRoomQuest)
        {            
            Destroy(TrainingRoomExit);
        }
      
    }

    public void AwakeWeapon()
    {
        player.ActivateWeapon();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        Application.Quit();
    }




}
