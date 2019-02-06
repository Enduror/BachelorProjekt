using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonSystem : MonoBehaviour {

    public GameObject door;
    public TriggerPlate[] steppingStones;
    public GameObject[] dummys;
    public Animator anim;
    
    
    public void Start()
    {
        anim = door.GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (IsAllPressed()&&IsAllKilled())
        {
            door.GetComponent<Collider2D>().enabled = false;
            anim.SetTrigger("openDoor");
            GetComponent<AudioSource>().Play();
            Destroy(door,2);
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

    private bool IsAllKilled()
    {
        for (int i = 0; i < dummys.Length; i++)
        {
            if (dummys[i]!= null)
            {
                return false;
            }
        }

        return true;
    }
}
