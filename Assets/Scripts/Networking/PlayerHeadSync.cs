// Created By   :   Isaac Bustad
// Created      :   5/14/2026



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

public class VRPlayerSync : NetworkBehaviour
{
    [SerializeField] private Transform headProxy; // Drag your Cube here
    private Transform mainCameraTransform;

    public override void OnStartLocalPlayer()
    {
        // Find the camera on the local machine
        if (Camera.main != null)
            mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Only the owner of this player should update the position
        if (isLocalPlayer && mainCameraTransform != null)
        {
            headProxy.position = mainCameraTransform.position;
            headProxy.rotation = mainCameraTransform.rotation;
        }
    }
}
