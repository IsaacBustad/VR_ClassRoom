// Isaac Bustad
// 2/4/2025



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    [CreateAssetMenu(fileName = "", menuName = "")]
    public class LayerCheck_SCO : ScriptableObject
    {
        // Vars
        [SerializeField] protected List<int> layersPlacable = new List<int>();


        // Methods
        public virtual bool CheckIfPlacable(int aLayer)
        {
            // declare
            bool isPlacable = false;

            // loop to check if layer is placable
            foreach (int layer in layersPlacable)
            {
                if (layer == aLayer)
                {
                    isPlacable = true;
                }
            }

            // return if placable
            return isPlacable;
        }


        // Accessors




    }
}