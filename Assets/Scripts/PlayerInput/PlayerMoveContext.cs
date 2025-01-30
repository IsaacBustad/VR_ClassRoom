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
    protected PlayerInputBridge ib = null;

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
        // lock RB rotation
        rb.freezeRotation = true;

        //Debug.Log("RB = " + rb.gameObject.name);
        ib = GetComponent<PlayerInputBridge>();
        //Debug.Log("IB = " + ib.gameObject.name);
    }

    protected virtual void FixedUpdate()
    {
        curPMS.FUActions(this);
    }

    #region Change State Methods    
    public virtual void FreeWalk()
    {
        PlayerMoveState nPMS = curPMS.FreeWalk(this);

        if (lastPMS.IsFreeWalk != curPMS.IsFreeWalk)
        {
            lastPMS = curPMS;
        }

        curPMS = nPMS;
    }
    public virtual void LockToPoint()
    {
        PlayerMoveState nPMS = curPMS.LockToPoint(this);

        if (lastPMS.IsLockToPoint != curPMS.IsLockToPoint)
        {
            lastPMS = curPMS;
        }

        curPMS = nPMS; ;
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
    public virtual PlayerInputBridge IB { get { return ib; } }
    #endregion

    #region Access to Move State Params
    public MoveStateParam_SCO FreeWalkMSP { get { return freeWalkMSP; } }
    #endregion

}
