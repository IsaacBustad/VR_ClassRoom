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
            currentMode = Mode.Default;
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
        previousMode = currentMode;
        currentMode = Mode.Default;

        if (previousMode != Mode.Default)
        {
            SwitchToDefaultMode();
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
                SwitchToDefaultMode();
                break;
        }

        previousMode = Mode.Default;
    }

    public void SwitchToDefaultMode()
    {
        currentMode = Mode.Default;
        placableItemGun.SetActive(false);
        roomGenerator.SetActive(false);
    }

    public void SwitchToRoomCreationMode()
    {
        currentMode = Mode.RoomCreation;
        placableItemGun.SetActive(false);
        roomGenerator.SetActive(true);
    }

    public void SwitchToItemPlacementMode()
    {
        currentMode = Mode.ItemPlacement;
        placableItemGun.SetActive(true);
        roomGenerator.SetActive(false);
    }

    public void SwitchToCatalogMenuMode()
    {
        previousMode = currentMode;
        currentMode = Mode.Default;
        placableItemGun.SetActive(false);
        roomGenerator.SetActive(false);
    }

    public enum Mode
    {
        Default,
        RoomCreation,
        ItemPlacement
    }
}
