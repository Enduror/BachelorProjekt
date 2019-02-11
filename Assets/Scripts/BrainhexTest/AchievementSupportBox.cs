using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSupportBox : MonoBehaviour
{
    public AchievmentDisplay achievmentDisplay;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            achievmentDisplay=GameObject.FindGameObjectWithTag("SecondLap").GetComponent<AchievmentDisplay>();
        }
        catch
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCollider"))
        {
           if( achievmentDisplay != null)
            {
                achievmentDisplay.SecondLap();
            }
            DataToSaveScript.BladeRun_SaveValue = true;
        }
            
    }
}
