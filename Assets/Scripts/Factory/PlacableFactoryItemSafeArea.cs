// Isaac Bustad
// 2/5/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace BugFreeProductions.Tools
{
    public class PlacableFactoryItemSafeArea : MonoBehaviour
    {
        // Vars
        //colors
        [SerializeField] protected Color positiveColor = Color.white;
        [SerializeField] protected Color negativeColor = Color.white;

        [SerializeField] protected Material material = null;


        protected int objInTrig = 0;


        // Methods
        #region Setup
        protected virtual void OnEnable()
        {
            CollectVars();
        }

        protected virtual void CollectVars()
        {
            //material = GetComponent<Material>();
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            objInTrig ++;
        }

        protected virtual void OnTriggerExit()
        {
            objInTrig --;
        }

        protected virtual void Update()
        {
            if (objInTrig > 0)
            {
                material.color = negativeColor;
            }
            else if (objInTrig == 0)
            {
                material.color = positiveColor;
            }
        }
        #endregion

        #region Align Object to Point and Rotation
        public virtual void PositionAndRotateBody(Vector3 aGlobePos, Vector3 aLookPos, float aHeight, Quaternion aLookRot)
        {
            PositionBody(aGlobePos, aHeight);
            RotateBody(aLookRot);
        }

        protected virtual void PositionBody(Vector3 aGlobePos, float aHeight)
        {
            Vector3 nPos = aGlobePos;

            nPos.y += aHeight / 2;
            transform.position = nPos;
        }

        protected virtual void RotateBody(Quaternion aLookRot)
        {
            transform.rotation = aLookRot;
        }


        #endregion

        // Accessors






    }
}