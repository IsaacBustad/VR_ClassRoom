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

    /* protected virtual void RotCamToPos()
     {
         // store current rotation
         Vector3 rot = camTF.eulerAngles;
         Debug.Log("current angle = " + rot);

         rot += (playerCameraContext.PlayerInputBridge.CamRotDir * playerCameraContext.PlayerCameraParam_SCO.RotSpeed);
         rot.z = 0f;
         Debug.Log("Pre Clamped X angle = " + rot.x);

         float clampedX = Mathf.Clamp(rot.x, 90, 360 - 90);
         //rot.x = Mathf.Clamp(rot.x, -playerCameraContext.PlayerCameraParam_SCO.MaxRot, playerCameraContext.PlayerCameraParam_SCO.MaxRot);
         rot.x = Mathf.Clamp(rot.x, 90, 360 - 90);
         Debug.Log("Post Clamped X angle" + clampedX);

         Debug.Log("target angle = " + rot);

         // create new rotation as quaterenion
         Quaternion nRot = Quaternion.Euler(rot);
         Debug.Log("generated angle = " + nRot.eulerAngles);

         // change cam rotation use Quaternion Lerp
         camTF.rotation = Quaternion.Lerp(camTF.rotation, nRot, playerCameraContext.PlayerCameraParam_SCO.TimeToTween );
     }*/

    protected virtual void RotCamToPos()
    {
        TargCamAngle.y += playerCameraContext.PlayerInputBridge.CamRotDir.y * playerCameraContext.PlayerCameraParam_SCO.RotSpeed;

        TargCamAngle.x += playerCameraContext.PlayerInputBridge.CamRotDir.x * playerCameraContext.PlayerCameraParam_SCO.RotSpeed;

        TargCamAngle.x = Mathf.Clamp(TargCamAngle.x, -90, 90);

        camTF.rotation = Quaternion.Lerp(camTF.rotation, Quaternion.Euler(TargCamAngle), playerCameraContext.PlayerCameraParam_SCO.TimeToTween);
    }



    // Accessors
    public PlayerCameraContext PlayerCameraContext { get { return playerCameraContext; } }



}
