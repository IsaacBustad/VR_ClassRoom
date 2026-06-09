// Created By   :   Isaac Bustad
// Created      :   6/8/2026

using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace BugFreeProductions.Tools
{
    public class NetUserPermission : NetworkBehaviour
    {
        #region Vars
        protected NetUserPermission instance = null;

        #region Synced and Network Vars
        // network and synced variables
        [SyncVar] protected bool guestCanPlace = false;

        #endregion Synced and Network Vars
        #endregion Vars

        #region Methods
        protected virtual void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
            }


        }
        public override void OnStartClient()
        {

        }

        // Only the owner should be able to request 
        // the guest placing permission changing
        public virtual void ToggleGuestCanPlace()
        {
            // check if is owned by the local object
            if (isOwned)
            {
                // request the permission be toggeled via command
                CmdToggleGuestCanPlace();
            }


        }

        // command to request server toggle permission 
        [Command] protected virtual void CmdToggleGuestCanPlace()
        {
            if (isServer)
            {
                guestCanPlace = !guestCanPlace;
            }
        }
        #endregion Methods
    }
}