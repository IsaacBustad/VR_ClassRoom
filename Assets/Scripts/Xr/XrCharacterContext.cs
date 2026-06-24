using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


namespace BugFreeProductions.Tools
{
    
    public class XrCharacterContext : MonoBehaviour
    {
        #region Vars
        [Header("Hand Interactors")]
        [SerializeField] protected XRBaseControllerInteractor leftHandGrabInteractor;
        [SerializeField] protected XRBaseControllerInteractor rightHandGrabInteractor;

        [Header("Component to disable in states")]
        [SerializeField] protected XRInteractionManager xrInteractionManager;
        [SerializeField] protected GameObject itemPlacer;

        // states for context use
        protected XrCharacterState curCharacterState;
        protected XrCharacterState buildCharacterState;
        protected XrCharacterState editCharacterState;
        protected XrCharacterState interactCharacterState;

        private bool _isBuildMode = false;

        #endregion Vars

        #region Methods
        /// <summary>
        /// Call this when entering or exiting your Placement/Removal mode.
        /// </summary>
        public void SetBuildMode(bool active)
        {
            _isBuildMode = active;

            if (_isBuildMode)
            {
                // Disable grabbing entirely while placing/removing
                leftHandGrabInteractor.enabled = false;
                rightHandGrabInteractor.enabled = false;
                
                // (Optional) Enable your placement/removal lasers/tools here
            }
            else
            {
                // Re-enable standard XRI grabbing when back in play mode
                leftHandGrabInteractor.enabled = true;
                rightHandGrabInteractor.enabled = true;
            }
        }

        public virtual void BuildMode()
        {
            
        }
        #endregion Methods


        #region Accessors
        public XrCharacterState CurCharacterState
        {
            get
            {
                return curCharacterState;
            }

            set
            {
                curCharacterState = value;
            }
        }

        #region State Accessors
        public XrCharacterState BuildCharacterState
        {
            get
            {
                return buildCharacterState;
            }
        }

        public XrCharacterState EditCharacterState
        {
            get
            {
                return editCharacterState;
            }
        }

        public XrCharacterState InteractCharacterState
        {
            get
            {
                return interactCharacterState;
            }
        }

        #endregion State Accessors

        #region Component Accessors
        public XRInteractionManager XRInteractionManager
        {
            get
            {
                return xrInteractionManager;
            }
        }

        public GameObject ItemPlacer
        {
            get
            {
                return itemPlacer;
            }
        }
        #endregion Component Accessors

        #endregion Accessors
    }
}