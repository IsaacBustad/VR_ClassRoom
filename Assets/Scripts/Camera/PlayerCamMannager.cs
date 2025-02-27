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

    [SerializeField] protected Vector3 TargCamAngle = Vector3.zero;

    // Methods
    protected virtual void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void FixedUpdate()
    {
        MoveCamToPosition();
        RotCamToPos();
    }

    protected virtual void MoveCamToPosition()
    {
        transform.position = Vector3.Lerp(playerCameraContext.CamAnker.position, transform.position, playerCameraContext.PlayerCameraParam_SCO.TimeToTween);// ((playerCameraContext.CamAnker.position - transform.position) + transform.position) * playerCameraContext.PlayerCameraParam_SCO.TimeToTween;
    }

    

    protected virtual void RotCamToPos()
    {
        TargCamAngle.y += playerCameraContext.PlayerInputBridge.CamRotDir.y * playerCameraContext.PlayerCameraParam_SCO.RotSpeed;

        TargCamAngle.x += playerCameraContext.PlayerInputBridge.CamRotDir.x * playerCameraContext.PlayerCameraParam_SCO.RotSpeed;

        TargCamAngle.x = Mathf.Clamp(TargCamAngle.x, -90, 90);

        camTF.rotation = Quaternion.Lerp(camTF.rotation, Quaternion.Euler(TargCamAngle), playerCameraContext.PlayerCameraParam_SCO.TimeToTween);
    }



    // Accessors
    public PlayerCameraContext PlayerCameraContext { get { return playerCameraContext; } }
    public Vector3 CamRot { get { return camTF.localEulerAngles; } }



}
