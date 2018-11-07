using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonSystem : MonoBehaviour {

    public GameObject door;
    public TriggerPlate[] steppingStones;
      
    void Update()
    {
        if (IsAllPressed())
        {
            Destroy(door);
            Destroy(this);
        }
    }

    private bool IsAllPressed()
    {
        for (int i = 0; i <steppingStones.Length; i++)
        {
            if (steppingStones[i].isPressed == false)
            {
                return false;
            }
        }
        return true;
    }
}
