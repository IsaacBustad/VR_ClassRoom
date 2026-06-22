// Created By   :   Isaac Bustad
// Created      :   6/22/2026

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace BugFreeProductions.Tools
{    
    public class NetXrInteractorBridge : MonoBehaviour
    {
        #region Vars
        [SerializeField] protected XRBaseInteractor leftXrInteractor;
        [SerializeField] protected XRBaseInteractor rightXrInteractor;

        [SerializeField] protected XRInteractionManager xRInteractionManager;
        #endregion Vars



        #region Methods
        protected virtual void OnEnable()
        {
            //xRInteractionManager.interactor += OnSelect;
            //leftXrInteractor.

            if (leftXrInteractor == null) return;
            leftXrInteractor.selectEntered.AddListener(OnGrab);
            leftXrInteractor.selectExited.AddListener(OnDrop);

            if (rightXrInteractor == null) return;
            rightXrInteractor.selectEntered.AddListener(OnGrab);
            rightXrInteractor.selectExited.AddListener(OnDrop);
        }

        

        protected  void OnGrab(SelectEnterEventArgs args)
        {
            GameObject grabbed = args.interactableObject.transform.gameObject;
            
            //grabbed.GetComponent<Networked>
        }

        private void OnDrop(SelectExitEventArgs args)
        {
            GameObject dropped = args.interactableObject.transform.gameObject;
            Debug.Log($"Dropped: {dropped.name}");
            // Handle network release logic here
        }
        #endregion Methods
    }
}