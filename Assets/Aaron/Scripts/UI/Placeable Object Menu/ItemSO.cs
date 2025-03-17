// Written by Aaron Williams
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string Id;
    public string Category;
    public Sprite Sprite;
    public GameObject ItemPrefab;
}