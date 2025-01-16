// Isaac Bustad
//11/6/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    [System.Serializable]
    public class ObjectPlacement
    {
        // Vars
        // has vars that match JSON object fields
        #region transform info in world space
        // position
        public float tpX = 0;
        public float tpY = 0;
        public float tpZ = 0;
        
        // rotation
        public float trX = 0;
        public float trY = 0;
        public float trZ = 0;

        #endregion
        public string id = "NA";

        

    }
}