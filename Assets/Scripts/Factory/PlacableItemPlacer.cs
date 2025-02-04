// Isaac Bustad
// 2/4/2025

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BugFreeProductions.Tools
{
    [RequireComponent(typeof(LineRenderer))]
    public class PlacableItemPlacer : FactoryItemPlacer
    {
        // Vars
        protected Transform posRotHelperTF = null;
        protected LineRenderer lineRenderer = null;
        [SerializeField, Range(1, 100)] protected float maxPlaceDist = 5;
        protected bool isPlacing = false;


        // Methods
        protected virtual void OnEnable()
        {
            CollectVars();
        }

        protected virtual void FixedUpdate()
        {
            if (isPlacing == true)
            {
                CastAndCheckforPlacement();
            }
        }

        protected virtual void CollectVars()
        {
            // make sure we have a helper
            
            posRotHelperTF = new GameObject("posRotHelper").transform;
            
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.startWidth = 0.2f;
            lineRenderer.endWidth = 0.2f;
            lineRenderer.enabled = false;
        }

        // input testing
        public override void UsePlacer(InputAction.CallbackContext aCon)
        {
            if (aCon.started == true)
            {
                lineRenderer.enabled = true;
                isPlacing = true;
            }
            else if (aCon.canceled == true)
            {
                UsePlacer();
                isPlacing = false;
                lineRenderer.enabled = false;
                Debug.Log("Canceled");
            }
            
        }


        // functionality to use placer
        public override void UsePlacer()
        {
            itemFactory.CreateItem(CalcObjectPlacementData());
        }

        // Set up placement data via custom calculation
        protected virtual ObjectPlacement CalcObjectPlacementData()
        {
            // declair returning var
            ObjectPlacement nPlacement = new ObjectPlacement();


            // Set ID
            nPlacement.id = itemID;

            // set transfom information
            Vector3 aPos = posRotHelperTF.position;

            nPlacement.tpX = aPos.x;
            nPlacement.tpY = aPos.y;
            nPlacement.tpZ = aPos.z;


            // set rotation Data
            Vector3 aRot = transform.eulerAngles;

            nPlacement.trX = aRot.x;
            nPlacement.trY = aRot.y;
            nPlacement.trZ = aRot.z;

            // return calculated placement data
            return nPlacement;
        }


        // Use Raycast and other checks to find where to place object
        protected virtual void CastAndCheckforPlacement()
        {
            // store raycast hit
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, maxPlaceDist))
            {


                posRotHelperTF.position = hit.point;
                posRotHelperTF.rotation = transform.rotation;

                DrawPlacementLine();
            }
            
        }

        // Draw the line of the placement ray
        protected virtual void DrawPlacementLine()
        {
            //lineRenderer.enabled = true;

            // create array of line points
            Vector3[] posArray = new Vector3[] {transform.position,posRotHelperTF.position};

            lineRenderer.SetPositions(posArray);
        }

        // Accessors



    }
}