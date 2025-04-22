using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMapManager : MonoBehaviour
{

    public PlayerInput playerInput;

    public const string DEFAULT_INPUT_MAP = "Default_State_Input";

    public const string ROOM_CREATION_INPUT_MAP = "Room_Creation_Input";

    public const string ITEM_PLACEMENT_INPUT_MAP = "Item_Placement_Input";


    public void SwitchToActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
    }
    public void SwitchToDefaultActionMap()
    {
        playerInput.SwitchCurrentActionMap(DEFAULT_INPUT_MAP);
    }
    public void SwitchToRoomCreationActionMap()
    {
        playerInput.SwitchCurrentActionMap(ROOM_CREATION_INPUT_MAP);
    }
    public void SwitchToItemPlacementActionMap()
    {
        playerInput.SwitchCurrentActionMap(ITEM_PLACEMENT_INPUT_MAP);
    }
}
