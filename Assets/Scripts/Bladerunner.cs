using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bladerunner : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool startBladeRun;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (player == null)
        {
            try
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            catch { }        
        }
      
    }

    private void FixedUpdate()
    {
        if (startBladeRun)
        {
            StartMoving();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerCollider"))
        {
            collision.GetComponentInParent<PlayerController>().TakeDamage(10);
        }
    }
    public void StartMoving()
    {
        rb.velocity = new Vector3(0, -1, 0) * speed * 10 * Time.deltaTime;
    }
}
