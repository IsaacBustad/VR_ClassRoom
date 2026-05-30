// Created By   :   Isaac Bustad
// Created      :   5/30/2026

using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


namespace BugFreeProductions.Tools
{


    public class NetPlacableItems : PlacableFactoryItem
    {
        #region Vars
        //protected PlacableFactoryItem pfi = null;

        #endregion Vars

        #region Methods
        protected override void OnEnable()
        {
            base.OnEnable();
            //pfi = GetComponent<PlacableFactoryItem>();
        }

        #endregion Methods
    }
}