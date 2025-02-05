// Written by Aaron Williams
using UnityEngine;

public class CatalogItemData : MonoBehaviour
{
    private string id;
    private string category;
    private Sprite sprite;

    public CatalogItemData(string name, string category, Sprite sprite)
    {
        this.id = name;
        this.category = category;
        this.sprite = sprite;
    }

    public string Id { get => id; set => id = value; }
    public string Category { get => category; set => category = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
}