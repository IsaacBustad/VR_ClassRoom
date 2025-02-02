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

   

    /*protected PlayerCamState freeWalkPCS  = new;
    protected PlayerCamState lockToPosPCS = ;*/
    #endregion

    #region Cam Vars
    [SerializeField] protected PlayerCamMannager camMannager = null;
    [SerializeField] protected Transform camAnker = null;
    #endregion

    #region Cam State Params
    [SerializeField] protected PlayerCameraParam_SCO freeWalkCamParam_SCO = null;
    [SerializeField] protected PlayerCameraParam_SCO lockedToPosCamParam_SCO = null;
    #endregion
    #region VR Cam Controls
    #endregion

    #region Input and addditional refference
    protected PlayerInputBridge playerInputBridge = null;
    #endregion


    // Methods
    protected virtual void OnEnable()
    {
        curCS = new PlayerCamState();

        CollectVars();
    }

    // Initialize variables

    // Collect Variable Refferences
    protected virtual void CollectVars()
    {

        // collect local object refferences
        playerInputBridge = GetComponent<PlayerInputBridge>();
    }

    protected virtual void FixedUpdate()
    {
        curCS.FUActions();
    }
    



    // Accessors
    public Transform CamAnker { get { return camAnker; } }
    public PlayerInputBridge PlayerInputBridge { get {  return playerInputBridge; } }
    public PlayerCameraParam_SCO PlayerCameraParam_SCO { get { return curCS.PlayerCameraParam_SCO(this); } }

    #region Accessors for player camera parameters
    public PlayerCameraParam_SCO FreeWalkPlayerCamParam_SCO { get { return freeWalkCamParam_SCO; } }
    #endregion


    // Accesors for other class methods



}
