using BugFreeProductions.Tools;
using Oculus.Interaction.Editor.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMapManager : MonoBehaviour
{
    private static InputMapManager instance = null;

    public PlayerInput playerInput;

    public const string DEFAULT_INPUT_MAP = "Default_State_Input";

    public const string ROOM_CREATION_INPUT_MAP = "Room_Creation_Input";

    public const string ITEM_PLACEMENT_INPUT_MAP = "Item_Placement_Input";

    public RoomGenerator roomGenerator;

    public PlacableItemPlacer placableItemPlacer;

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
            SwitchToDefaultActionMap();
        }
    }

    public static InputMapManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("InputMapManager").AddComponent<InputMapManager>();
            }
            return instance;
        }
    }

    public void SwitchToActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
    }

    public void SwitchToDefaultActionMap()
    {
        playerInput.SwitchCurrentActionMap(DEFAULT_INPUT_MAP);
        placableItemPlacer.enabled = false;
        roomGenerator.enabled = false;
    }

    public void SwitchToRoomCreationActionMap()
    {
        playerInput.SwitchCurrentActionMap(ROOM_CREATION_INPUT_MAP);
        placableItemPlacer.enabled = false;
        roomGenerator.enabled = true;
    }

    public void SwitchToItemPlacementActionMap()
    {
        playerInput.SwitchCurrentActionMap(ITEM_PLACEMENT_INPUT_MAP);
        placableItemPlacer.enabled = true;
        roomGenerator.enabled = false;
}
}
