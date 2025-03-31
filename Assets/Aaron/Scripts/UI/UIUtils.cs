// Written by Aaron Williams
using UnityEngine;
using UnityEngine.UI;

public static class UIUtils
{
    public static void SetTransparency(Image image, float percent)
    {
        Color color = image.color;
        color.a = Mathf.Clamp01(percent);
        image.color = color;
    }

    public static void EnableUILock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public static void DisableUILock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
