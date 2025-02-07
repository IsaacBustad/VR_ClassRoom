// Written by Aaron Williams
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
    private Transform canvasTransform;
    [SerializeField]
    private GameObject catalogItemPrefab;
    [SerializeField]
    private GameObject filterTogglePrefab;
    [SerializeField]
    private Transform contentPanel;

    // TODO Create the filters with code instead of in the editor
    [SerializeField]
    private List<CatalogFilterToggle> categoryToggles;
    [SerializeField]
    private List<CatalogItemData> allItems = new List<CatalogItemData>();

    public GameObject CatalogItemPrefab { get => catalogItemPrefab; set => catalogItemPrefab = value; }
    public Transform ContentPanel { get => contentPanel; set => contentPanel = value; }
    public List<CatalogFilterToggle> CategoryToggles { get => categoryToggles; set => categoryToggles = value; }

    private void Start()
    {
        LoadItems();
        TempDrawToggles();
        UpdateCatalog();
    }

    // TODO fix this to look how Isaac wants it
    private void TempDrawToggles()
    {
        AssembleToggleButton(CategoryUtil.INTERACTABLE, -140f, 85f);

        AssembleToggleButton(CategoryUtil.CHAIR, -140f, 55f);

        AssembleToggleButton(CategoryUtil.TABLE, -140f, 25f);

        AssembleToggleButton(CategoryUtil.UTILITY, -140f, -5f);

        AssembleToggleButton(CategoryUtil.OTHER, -140f, -35f);
    }

    // TODO fix this to look how Isaac wants it
    private void AssembleToggleButton(string category, float paramX, float paramY)
    {
        GameObject filterToggleGameObject = Instantiate(filterTogglePrefab, canvasTransform);
        filterToggleGameObject.transform.localPosition = new Vector3(paramX, paramY, 0);

        CatalogFilterToggle filterToggleComponent = filterToggleGameObject.GetComponent<CatalogFilterToggle>();
        filterToggleComponent.Category = category;
        filterToggleComponent.onValueChanged.AddListener(delegate { UpdateCatalog(); });
        categoryToggles.Add(filterToggleComponent);

        filterToggleGameObject.GetComponentInChildren<Text>().text = category;
    }

    private void LoadItems()
    {
        allItems.Clear();

        // TODO change this to the final scriptableObject type when ready
        ItemSO[] items = Resources.LoadAll<ItemSO>(ITEM_FOLDER);

        foreach (ItemSO item in items)
        {
            GameObject catalogButton = Instantiate(catalogItemPrefab, contentPanel);
            CatalogItemData catalogItemData = catalogButton.AddComponent<CatalogItemData>();
            //TODO make a better way to load this
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

                if (filter.isOn && item.Category == filter.Category)
                {
                    shouldDisplay = true;
                }
            }
            item.gameObject.SetActive(shouldDisplay);
        }
    }
}