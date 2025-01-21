// Isaac Bustad
// 1/17/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState 
{
    // Vars


    // Methods
    public virtual PlayerMoveState LockToPoint(PlayerMoveContextLocal aPMCL)
    {
        return aPMCL.LockToPointPMS;
    }

    public virtual PlayerMoveState FreeWalk(PlayerMoveContextLocal aPMCL)
    {
        return aPMCL.FreeWalkPMS;
    }
    
    // Accessors
    public virtual bool IsLockToPoint { get { return false; } }
    public virtual bool IsFreeWalk { get { return false; } }



}
