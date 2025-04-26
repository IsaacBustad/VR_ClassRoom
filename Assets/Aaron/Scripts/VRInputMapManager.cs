// Written by Aaron Williams
using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRInputMapManager : MonoBehaviour
{
    private static VRInputMapManager instance = null;

    public GameObject roomGenerator;

    public GameObject placableItemGun;

    public Mode previousMode;

    public Mode currentMode;

    private void OnEnable()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            instance = this;
        }
    }

    public static VRInputMapManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("VRInputMapManager").AddComponent<VRInputMapManager>();
            }
            return instance;
        }
    }

    public void OnOpenRadialMenuUI()
    {
        if (previousMode != Mode.Default)
        {
            SwitchToDefaultMode(true);
        }
    }

    public void OnCloseMenuUI()
    {
        switch (previousMode)
        {
            case Mode.RoomCreation:
                SwitchToRoomCreationMode();
                break;
            case Mode.ItemPlacement:
                SwitchToItemPlacementMode();
                break;
            default:
                SwitchToDefaultMode(false);
                break;
        }
    }

    public void SwitchToDefaultMode(bool isForRadialMenu)
    {
        if (!isForRadialMenu) { previousMode = Mode.Default; }
        placableItemGun.SetActive(false);
        roomGenerator.SetActive(false);
        roomGenerator.GetComponent<RoomGenerator>().HideFloorPoints();
    }

    public void SwitchToRoomCreationMode()
    {
        previousMode = Mode.RoomCreation;
        placableItemGun.SetActive(false);
        roomGenerator.SetActive(true);
        roomGenerator.GetComponent<RoomGenerator>().ShowFloorPoints();
    }

    public void SwitchToItemPlacementMode()
    {
        previousMode = Mode.ItemPlacement;
        placableItemGun.SetActive(true);
        roomGenerator.SetActive(false);
        roomGenerator.GetComponent<RoomGenerator>().HideFloorPoints();
    }

    public void SwitchToCatalogMenuMode()
    {
        if (previousMode != Mode.Default)
        {
            SwitchToDefaultMode(true);
        }
    }
    public bool IsInPlacerMode()
    {
        return previousMode == Mode.ItemPlacement;
    }

    public enum Mode
    {
        Default,
        RoomCreation,
        ItemPlacement,
        CatalogMenu,
        NULL
    }
}
