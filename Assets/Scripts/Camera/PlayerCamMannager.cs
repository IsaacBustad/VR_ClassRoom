// Isaac Bustad
// 1/30/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamMannager : MonoBehaviour
{
    // Vars
    [SerializeField] protected Transform camTF = null;
    [SerializeField] protected PlayerCameraContext playerCameraContext = null;

    // Methods
    protected virtual void OnEnable()
    {
        
    }

    protected virtual void FixedUpdate()
    {
        MoveCamToPosition();
        RotCamToPos();
    }

    protected virtual void MoveCamToPosition()
    {
        transform.position = (playerCameraContext.CamAnker.position - transform.position) * playerCameraContext.PlayerCameraParam_SCO.TimeToTween;
    }

    protected virtual void RotCamToPos()
    {
        // store current rotation
        Vector3 rot = camTF.eulerAngles;
        rot += playerCameraContext.PlayerInputBridge.CamRotDir;

        // create new rotation as quaterenion
        Quaternion nRot = Quaternion.Euler(rot);

        // change cam rotation use Quaternion Lerp
        Quaternion.Lerp(camTF.rotation, nRot, playerCameraContext.PlayerCameraParam_SCO.TimeToTween );
    }



    // Accessors
    public PlayerCameraContext PlayerCameraContext { get { return playerCameraContext; } }



}
