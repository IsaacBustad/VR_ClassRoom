// Isaac Bustad
// 1/22/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamState
{
    // Vars


    // Methods
    #region State Change Region


    #endregion
    // actions to be executed in Fixed Update
    public virtual void FUActions()
    {
        
    }

    // actions to be executed in Update
    public virtual void UActions()
    {

    }

    // rotate camera
    protected virtual void RotateCamera()
    {

    }

    // Accessors
    public virtual PlayerCameraParam_SCO PlayerCameraParam_SCO(PlayerCameraContext aPCC)
    {
        return aPCC.FreeWalkPlayerCamParam_SCO;
    }




}
