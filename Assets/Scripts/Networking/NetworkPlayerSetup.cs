// Created By   :   Isaac
// Created      :   5/14/2026
// Gemini Assisted

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;



public class VRPlayerSetup : NetworkBehaviour
{
    [SerializeField] private GameObject localVRRig;  // Camera, tracking, etc.
    [SerializeField] private GameObject remoteAvatar; // Visuals for other players

    // Mirror fires this strictly on the client that OWNS this player object
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        SetupLocalPlayer();
    }

    // Mirror fires this on ALL clients when any player object wakes up/spawns
    public override void OnStartClient()
    {
        base.OnStartClient();
        
        // If it's NOT the local player, set up the remote visuals
        if (!isLocalPlayer)
        {
            SetupRemotePlayer();
        }
    }

    private void SetupLocalPlayer()
    {
        localVRRig.SetActive(true);
        remoteAvatar.SetActive(false);
    }

    private void SetupRemotePlayer()
    {
        localVRRig.SetActive(false);
        remoteAvatar.SetActive(true);
    }
}