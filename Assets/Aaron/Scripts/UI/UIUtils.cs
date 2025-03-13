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
}
