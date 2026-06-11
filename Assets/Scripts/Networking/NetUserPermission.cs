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
        protected static NetUserPermission instance = null;

        #region Synced and Network Vars
        // network and synced variables
        [SyncVar] protected bool guestCanEdit = false;
        [SyncVar] protected bool guestCanRecord = false;

        #endregion Synced and Network Vars
        #endregion Vars

        #region Methods
        protected virtual void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
            }

            else
            {
                Destroy(gameObject);
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
            if (isOwned && isServer)
            {
                guestCanEdit = !guestCanEdit;
                // request the permission be toggeled via command
                //CmdToggleGuestCanEdit();
            }


        }

        // command to request server toggle permission 
        // [Command] protected virtual void CmdToggleGuestCanEdit()
        // {
        //     if (isServer)
        //     {
        //         guestCanEdit = !guestCanEdit;
        //     }
        // }
        #endregion Methods

        #region Accessors
        

        public static NetUserPermission Instance
        {
            get
            {
                return instance;
            }
        }

        public static bool GuestCanEdit
        {
            get
            {
                return instance.guestCanEdit;
            }

        }

        public static bool GuestCanRecord
        {
            get
            {
                return instance.guestCanRecord;
            }
        }
        #endregion Accessors
    }
}