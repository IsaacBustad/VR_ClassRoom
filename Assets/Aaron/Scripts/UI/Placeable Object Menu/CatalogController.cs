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
    // TODO update this to the final folder names inside of Resources
    // TODO switch back to const string, not const rn to make testing easier and string visible/editable in editor
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

    private void OnEnable()
    {
        EnableMenu();
    }
    private void LoadFilterToggles()
    {
        categoryToggles.Clear();

        // TODO change this to the final scriptableObject type when ready
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

    public void EnableMenu()
    {
        if (!canvasTransform.gameObject.activeSelf)
        {
            //if(isVR)
            //{
            //    //Vector3 spawnPosition = playerTransform.position + playerTransform.forward * 2.5f;
            //    //Quaternion spawnRotation = Quaternion.LookRotation(playerTransform.forward);
            //    //menu.gameObject.transform.position = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z);
            //    //menu.gameObject.transform.rotation = spawnRotation;

            //    //rightHand.SetActive(false);
            //}
            Debug.Log("Cursor should be visible");
            canvasTransform.gameObject.SetActive(true);
            UIUtils.EnableUILock();
        }
        else
        {
            canvasTransform.gameObject.SetActive(false);
            //rightHand.SetActive(true);
            UIUtils.DisableUILock();
        }
    }

}