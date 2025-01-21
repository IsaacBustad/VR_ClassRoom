// Isaac Bustad
// 1/17/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BugFreeProductions.Extentions;

public class PlayerMoveState 
{
    // Vars


    // Methods
    #region State Change Methods
    public virtual PlayerMoveState LockToPoint(PlayerMoveContext aPMC)
    {
        return aPMC.LockToPointPMS;
    }

    public virtual PlayerMoveState FreeWalk(PlayerMoveContext aPMC)
    {
        return aPMC.FreeWalkPMS;
    }
    #endregion

    #region Fixed Update Actions
    public virtual void FUActions(PlayerMoveContext aPMC)
    {
        Move(aPMC.RB,aPMC.IB.MoveDir,aPMC.FreeWalkMSP);
        BugFreeTool.LimitToWorldVelocity(aPMC.RB.velocity);
    }

    public virtual void UActions(PlayerMoveContext aPMC)
    {
        //Move(aPMC.RB,aPMC.IB,aPMC.);
    }

    protected virtual void Move(Rigidbody aRB, Vector3 aMovDir, MoveStateParam_SCO aMSP_SCO)
    {
        if (aRB != null)
        {
            if (aRB.velocity.magnitude < aMSP_SCO.MaxSpeed)
            {
                aRB.AddForce(aMovDir.normalized * aMSP_SCO.Accelleration, ForceMode.Force);
            }

        }
        //aRB.AddForce(aMovDir.normalized *);
    }
    #endregion

    // Accessors
    #region Bool Check for States
    public virtual bool IsLockToPoint { get { return false; } }
    public virtual bool IsFreeWalk { get { return false; } }
    #endregion


}
