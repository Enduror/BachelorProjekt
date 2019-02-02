using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bladerunner_StartBox : MonoBehaviour
{
    public GameObject deletedGround;
    public GameObject blades;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        blades.GetComponent<Bladerunner>().startBladeRun = true;
        deletedGround.SetActive(false);
    }
}
