// Isaac Bustad
// 1/17/2025


using BugFreeProductions.Extentions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMS_LockToPoint : PlayerMoveState
{
    // Vars




    // Methods
<<<<<<< Updated upstream
    public override void FUActions(PlayerMoveContext aPMC)
    {
=======
    // do not move when locked to point
    public override void FUActions(PlayerMoveContext aPMC)
    {
        base.FUActions(aPMC);
    }
    protected override void Move(Rigidbody aRB, Vector3 aMovDir, MoveStateParam_SCO aMSP_SCO)
    {
>>>>>>> Stashed changes
        
    }




    // Accessors
    public override bool IsLockToPoint { get { return true; } }



}
