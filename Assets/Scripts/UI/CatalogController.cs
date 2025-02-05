// Written by Aaron Williams
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogController : MonoBehaviour
{
    // TODO update this to the final folder name inside of Resources
    // TODO switch back to const string, not const rn to make testing easier and string visible/editable in editor
    [SerializeField]
    private string ITEM_FOLDER = "ClassItems";

    [SerializeField]
    private GameObject catalogItemPrefab;
    [SerializeField]
    private Transform contentPanel;
    [SerializeField]
    private List<CatalogFilterToggle> categoryToggles;
    [SerializeField]
    private List<CatalogItemData> allItems = new List<CatalogItemData>();

    public GameObject CatalogItemPrefab { get => catalogItemPrefab; set => catalogItemPrefab = value; }
    public Transform ContentPanel { get => contentPanel; set => contentPanel = value; }
    public List<CatalogFilterToggle> CategoryToggles { get => categoryToggles; set => categoryToggles = value; }

    private void Start()
    {
        foreach (CatalogFilterToggle filterToggle in categoryToggles)
        {
            filterToggle.onValueChanged.AddListener(delegate { UpdateCatalog(); });
        }
        LoadItems();
        UpdateCatalog();
    }

    private void LoadItems()
    {
        allItems.Clear();

        // TODO change this to the final scriptableObject type when ready
        ItemSO[] items = Resources.LoadAll<ItemSO>(ITEM_FOLDER);

        foreach (ItemSO item in items)
        {
            allItems.Add(new CatalogItemData(item.Id, item.Category, item.Sprite));
        }
    }

    private void UpdateCatalog()
    {
        // Get active categories
        List<string> activeCategories = new List<string>();
        foreach (var filterToggle in categoryToggles)
        {
            if (filterToggle.isOn)
            {
                activeCategories.Add(filterToggle.Category);
            }
        }

        // enable filtered items
        foreach (var item in allItems)
        {
            if (activeCategories.Contains(item.Category))
            {
                // TODO need to test this to make sure that the grid resizes and reorghanizes when items are filtered/unfiltered
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}