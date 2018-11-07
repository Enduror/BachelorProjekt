using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    public int health;
    public int startHealth;
    public EventController ec;
    
    
	// Use this for initialization
	void Start () {
        health = startHealth;
        ec = FindObjectOfType<EventController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            SpecialDeath();
            Destroy(gameObject);            
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;     
    }
    public void SpecialDeath()
    {
        if (this.name == "Dummy")
        {
            ec.dummyCounter++;
        }       
    }
}
