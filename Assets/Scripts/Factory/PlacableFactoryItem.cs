// Isaac Bustad
// 2/4/25


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    public class PlacableFactoryItem : FactoryItem
    {
        // Var
        protected PlacableFactoryItemBody body;
        protected Rigidbody rb;
        // Components in body use get component to collect



        // Methods
        #region Setup and Finalize placement
        public virtual void OnEnable()
        {
            CollectVars();
        }

        protected virtual void CollectVars()
        {
            // get and default Rigidbody
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;

            // collect bodyScript
            body = GetComponent<PlacableFactoryItemBody>();
        }

        public virtual void FinalizePlacement()
        {
            body = GetComponent<PlacableFactoryItemBody>();
            if (body != null)
            {                
                body.FinalizeBody();
            }
        }
        #endregion


        #region Align Object to Point and Rotation
        public virtual void PositionAndRotateBody(Vector3 aGlobePos, Vector3 aLookPos)
        {
            transform.position = aGlobePos;
            body.PositionAndRotateBody(aGlobePos, aLookPos);
        }

        public virtual void PositionAndRotateBody(Vector3 aGlobePos, Vector3 aLookPos,  Vector3 aAdditionalRotation)
        {
            transform.position = aGlobePos;
            body.PositionAndRotateBody(aGlobePos, aLookPos, aAdditionalRotation);
        }

        #endregion 

        public virtual void RemoveItem()
        {
            Destroy(gameObject);
        }
        // Accessors





    }
}