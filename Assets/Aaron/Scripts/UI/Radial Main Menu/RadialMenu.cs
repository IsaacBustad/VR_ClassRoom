using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    [Header("Is In Virtual Reality")]
    [SerializeField] private bool isVR;
    [SerializeField] private Camera mainCamera;

    [Header("UI Options")]
    [SerializeField] private List<MenuOption> Menus;

    [Header("VR Controller Settings")]
    [SerializeField] private OVRInput.Controller ovrController = OVRInput.Controller.RTouch;
    [SerializeField] private OVRInput.Button selectOptionButton = OVRInput.Button.PrimaryIndexTrigger;

    [Header("Keybaord + Mouse Settings")]
    [SerializeField] private KeyCode menuActivationKey;

    [Header("Radial MenuGameObject Settings")]
    
    [SerializeField] private float segmentPadding;

    [Header("Editor Assigments")]
    [SerializeField] private Transform menuCanvas;
    [SerializeField] private Transform handTransform;
    [SerializeField] private GameObject haloPrefab;
    [SerializeField] private GameObject centerText;

    [Header("Spawning Adjustments")]
    [SerializeField] private float menuDistanceOffset = 0.15f;
    [SerializeField] private float kbmMenuDistanceOffset = 0.5f;

    private List<GameObject> radialMenuOption = new();

    private int selectedMenuOption;

    private const string CLOSE = "Close";

    private void Start()
    {
        InitializeRadialMenu();
    }
    private void Update()
    {
        if(isVR)
        {
            HandleVRInput();
        }
        else
        {
            if (menuCanvas.gameObject.activeInHierarchy)
            {
                GetSelectedRadialPart();

                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("selected option");
                    SelectMenuOption();
                }
            }
        }
    }

    private void HandleVRInput()
    {
        // TODO: Update to new input system
        if (OVRInput.GetDown(selectOptionButton, ovrController))
        {
            EnableRadialMenu();
        }

        if (OVRInput.Get(selectOptionButton, ovrController))
        {
            GetSelectedRadialPart();
        }

        if (OVRInput.GetUp(selectOptionButton, ovrController))
        {
            SelectMenuOption();
        }
    }

    public void HandleKBMInput(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            if (!menuCanvas.gameObject.activeInHierarchy)
            {
                EnableRadialMenu();
            }
            else
            {
                DisableRadialMenu(false);
            }
        }
    }

    private void InitializeRadialMenu()
    {
        if (isVR)
        {
            menuCanvas.gameObject.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        }
        else
        {
            menuCanvas.gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        }
        
        Menus.Insert(1, new MenuOption(CLOSE));

        for (int i = 0; i < Menus.Count; i++)
        {
            float angle = -i * 360 / Menus.Count - segmentPadding / 2;
            Vector3 radialPartEulerAngle = new Vector3(0, 0, angle);

            GameObject menOption = Instantiate(haloPrefab, menuCanvas);
            menOption.transform.position = menuCanvas.position;
            menOption.transform.localEulerAngles = radialPartEulerAngle;

            menOption.GetComponent<Image>().fillAmount = (1 / (float)Menus.Count) - (segmentPadding / 360);

            radialMenuOption.Add(menOption);
        }
    }

    private void GetSelectedRadialPart()
    {
        Vector3 selectionPoint;

        if (isVR)
        {
            selectionPoint = GetTransform().position;
        }
        else
        {
            Vector2 mousePosition = Input.mousePosition;
            selectionPoint = mousePosition;
        }

        Vector3 centerToSelectionPoint = selectionPoint - menuCanvas.position;
        Vector3 centerToSelectionPointProjected = Vector3.ProjectOnPlane(centerToSelectionPoint, menuCanvas.forward);

        float angle = Vector3.SignedAngle(menuCanvas.up, centerToSelectionPointProjected, -menuCanvas.forward);

        if (angle < 0) { angle += 360; }

        selectedMenuOption = (int)angle * Menus.Count / 360;

        foreach (GameObject menuOption in radialMenuOption)
        {
            menuOption.GetComponent<Image>().color = Color.white;
            menuOption.transform.localScale = Vector3.one;
            menuOption.GetComponentInChildren<Text>().enabled = false;
        }

        for (int i = 0; i < radialMenuOption.Count; i++)
        {
            if (i == selectedMenuOption)
            {
                radialMenuOption[i].GetComponent<Image>().color = Color.green;
                radialMenuOption[i].transform.localScale = 1.1f * Vector3.one;
                radialMenuOption[i].GetComponentInChildren<Text>().enabled = true;
                centerText.GetComponent<Text>().text = Menus[selectedMenuOption].MenuName;
            }
            else
            {
                radialMenuOption[i].GetComponent<Image>().color = Color.white;
                radialMenuOption[i].transform.localScale = Vector3.one;
                radialMenuOption[i].GetComponentInChildren<Text>().enabled = false;
            }
        }
    }

    private void SelectMenuOption()
    {
        radialMenuOption[selectedMenuOption].SetActive(true);

        foreach(MenuOption menu in Menus)
        {
            if (menu.MenuGameObject != null)
            {
                menu.MenuGameObject.SetActive(false);
            }
        }

        if (selectedMenuOption < radialMenuOption.Count - 1 && Menus[selectedMenuOption].MenuName != CLOSE)
        {
            Menus[selectedMenuOption].MenuGameObject.SetActive(true);
            DisableRadialMenu(true);
        }
        else
        {
            DisableRadialMenu(false);
        }
    }

    public void EnableRadialMenu()
    {
        if(!isVR)
        {
            UIUtils.EnableUILock();
        }

        menuCanvas.gameObject.SetActive(true);

        Vector3 eulerAngles = GetTransform().rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        menuCanvas.rotation = Quaternion.Euler(eulerAngles);

        menuCanvas.position = GetTransform().position + (Vector3.forward * GetDistanceOffset());
    }

    public void DisableRadialMenu(bool selectedNewMenu)
    {
        if (!isVR && !selectedNewMenu)
        {
            UIUtils.DisableUILock();
        }
        menuCanvas.gameObject.SetActive(false);
    }

    private Transform GetTransform()
    {
        return isVR? handTransform : mainCamera.transform;
    }
    private float GetDistanceOffset()
    {
        return isVR ? kbmMenuDistanceOffset : menuDistanceOffset;
    }
}

[System.Serializable]
public class MenuOption
{
    [SerializeField] private string menuName;
    [SerializeField] private GameObject menuGameObject;

    public string MenuName { get => menuName; set => menuName = value; }
    public GameObject MenuGameObject { get => menuGameObject; set => menuGameObject = value; }

    public MenuOption(string name, GameObject menu = null)
    {
        this.menuName = name;
        this.menuGameObject = menu;
    }
}
