// Isaac Bustad
// 1/17/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBridgeLocal : PlayerInputBridge
{
    // Vars
    #region Movement Vars
    
    #endregion

    #region Camera Vars
    
    #endregion

    // Methods
    #region Keyboard Player Controls
    public override void MouseCamControles(InputAction.CallbackContext aCon)
    {
        Vector2 nDir = aCon.ReadValue<Vector2>();
        //Debug.Log("In Direction" + nDir);
        camRotDir += new Vector3(-nDir.y, nDir.x, 0);
        //Debug.Log("Mouse Direction" + camRotDir);
    }

    public override void KeyBoardMove(InputAction.CallbackContext aCon)
    {
        Vector2 nDir = aCon.ReadValue<Vector2>();

        moveDir = new Vector3(nDir.x, 0, nDir.y);
    }

    public override void Primary_Action_Left_Q(InputAction.CallbackContext aCon)
    {

    }

    public override void Primary_Action_Right_E(InputAction.CallbackContext aCon)
    {

    }

    protected virtual void Update()
    {
        LerpCamToZero();
    }

    protected virtual void LerpCamToZero()
    {
        if (camRotDir.magnitude > playerCameraContext.PlayerCameraParam_SCO.ReZeroBuff)
        {
            camRotDir = Vector3.Lerp(camRotDir, Vector3.zero, playerCameraContext.PlayerCameraParam_SCO.TimeToTween);
        }
        else camRotDir = Vector3.zero;
        
    }
    #endregion


    // Accessors
    


}
