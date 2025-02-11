// Isaac Bustad
// 2/4/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace BugFreeProductions.Tools
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlacableFactoryItemBody : MonoBehaviour
    {
        // Vars
        // List of body colliders that will be changed from trigger
        [SerializeField, Tooltip("Assign coliders in inspector to be enabled for placement finalization")] 
        protected List<Collider> bodColliders = new List<Collider>();
        
        protected Rigidbody rb = null;


        // safe area trigger
        [SerializeField] protected GameObject safeAreaGO = null;
        [SerializeField] protected GameObject safeArea = null;

        [SerializeField] protected Transform bodyObject = null;
        [SerializeField] protected Transform rotHelper = null;

        [SerializeField, Range(1,20)] protected float width = 1;
        [SerializeField, Range(1, 20)] protected float height = 1;

        // Methods
        #region Default and Finalize

        protected virtual void OnEnable()
        {
            CollectVars();
            DefaultVars();
        }

        protected virtual void CollectVars()
        {
            rb = GetComponent<Rigidbody>();
        }

        protected virtual void DefaultVars()
        {
            // freeze rb
            //rb.freezeRotation = true;

            // set all coliders to trigger to avoid colissions
            if (bodColliders.Count > 0)
            {
                foreach (Collider col in bodColliders)
                {
                    col.enabled = false;
                }
            }

            // ensure sfe area trigger is enabled
            safeAreaGO.SetActive(true);

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
                    col.enabled = true;
                }
            }
        }

        // finalize / remove safe area trigger
        protected virtual void FinalizeSafeArea()
        {
            safeAreaGO.SetActive(false);
        }
        #endregion

        #region Align Object to Point and Rotation
        public virtual void PositionAndRotateBody(Vector3 aGlobePos, Vector3 aLookPos)
        {
            PositionBody(aGlobePos);
            //safeArea.PositionAndRotateBody
        }

        protected virtual void PositionBody(Vector3 aGlobePos)
        {
            Vector3 nPos = aGlobePos;

            nPos.y += height / 2;
            bodyObject.position = nPos;
        }

        protected virtual void RotateBody(Vector3 aLookPos)
        {

        }


        #endregion


        // Accessors





    }
}