// Written by Aaron Williams
using BugFreeProductions.Tools;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CatalogController : MonoBehaviour
{
    [SerializeField]
    private bool isVR = false;
    [SerializeField]
    private Transform vrCameraRigTransform;

    [SerializeField]
    private string ITEM_FOLDER = "ClassItems";
    [SerializeField]
    private string CATEGORIES_FOLDER = "Categories";
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private GameObject catalogItemPrefab;
    [SerializeField]
    private GameObject filterTogglePrefab;
    [SerializeField]
    private Transform itemsContentPanel;
    [SerializeField]
    private Transform filtersContentPanel;

    [SerializeField]
    private PlacableItemPlacer itemPlacer;

    private const string toggleSuffix = " toggle";

    [SerializeField]
    private List<CatalogFilterToggle> categoryToggles;
    [SerializeField]
    private List<CatalogItemData> allItems = new List<CatalogItemData>();

    public GameObject CatalogItemPrefab { get => catalogItemPrefab; set => catalogItemPrefab = value; }
    public Transform ItemsContentPanel { get => itemsContentPanel; set => itemsContentPanel = value; }
    public Transform FiltersContentPanel { get => filtersContentPanel; set => filtersContentPanel = value; }
    public List<CatalogFilterToggle> CategoryToggles { get => categoryToggles; set => categoryToggles = value; }

    private void Start()
    {
        LoadItems();
        LoadFilterToggles();
        UpdateCatalog();
    }

    private void LoadFilterToggles()
    {
        categoryToggles.Clear();

        CategorySO[] categories = Resources.LoadAll<CategorySO>(CATEGORIES_FOLDER);

        foreach (CategorySO category in categories)
        {
            GameObject filterToggleGameObject = Instantiate(filterTogglePrefab, filtersContentPanel);
            filterToggleGameObject.name = category + toggleSuffix;

            CatalogFilterToggle filterToggleComponent = filterToggleGameObject.GetComponent<CatalogFilterToggle>();
            filterToggleComponent.Category = category.Category;
            filterToggleComponent.onValueChanged.AddListener(delegate { UpdateCatalog(); });

            filterToggleGameObject.transform.GetChild(0).GetComponent<Image>().sprite = category.Sprite;

            categoryToggles.Add(filterToggleComponent);
        }
    }

    private void LoadItems()
    {
        allItems.Clear();

        ItemSO[] items = Resources.LoadAll<ItemSO>(ITEM_FOLDER);

        foreach (ItemSO item in items)
        {
            GameObject catalogButton = Instantiate(catalogItemPrefab, itemsContentPanel);
            catalogButton.GetComponent<Button>().onClick.AddListener(delegate { SelectObjectToPlace(catalogButton); });
            CatalogItemData catalogItemData = catalogButton.AddComponent<CatalogItemData>();
            catalogButton.GetComponent<Image>().sprite = item.Sprite;
            catalogItemData.Initialize(item.Id, item.Category, item.Sprite);
            allItems.Add(catalogItemData);
        }
    }

    private void UpdateCatalog()
    {
        foreach (CatalogItemData item in allItems)
        {
            bool shouldDisplay = false;

            foreach (var filter in categoryToggles)
            {
                if (filter.isOn && (string.Equals(item.Category, filter.Category, StringComparison.OrdinalIgnoreCase)))
                {
                    shouldDisplay = true;
                }
            }
            item.gameObject.SetActive(shouldDisplay);
        }
    }

    private void SelectObjectToPlace(GameObject catalogButton)
    {
        itemPlacer.ItemID = catalogButton.GetComponent<CatalogItemData>().Id;
    }

    public void ToggleMenu()
    {
        if (!canvasTransform.gameObject.activeInHierarchy)
        {
            if (isVR)
            {
                Vector3 spawnPosition = vrCameraRigTransform.position + vrCameraRigTransform.forward * 2.5f;
                Quaternion spawnRotation = Quaternion.LookRotation(vrCameraRigTransform.forward);
                gameObject.transform.position = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z);
                gameObject.transform.rotation = spawnRotation;

                VRInputMapManager.Instance.SwitchToCatalogMenuMode();
            }
            
            if(!isVR)
            {
                InputMapManager.Instance.SwitchToCatalogMenuActionMap();
                UIUtils.EnableUILock();
            }
            canvasTransform.gameObject.SetActive(true);
        }
        else
        {
            if (isVR)
            {
                VRInputMapManager.Instance.OnCloseMenuUI();
            }

            if (!isVR)
            {
                InputMapManager.Instance.SwitchToItemPlacementActionMap();
                UIUtils.DisableUILock();
            }
            canvasTransform.gameObject.SetActive(false);
        }
    }

}