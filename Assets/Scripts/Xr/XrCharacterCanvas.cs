// Created By   :   Isaac Bustad
// Created      :   6/15/2026

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    
    public class XrCharacterCanvas : MonoBehaviour
    {
        #region Vars
        // needed to check and toggel permissions for guest
        protected NetUserPermission netUserPermission = null;

        // objects that should be enabled for the host
        [SerializeField] List<GameObject> hostUI = new List<GameObject>();

        // objects that should be enabled on guest
        [SerializeField] List<GameObject> guestUI = new List<GameObject>();

        // positive and negative colors
        [SerializeField] protected Color positiveColor = Color.green;
        [SerializeField] protected Color negativeColor = Color.red;
        #endregion Vars

        #region Methods
        protected virtual void OnEnable()
        {
            CollectVars();
            Setup();
        }

        protected virtual void CollectVars()
        {
            // collect the NetUserPermission for refference
            
        }

        public virtual void ToggleGuestCanRecord()
        {
            
        }

        public virtual void ToggleGuestCanEdit()
        {
            
        }

        protected virtual void Setup()
        {
            if (NetUserPermission.Instance.isServer)
            {
                
            }
            else
            {
                
            }
        }

        protected virtual void HostSetup()
        {
            
        }

        protected virtual void GuestSetup()
        {
            
        }



        #endregion Methods
    }
}