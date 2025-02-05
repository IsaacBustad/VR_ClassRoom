// Isaac Busatd
// 12/4/2024


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BugFreeProductions.Tools
{
    [CreateAssetMenu(fileName = "AbstractFactory_SCO", menuName = "ScriptableObject/AbstractFactory_SCO")]
    public class AbstractFactory_SCO : ScriptableObject
    {
        // Vars
        [SerializeField, Header("Factories run"), Tooltip("List of Generic Factories This Abstract Factory is responsible for running")] 
        List<GenericFactory_SCO> genericFactory_SCOs = new List<GenericFactory_SCO>();

        #region Factory Item Creation
        // Methods
        public virtual void CreateItem(Transform aTF , string aID)
        {
            // hold id to search for
            string srchString = aID;

            // hold id we are looping through
            string factID = null;


            foreach (GenericFactory_SCO gf in genericFactory_SCOs)
            {
                // change ID we check against
                factID = gf.ItemID;

                // check Against search id
                if (srchString == factID)
                {
                    gf.CreateItem(aTF);
                }

            } 


        }

        public virtual void CreateItem(ObjectPlacement aPlacement)
        {
            // hold id to search for
            string srchString = aPlacement.id;

            // hold id we are looping through
            string factID = null;


            foreach (GenericFactory_SCO gf in genericFactory_SCOs)
            {
                // change ID we check against
                factID = gf.ItemID;

                // check Against search id
                if (srchString == factID)
                {
                    gf.CreateItem(aPlacement);
                }

            }

        }

        public virtual void CreateItem(ref FactoryItem aFI, ObjectPlacement aPlacement)
        {
            // hold id to search for
            string srchString = aPlacement.id;

            // hold id we are looping through
            string factID = null;


            foreach (GenericFactory_SCO gf in genericFactory_SCOs)
            {
                // change ID we check against
                factID = gf.ItemID;

                // check Against search id
                if (srchString == factID)
                {
                    gf.CreateItem(ref aFI, aPlacement);
                }

            }

        }

        public virtual void CreateItem(ObjectPlacement aPlacement, int aLayer)
        {
            // hold id to search for
            string srchString = aPlacement.id;

            // hold id we are looping through
            string factID = null;


            foreach (GenericFactory_SCO gf in genericFactory_SCOs)
            {
                // change ID we check against
                factID = gf.ItemID;

                // check Against search id
                if (srchString == factID)
                {
                    gf.CreateItem(aPlacement);
                }

            }

        }
        #endregion


        #region Gather Factory Item Position Save Info
        public virtual ObjectPlacementList GatherFactItemPosInfo()
        {
            ObjectPlacementList retLst = new ObjectPlacementList();

            List<ObjectPlacement> totalObjPlacs = new List<ObjectPlacement>();

            foreach (GenericFactory_SCO gf in genericFactory_SCOs)
            {
                List<ObjectPlacement> nl = gf.GatherFactItemPosInfo();
                foreach (ObjectPlacement op in nl)
                {
                    totalObjPlacs.Add(op);
                }
            }

            retLst.objectPlacements = totalObjPlacs.ToArray();


            return retLst;
        }
        #endregion

    }
}