// Isaac Bustad
// 2/4/2025


using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace BugFreeProductions.Tools
{
    public class FactoryItemPlacer : MonoBehaviour
    {
        // Vars
        [SerializeField] protected string itemID = "NA";
        [SerializeField] protected AbstractFactory_SCO itemFactory = null;



        // Methods
        // public for input testing
        public virtual void UsePlacer(InputAction.CallbackContext aCon)
        {
            UsePlacer();
        }

        public virtual void UsePlacer()
        {
            
        }



        // Accessors




    }
}