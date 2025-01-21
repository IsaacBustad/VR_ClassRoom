// Isaac Busatd
// 1/17/2025



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveContextLocal : MonoBehaviour
{
    // Var 
    // curent player move state for use in local version
    protected PlayerMoveState curPMS = null;
    protected PlayerMoveState lastPMS = null;

    protected PlayerMoveState freeWalkPMS = new PMS_FreeWalk();
    protected PlayerMoveState lockToPointPMS = new PMS_LockToPoint();
    //protected PlayerMoveState pms_


    // Methods
    protected virtual void OnEnable()
    {
        // Set Defaults
        curPMS = freeWalkPMS;
        lastPMS = curPMS;

        // Collect Vars
        CollectVars();
    }

    protected virtual void CollectVars()
    {

    }

    #region Change State Methods
    protected virtual void ChangState(PlayerMoveState aPMS)
    {
        if (curPMS != aPMS && lastPMS != curPMS)
        {
            lastPMS = curPMS;
        }

        curPMS = aPMS;
    }

    public virtual void FreeWalk()
    {
        PlayerMoveState nPMS = curPMS.FreeWalk(this);

        ChangState(nPMS);
    }
    public virtual void LockToPoint()
    {
        PlayerMoveState nPMS = curPMS.LockToPoint(this);
        ChangState(nPMS);
    }

    #endregion


    // Accessors
    #region Access To move States
    public PlayerMoveState CurPMS { get { return curPMS; } }
    public PlayerMoveState FreeWalkPMS { get { return freeWalkPMS; } }
    public PlayerMoveState LockToPointPMS { get { return freeWalkPMS; } }
    #endregion



}
