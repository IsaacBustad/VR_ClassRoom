// Isaac Bustad
// 8/1/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMannager : MonoBehaviour 
{
    // Vars
    // for singalton
    static private GameMannager instance;

    // for opperations
    //protected RacerInputBridge[] racerInputBridges = new RacerInputBridge[0];

    // for settings
    //protected RacerSetting[] racerSettings;


    // Methods
    
    


    // Accessors
    //public RacerInputBridge[] RacerInputBridges { get { return racerInputBridges; } }

    // for singalton
    static public GameMannager GM 
    { 
        get 
        { 
            if (instance == null)
            {
                GameObject nOBJ = new GameObject("GameMannager");
                instance = nOBJ.AddComponent<GameMannager>();

                // Do Not Destroy So Game Mannager Is Percistant
                DontDestroyOnLoad(nOBJ);
            }
            
            return instance; 
        } 
    }



}
