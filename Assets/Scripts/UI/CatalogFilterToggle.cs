// Written by Aaron Williams
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CatalogFilterToggle : Toggle
{
    //TODO make the filters create through code and remove this serialize tag
    [SerializeField]
    private string category;
    public string Category { get => category; set => category = value; }
}
