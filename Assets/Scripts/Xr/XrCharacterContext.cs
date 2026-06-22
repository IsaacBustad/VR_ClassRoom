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
        [SerializeField] private XRBaseControllerInteractor leftHandGrabInteractor;
        [SerializeField] private XRBaseControllerInteractor rightHandGrabInteractor;

        protected XrCharacterState curCharacterState;
        //protected XrCharacterState buildCharacterState = new;
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

        #endregion Accessors
    }
}