// Created By   :   Isaac Bustad
// Created      :   5/30/2026


using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BugFreeProductions.Tools
{
    public class NetPlacableObjectPlacer : VR_PlacableItemPlacerGun
    {
        #region Vars
        [SerializeField] protected NetworkIdentity ni = null;
        protected bool usersCanPlace = false;

        // ref for the networked item spawner
        protected NetPlacableItemSpawner netItemSpawner = null;
        #endregion Vars

        // protected virtual void Start()
        // {
        //     // NetworkBehaviour nb = gameObject.AddComponent< NetworkBehaviour>();
        //     // bool ab = nb.isServer;
        // }

        // Methods
        protected override void OnEnable()
        {
            // get ensure network behavoiur exist
            if (ni == null)
            {
                ni = gameObject.GetComponentInParent<NetworkIdentity>();
            }

            // execute base
            // followed by .base code for reference
            base.OnEnable();
            //CollectVars();
        }

        protected override void FixedUpdate()
        {
            if(ni.isServer || usersCanPlace)
            {
                base.FixedUpdate();
            }

            // if (isPlacing == true)
            // {
            //     CastAndCheckforPlacement();
            // }
        }

        protected override void CollectVars()
        {
            // get the NetPlacableItemSpawner reference
            netItemSpawner = GetComponent<NetPlacableItemSpawner>();

            base.CollectVars();
            // make sure we have a helper            
            // posRotHelperTF = new GameObject("posRotHelper").transform;


            // lineRenderer = GetComponent<LineRenderer>();
            // lineRenderer.startWidth = 0.2f;
            // lineRenderer.endWidth = 0.2f;
            // lineRenderer.enabled = false;
            // lineRenderer.startColor = Color.green;
            // lineRenderer.endColor = Color.green;
        }

        // input testing
        public override void UsePlacer(bool aCon)
        {
            if (ni.isServer || usersCanPlace)
            {
                base.UsePlacer(aCon);
            }



            // if (aCon.started == true)
            // {
            //     lineRenderer.enabled = true;
            //     isPlacing = true;


            // }
            // else if (aCon.canceled == true)
            // {
            //     PlaceItem();
            //     //PlaceItem();
            //     isPlacing = false;
            //     lineRenderer.enabled = false;


            //     // assigned null for re use
            //     factoryItem = null;
            //     placableFactoryItem = null;
            // }

        }


        // functionality to use placer
        protected override void PlaceItem()
        {
            if (ni.isServer)
            {
                base.PlaceItem();

                NetworkServer.Spawn(placableFactoryItem.gameObject);

            }

            // for players to place items
            else if (usersCanPlace)
            {
                if (netItemSpawner != null)
                {
                    netItemSpawner.RequestNetworkItemSpawn(placableFactoryItem.ObjectPlacement().ToNetPlacementData());
                }
            }

            // if ( placableFactoryItem != null)
            // {
            //     placableFactoryItem.FinalizePlacement();
            // }
        }

        // Set up placement data via custom calculation
        protected override ObjectPlacement CalcObjectPlacementData()
        {
            // if (nb.isServer || usersCanPlace)
            // {
            //     base.CalcObjectPlacementData();
            // }

            // monitor this line for errors
            // may be fine to use since this is only called by the object itself
            return base.CalcObjectPlacementData();

            // // declare returning var
            // ObjectPlacement nPlacement = new ObjectPlacement();


            // // Set ID
            // nPlacement.id = itemID;

            // // set transform information
            // Vector3 aPos = posRotHelperTF.position;

            // nPlacement.tpX = aPos.x;
            // nPlacement.tpY = aPos.y;
            // nPlacement.tpZ = aPos.z;


            // // set rotation Data
            // Vector3 aRot = transform.eulerAngles;

            // nPlacement.trX = aRot.x;
            // nPlacement.trY = aRot.y;
            // nPlacement.trZ = aRot.z;

            // // return calculated placement data
            // return nPlacement;
        }


        // Use Raycast and other checks to find where to place object
        protected override void CastAndCheckforPlacement()
        {
            base.CastAndCheckforPlacement();
            // // store raycast hit
            // RaycastHit hit;

            // if (Physics.Raycast(transform.position, transform.forward, out hit, maxPlaceDist, 31, QueryTriggerInteraction.Ignore))
            // {


            //     posRotHelperTF.position = hit.point;
            //     posRotHelperTF.rotation = transform.rotation;

            //     DrawPlacementLine();

            //     // if we have not created an object to place create here
            //     // validates that we are pointing at a valid position
            //     if (factoryItem == null)
            //     {
            //         itemFactory.CreateItem(ref factoryItem, CalcObjectPlacementData());
            //         placableFactoryItem = factoryItem.GetComponent<PlacableFactoryItem>();
            //     }


            //     // change body position

            //     placableFactoryItem.PositionAndRotateBody(posRotHelperTF.position,transform.position,playerInputBridge.AdditionalRotation);
            // }

        }

        // Draw the line of the placement ray
        protected override void DrawPlacementLine()
        {
            base.DrawPlacementLine();
            // //lineRenderer.enabled = true;

            // // create array of line points
            // Vector3[] posArray = new Vector3[] {transform.position,posRotHelperTF.position};

            // lineRenderer.SetPositions(posArray);
        }

        // spawn Item on network
        protected void CMDSpawnNetItem()
        {
            NetworkServer.Spawn(placableFactoryItem.gameObject);
        }
    }
}