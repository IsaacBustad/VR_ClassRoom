// Created By   :   Isaac Bustad
// Created      :   6/8/2026

using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace BugFreeProductions.Tools
{
    public class NetGuestPermissionManager : NetworkBehaviour
    {
        #region Vars
        protected static NetGuestPermissionManager instance = null;

        // actions that need to be run on variable updates
        public event Action<NetGuestPermission> OnPermissionsChanged;

        #region Synced and Network Vars
        // network and synced variables
        [SyncVar(hook = nameof(OnPermissionDataChanged))] NetGuestPermission netGuestPermission = new NetGuestPermission();


        #endregion Synced and Network Vars
        #endregion Vars

        #region Methods
        // Write the matching hook method
        protected virtual void OnPermissionDataChanged(NetGuestPermission oldData, NetGuestPermission newData)
        {
            // Optional: Protect against unnecessary execution if the data didn't actually change
            // (Note: Structs compare all fields automatically when using Equals or == if implemented)
            if (oldData.Equals(newData)) return;

            // Broadcast the update to your local UI subscribers
            OnPermissionsChanged?.Invoke(netGuestPermission);
            Debug.Log("Data = bool can edit : " + netGuestPermission.guestCanEdit);
        }
        protected virtual void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
            }

            // else
            // {
            //     Destroy(gameObject);
            // }


        }
        public override void OnStartClient()
        {
            OnPermissionsChanged?.Invoke(netGuestPermission);
        }

        // Only the owner should be able to request 
        // the guest placing permission changing
        public virtual void ToggleGuestCanEdit()
        {
            // check if is owned by the local object 
            if (isServer)
            {
                NetGuestPermission nNetGuestPermission = netGuestPermission;

                nNetGuestPermission.guestCanEdit = !nNetGuestPermission.guestCanEdit;

                netGuestPermission = nNetGuestPermission;
                // request the permission be toggled via command
                //CmdToggleGuestCanEdit();
            }


        }

        public virtual void ToggleGuestCanRecord()
        {
            // check if is owned by the local object 
            if (isServer)
            {
                NetGuestPermission nNetGuestPermission = netGuestPermission;

                nNetGuestPermission.guestCanRecord = !nNetGuestPermission.guestCanRecord;

                netGuestPermission = nNetGuestPermission;
                // request the permission be toggled via command
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


        public static NetGuestPermissionManager Instance
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
                return instance.netGuestPermission.guestCanEdit;
            }

        }

        public static bool GuestCanRecord
        {
            get
            {
                return instance.netGuestPermission.guestCanRecord;
            }
        }
        #endregion Accessors
    }


}