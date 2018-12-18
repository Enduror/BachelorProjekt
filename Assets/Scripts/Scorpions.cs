using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpions : MonoBehaviour {
    public Vector2 direction;
    public float duration;
    public float timer;
    public Color color;
    
    

	// Use this for initialization
	void Start () {
        color = Random.ColorHSV();
        GetComponentInChildren<SpriteRenderer>().color = color;
       
	}
	
	// Update is called once per frame
	void Update () {
        if (timer < 0)
        {
            timer = Random.Range(2, 4);
            direction = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));

            if (direction.x >= 0)
            {
                GetComponentInChildren<Transform>().localScale = new Vector2(-0.2f,0.2f);
            }
            else
            {
                GetComponentInChildren<Transform>().localScale = new Vector2(0.2f, 0.2f);
            }

        }
        timer -= Time.deltaTime;
        transform.Translate(direction*1/100);
	}
}
