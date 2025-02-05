// Isaac Bustad
// 2/4/25


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    public class PlacableFactoryItem : FactoryItem
    {
        // Var
        [SerializeField] protected PlacableFactoryItemBody body;

        // Components in body use get component to collect



        // Methods
        

        public virtual void FinalizePlacement()
        {
            if (body != null)
            {
                body.FinalizeBody();
            }
        }


        // Accessors





    }
}