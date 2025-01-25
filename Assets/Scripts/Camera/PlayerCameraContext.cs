// Isaac Bustad
// 1/20/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.WebCam;

public class PlayerCameraContext : MonoBehaviour
{
    // Vars

    #region Cam State Vars
    protected PlayerCamState curCS = null;
    protected PlayerCamState lastCS = null;

    #region Camera Refference

    #endregion

    #region 3D Cam Reff

    #endregion 

    protected PlayerCamState vrCS ;
    protected PlayerCamState threeDCS ;
    #endregion

    #region Cam Vars
    [SerializeField] protected Transform CamTF;
    #endregion

    #region Cam State Params
    protected PlayerCameraParam player3DPCP = null;
    #endregion
    #region VR Cam Controls
    #endregion


    // Methods
    protected virtual void OnEnable()
    {

    }

    protected virtual void FixedUpdate()
    {

    }
    



    // Accessors



}
