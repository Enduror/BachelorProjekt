using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCanvasSingleton : MonoBehaviour
{
    public static AchievementCanvasSingleton Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
