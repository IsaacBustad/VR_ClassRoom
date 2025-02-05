// Isaac Bustad
// 2/5/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace BugFreeProductions.Tools
{
    public class PlacableFactoryItemSafeArea : MonoBehaviour
    {
        // Vars
        //colors
        [SerializeField] protected Color positiveColor = Color.white;
        [SerializeField] protected Color negativeColor = Color.white;

        [SerializeField] protected Material material = null;


        protected int objInTrig = 0;


        // Methods
        protected virtual void OnTriggerEnter(Collider other)
        {
            objInTrig ++;
        }

        protected virtual void OnTriggerExit()
        {
            objInTrig --;
        }

        protected virtual void Update()
        {
            if (objInTrig > 0)
            {
                material.color = negativeColor;
            }
            else if (objInTrig == 0)
            {
                material.color = positiveColor;
            }
        }



        // Accessors






    }
}