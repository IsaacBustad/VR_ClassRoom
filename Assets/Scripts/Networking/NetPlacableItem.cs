// Created By   :   Isaac Bustad
// Created      :   5/30/2026

using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;



namespace BugFreeProductions.Tools
{

    public class NetPlacableItem : PlacableFactoryItem
    {
        #region Vars
        protected NetworkIdentity ni = null;
        #endregion Vars

        #region Methods
        public override void RemoveItem()
        {
            if (ni.isServer)
            {
                NetworkServer.Destroy(gameObject);
            }
        }

        protected override void CollectVars()
        {
            ni = GetComponent<NetworkIdentity>();
            base.CollectVars();
            // // get and default Rigidbody
            // rb = GetComponent<Rigidbody>();
            // rb.freezeRotation = true;

            // // collect bodyScript
            // body = GetComponent<PlacableFactoryItemBody>();
        }
        #endregion Methods
    }
}