// Created by   :   Isaac Bustad
// Created      :   5/8/2026


using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkSinglePlayerInputNode : NetworkBehaviour
{
    
    [SerializeField] private GameObject localCameraAndInput;

    [SerializeField] private GameObject ovrCameraRig; // The Rig inside the prefab

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            // 1. Disable the "Lobby" camera used to see the UI
            Camera lobbyCam = GameObject.Find("LobbyCamera")?.GetComponent<Camera>();
            if (lobbyCam != null) lobbyCam.gameObject.SetActive(false);

            // 2. Enable the VR Rig for the local player
            ovrCameraRig.SetActive(true);
            
            Debug.Log("Local VR Rig Activated");
        }
        else
        {
            // For other players, keep their cameras off so they don't fight for your screen
            ovrCameraRig.SetActive(false);
        }
    }

}
