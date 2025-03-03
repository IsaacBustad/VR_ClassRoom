// Isaac Bustad
// 3/3/2025


using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BugFreeProductions.Tools {
    [RequireComponent(typeof(LineRenderer))]
    public class PlacableItemRemover : MonoBehaviour
    {
        // Vars
        protected LineRenderer lineRenderer =null;
        [SerializeField, Range(1, 100)] protected float maxRemoveDist = 5;
        protected bool isRemoving = false;
        [SerializeField] protected Transform posRotHelperTF = null;

        // temp selected item ref
        protected PlacableFactoryItem placableFactoryItem = null;


        // Methods
        protected virtual void OnEnable()
        {
            CollectVars();
        }

        protected virtual void CollectVars()
        {
            // get the required line renderer
            lineRenderer = GetComponent<LineRenderer>();

            // create posRotHelper if none is assigned
            if (posRotHelperTF == null)
            {
                posRotHelperTF = new GameObject("PosRotHelper").transform;
            }
        }

        protected virtual void CastAndCheckforPlacement()
        {
            // store raycast hit
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, maxRemoveDist, 31, QueryTriggerInteraction.Ignore))
            {


                posRotHelperTF.position = hit.point;
                posRotHelperTF.rotation = transform.rotation;

                DrawRemovalLine();

                // get the placable Factory Item from an object if it exist
                // else placableFactoryItem will be null
                placableFactoryItem = hit.collider.gameObject.GetComponent<PlacableFactoryItem>();

                // if the placable Factory Item exist
                // run the method to highlight
                if (placableFactoryItem != null)
                {

                }



            }

        }

        public virtual void UseRemover(InputAction.CallbackContext aCon)
        {
            if (aCon.started)
            {
                isRemoving = true;
            }
            else if (aCon.canceled)
            {
                
            }
        }

        protected virtual void DrawRemovalLine()
        {
            //lineRenderer.enabled = true;

            // create array of line points
            Vector3[] posArray = new Vector3[] { transform.position, posRotHelperTF.position };

            lineRenderer.SetPositions(posArray);
        }


        // Accessors





    }
}