

using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class NetworkedSnapToPositionRotation : NetworkBehaviour
{
    #region Vars
    [SerializeField] protected Transform trackedTf = null;
    #endregion Vars

    #region  Methods
    protected void LateUpdate()
    {
        if(isOwned)
        {
            transform.position = trackedTf.position;
            transform.rotation = trackedTf.rotation;
        }
        
    }
    #endregion Methods
}
