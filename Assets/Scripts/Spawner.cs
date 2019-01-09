using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int lifeTime;
    public float spawnerLifeTime;
    public float currentTime;
    
    public GameObject tomatoMonster;
    
    
	// Use this for initialization
	void Start () {
        currentTime = lifeTime;

		
	}
	
	// Update is called once per frame
	void Update () {
        SpawnTomato();
        
            transform.localScale =new Vector3(currentTime/2,currentTime/2,0);
       
    }

    public void SpawnTomato()
    {
        currentTime -= Time.deltaTime;
        spawnerLifeTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            Instantiate(tomatoMonster, transform.position, Quaternion.identity);
            currentTime = lifeTime;
        }
        if (spawnerLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
