using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {	

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Crown" && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().ActivateCrownMode();
        }
    }
}
