// Isaac Bustad
// 10/8/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    public class FactoryItem : Poolable
    {
        // Vars
        // id standing for particular prefab
        [SerializeField] protected string id = "NA";


        // Methods
        public virtual void UseFactoryItem(Transform aTF, GenericPool aGP)
        {
            gameObject.SetActive(true);
            pool = aGP;
            // position and align
            transform.position = aTF.position;
            transform.rotation = aTF.rotation;
        }

        #region Stuff For Object Placement
        public virtual void UseFactoryItem(ObjectPlacement aPlacement, GenericPool aGP)
        {
            gameObject.SetActive(true);
            pool = aGP;
            // position and align
            transform.position = new Vector3(aPlacement.tpX, aPlacement.tpY, aPlacement.tpZ);
            transform.rotation = Quaternion.Euler(aPlacement.trX, aPlacement.trY, aPlacement.trZ);

            // pool objects created with placement data
            pool.PoolObj(this);
        }
        #endregion

        protected virtual void OnDestroy()
        {
            pool.RevFromPool(this);
        }


        public virtual ObjectPlacement ObjectPlacement() 
        {
            ObjectPlacement nObjPlace = new ObjectPlacement();

            nObjPlace.id = id;

            nObjPlace.tpX = transform.position.x;
            nObjPlace.tpY = transform.position.y;
            nObjPlace.tpZ = transform.position.z;

            nObjPlace.trX = transform.eulerAngles.x;
            nObjPlace.trY = transform.eulerAngles.y;
            nObjPlace.tpZ = transform.eulerAngles.z;
            
            return nObjPlace;
        }

        // Accessors
        public virtual string ID { get { return id; } }
        


    }
}