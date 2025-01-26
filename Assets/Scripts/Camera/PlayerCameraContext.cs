// Isaac Bustad
// 1/20/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCameraContext : MonoBehaviour
{
    // Vars

    #region Cam State Vars
    protected PlayerCamState curCS = null;
    protected PlayerCamState lastCS = null;

    #region Camera Refference
    [SerializeField] protected Transform playerCamTF = null;
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
    protected PlayerCameraParam_SCO player3DPCP = null;
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
