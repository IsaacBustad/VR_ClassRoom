// Isaac Bustad
// 1/17/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBridgeLocal : MonoBehaviour
{
    // Vars
    #region Movement Vars
    [SerializeField] protected PlayerMoveContextLocal vrpmcl = null;

    // Vector to Move
    protected Vector3 moveDir = Vector3.zero;
    #endregion

    #region Camera Vars
    // for Camera context to access
    protected Vector3 camRotDir = Vector3.zero;
    #endregion

    // Methods
    #region Keyboard Player Controls
    public virtual void MouseCamControles(InputAction.CallbackContext aCon)
    {
        Vector2 nDir = aCon.ReadValue<Vector2>();

        camRotDir = new Vector3(nDir.y, nDir.x, 0);
    }

    public virtual void KeyBoardMove(InputAction.CallbackContext aCon)
    {
        Vector2 nDir = aCon.ReadValue<Vector2>();

        moveDir = new Vector3(nDir.x, 0, nDir.y);
    }

    public virtual void Primary_Action_Left_Q(InputAction.CallbackContext aCon)
    {

    }

    public virtual void Primary_Action_Right_E(InputAction.CallbackContext aCon)
    {

    }
    #endregion


    // Accessors



}
