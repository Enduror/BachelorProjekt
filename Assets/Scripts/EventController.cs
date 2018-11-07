using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
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




}
