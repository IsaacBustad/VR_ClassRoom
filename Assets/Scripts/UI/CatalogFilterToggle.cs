// Written by Aaron Williams
using UnityEngine.UI;

[System.Serializable]
public class CatalogFilterToggle : Toggle
{
    private string category;
    private Toggle toggle;

    public string Category { get => category; set => category = value; }
    public Toggle Toggle { get => toggle; set => toggle = value; }
}
