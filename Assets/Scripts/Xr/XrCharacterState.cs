// Created By   :   Isaac Bustad
// Created      :   6/20/2026


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BugFreeProductions.Tools
{
    
    public class XrCharacterState
    {
        #region Vars
        protected XrCharacterContext xrcc = null;
        #endregion Vars


        #region Methods
        // Construct
        public virtual void BuildMode()
        {
            xrcc.CurCharacterState = xrcc.BuildCharacterState;
            xrcc.XRInteractionManager.enabled = false;
            xrcc.ItemPlacer.SetActive(false);
        }


        // Edit
        public virtual void EditMode()
        {
            xrcc.CurCharacterState = xrcc.EditCharacterState;
            xrcc.ItemPlacer.SetActive(true);
            xrcc.XRInteractionManager.enabled = false;
        }


        // Interact
        public virtual void InteractMode()
        {
            xrcc.CurCharacterState = xrcc.InteractCharacterState;
            xrcc.XRInteractionManager.enabled = true;
            xrcc.ItemPlacer.SetActive(false);
        }
        
        #endregion Methods


        

        
        // Build

        #region Constructors
        public XrCharacterState(XrCharacterContext aXRCC)
        {
            xrcc = aXRCC;
        }
        #endregion Constructors

        #region Accessors
        public bool IsBuildMode
        {
            get
            {
                return false;
            }
        }

        public bool IsEditMode
        {
            get
            {
                return false;
            }
        }

        public bool IsInteractMode
        {
            get
            {
                return false;
            }
        }

        #endregion Accessors
    }
}