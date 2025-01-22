// Isaac Bustad
// 1/22/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamState
{
    // Vars


    // Methods
    // actions to be executed in Fixed Update
    public virtual void FUActions()
    {
        RotateCamera();
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



   
}
