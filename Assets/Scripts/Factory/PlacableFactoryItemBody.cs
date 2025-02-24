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
        [SerializeField] protected PlacableFactoryItemSafeArea safeArea = null;

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
            // activate rb interections
            rb.freezeRotation = false;
            rb.useGravity = true;

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
            safeArea.PositionAndRotateBody(aGlobePos, aLookPos, height, CalcNewRot(aLookPos));
        }

        protected virtual void PositionBody(Vector3 aGlobePos)
        {
            Vector3 nPos = aGlobePos;

            nPos.y += height / 2;
            bodyObject.position = nPos;
        }

        protected virtual void RotateBody(Vector3 aLookPos)
        {
            

            bodyObject.transform.rotation = CalcNewRot(aLookPos);

        }

        protected virtual Quaternion CalcNewRot(Vector3 aLookPos)
        {
            // find target rotation
            rotHelper.LookAt(aLookPos);

            // create new rot
            Vector3 nRot = rotHelper.eulerAngles;

            // adjust rot
            nRot.z = 0;
            nRot.x = 0;

            Quaternion nQ = Quaternion.Euler(nRot);
            return nQ;
        }


        #endregion


        // Accessors





    }
}