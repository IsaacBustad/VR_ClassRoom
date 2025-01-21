// Isaac Busatd
// 1/17/2025



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveContext : MonoBehaviour
{
    // Var 
    // curent player move state for use in local version
    #region State Vars
    protected PlayerMoveState curPMS = null;
    protected PlayerMoveState lastPMS = null;

    protected PlayerMoveState freeWalkPMS = new PMS_FreeWalk();
    protected PlayerMoveState lockToPointPMS = new PMS_LockToPoint();
    #endregion

    #region Movement Variables
    protected Rigidbody rb = null;
    protected InputBridgeLocal ib = null;

    #endregion

    #region Move Settings SCO's
    [SerializeField] protected MoveStateParam_SCO freeWalkMSP = null;
    #endregion
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
        // collect Component refferences on this body
        rb = GetComponent<Rigidbody>();
        ib = GetComponent<InputBridgeLocal>();
    }

    protected virtual void FixedUpdate()
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

    #region Access to move Vars
    public virtual Rigidbody RB { get { return rb; } }
    public virtual InputBridgeLocal IB { get { return ib; } }
    #endregion

    #region Access to Move State Params

    #endregion

}
