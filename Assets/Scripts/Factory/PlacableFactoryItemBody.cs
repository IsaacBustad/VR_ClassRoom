// Isaac Bustad
// 2/4/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BugFreeProductions.Tools
{
    public class PlacableFactoryItemBody : MonoBehaviour
    {
        // Vars
        // List of body colliders that will be changed from trigger
        [SerializeField] protected List<Collider> bodColliders = new List<Collider>();
        [SerializeField] protected Rigidbody rb = null;


        // safe area trigger
        [SerializeField] GameObject safeArea = null;
        [SerializeField, Range(1,20)] protected float width = 1;
        [SerializeField, Range(1, 20)] protected float height = 1;

        // Methods
        protected virtual void OnEnable()
        {
            DefaultVars();
        }

        protected virtual void DefaultVars()
        {
            // freeze rb
            rb.freezeRotation = true;

            // set all coliders to trigger to avoid colissions
            if (bodColliders.Count > 0)
            {
                foreach (Collider col in bodColliders)
                {
                    col.isTrigger = true;
                }
            }

            // ensure sfe area trigger is enabled
            safeArea.SetActive(true);

        }

        // final setup for all body components
        public virtual void FinalizeBody()
        {
            FinalizeBodyColiders();
            FinalizeSafeArea();
        }

        // final setup for body coliders
        protected virtual void FinalizeBodyColiders()
        {
            if (bodColliders.Count > 0)
            {
                foreach (Collider col in bodColliders)
                {
                    col.isTrigger = false;
                }
            }
        }

        // finalize / remove safe area trigger
        protected virtual void FinalizeSafeArea()
        {
            safeArea.SetActive(false);
        }


        // Accessors





    }
}