// Isaac Bustad
// 1/30/2025



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBridge : MonoBehaviour
{
    // Vars
    #region Movement Vars
    protected PlayerMoveContext playerMoveContext = null;

    // Vector to Move
    protected Vector3 moveDir = Vector3.zero;
    #endregion

    #region Camera Vars
    // for Camera context to access
    protected Vector3 camRotDir = Vector3.zero;

    // to hold CamStateContext
    protected PlayerCameraContext playerCameraContext = null;
    #endregion

    #region Additional rotation for object placement
    protected Vector3 additionalBodyRotation = Vector3.zero;
    #endregion

    // Methods
    protected virtual void OnEnable()
    {
        CollectVars();
    }

    protected virtual void CollectVars()
    {
        // get move context
        // should be on this object
        playerMoveContext = GetComponent<PlayerMoveContext>();

        // get cam context
        // should be on this object
        playerCameraContext = GetComponent<PlayerCameraContext>();

    }

    #region Keyboard Player Controls
    public virtual void MouseCamControles(InputAction.CallbackContext aCon)
    {
        
    }

    public virtual void KeyBoardMove(InputAction.CallbackContext aCon)
    {
        
    }

    public virtual void Primary_Action_Left_Q(InputAction.CallbackContext aCon)
    {

    }

    public virtual void Primary_Action_Right_E(InputAction.CallbackContext aCon)
    {

    }
    #endregion


    // Accessors
    public Vector3 MoveDir { get { return moveDir; } }
    public Vector3 CamRotDir { get { return camRotDir; } }


}
