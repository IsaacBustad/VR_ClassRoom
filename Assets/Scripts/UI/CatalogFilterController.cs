// Written by Aaron Williams
using System.Collections.Generic;
using UnityEngine;

public class CatalogFilterController : MonoBehaviour
{
    private List<CatalogFilterToggle> filterCategories;
    private List<CatalogItemData> catalogItems;

    public List<CatalogFilterToggle> FilterCategories { get => filterCategories; set => filterCategories = value; }
    public List<CatalogItemData> CatalogItems { get => catalogItems; set => catalogItems = value; }

    private void Start()
    {
        foreach (var category in filterCategories)
        {
            category.Toggle.onValueChanged.AddListener(delegate { ApplyFilters(); });
        }
    }

    public void ApplyFilters()
    {
        foreach (CatalogItemData item in catalogItems)
        {
            bool shouldDisplay = false;

            foreach (var filter in filterCategories)
            {
                if (filter.isOn && item.Category == filter.Category)
                {
                    shouldDisplay = true;
                    break;
                }
            }

            item.gameObject.SetActive(shouldDisplay);
        }
    }
}