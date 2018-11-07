using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    // hearthContainers
    public GameObject hearthContrainer;
    public Transform spawnHealthPoint;
    public Vector3 currentLocation;
    public PlayerController playerController;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public GameObject transitionScreen;
    private void Awake()
    {
        transitionScreen.SetActive(true);
    }

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerController.health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }




}
