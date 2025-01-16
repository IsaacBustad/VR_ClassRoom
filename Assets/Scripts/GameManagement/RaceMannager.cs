// Isaac Bustad
// 8/1/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceMannager : MonoBehaviour
{
    // Vars
    //[SerializeField] private GameMannager gM;


    // Methods
    private void Awake()
    {
        SingleRaceManager();
        
    }

    // Make sure there is one Race Mannager
    protected void SingleRaceManager()
    {
        RaceMannager[] rms = FindObjectsOfType<RaceMannager>();
        if (rms.Length > 1)
        {
            Destroy(gameObject);
        }
        
    }

    // Accessors
}
