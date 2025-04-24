// Written by Aaron Williams
using UnityEngine;
using UnityEngine.UI;

public static class UIUtils
{
    public static PlayerMoveContext PLAYER_MOVE_CONTEXT;
    public static PlayerCamMannager PLAYER_CAMERA_MANAGER;
    public static RadialMenu PLAYER_RADIAL_MENU;

    public static void SetTransparency(Image image, float percent)
    {
        Color color = image.color;
        color.a = Mathf.Clamp01(percent);
        image.color = color;
    }

    public static void HandleToggleRadialMenuKBM()
    {
        PLAYER_RADIAL_MENU.HandleToggleRadialMenuKBM();
    }

    public static void EnableUILock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PLAYER_MOVE_CONTEXT.enabled = false;
        PLAYER_CAMERA_MANAGER.enabled = false;
    }
    public static void DisableUILock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PLAYER_MOVE_CONTEXT.enabled = true;
        PLAYER_CAMERA_MANAGER.enabled = true;
    }
}
