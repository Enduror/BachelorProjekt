using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public HealthSystem hs;
    public Slider slider;

    public float startHealth;
    public float health;

    public float currentHealth;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (health == 0)
        {
            health = hs.health;
            startHealth = hs.startHealth;
        }

        CalculateHealth();
        slider.value = currentHealth;
	}
    public void CalculateHealth()
    {
        
         currentHealth= health  /startHealth;
    }
    
}
