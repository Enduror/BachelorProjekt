using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRoom : MonoBehaviour
{

    public GameObject[] traps;
    // Use this for initialization
    void Start()
    {
        foreach (GameObject i in traps)
        {
            i.SetActive(false);
        }       
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (GameObject i in traps)
            {
                i.SetActive(true);
            }
        }
    }
}


    
