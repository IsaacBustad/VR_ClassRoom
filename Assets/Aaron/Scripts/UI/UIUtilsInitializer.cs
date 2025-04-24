// Written by Aaron Williams
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtilsInitializer : MonoBehaviour
{
    [SerializeField] private PlayerMoveContext playerMoveContext;
    [SerializeField] private PlayerCamMannager playerCameraManager;
    [SerializeField] private RadialMenu playerRadialMenu;

    private void Start()
    {
        if(playerMoveContext != null)
        {
            UIUtils.PLAYER_MOVE_CONTEXT = playerMoveContext;
        }
        else
        {
            Debug.Log("You need to assign UIUtilsInitializer.playerMoveContext in the editor.");
        }

        if(playerCameraManager != null)
        {
            UIUtils.PLAYER_CAMERA_MANAGER = playerCameraManager;
        }
        else
        {
            Debug.Log("You need to assign UIUtilsInitializer.playerCameraManager in the editor.");
        }

        if (playerRadialMenu != null)
        {
            UIUtils.PLAYER_RADIAL_MENU = playerRadialMenu;
        }
        else
        {
            Debug.Log("You need to assign UIUtilsInitializer.playerRadialMenu in the editor.");
        }
    }
}
