// Written by Aaron Williams
using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] GameObject startButtonPanel;
    [SerializeField] GameObject createOrSelectRoomPanel;
    [SerializeField] GameObject roomSelectionPanel;

    [SerializeField] Transform roomSelectionContent;
    [SerializeField] GameObject buttonPrefab;

    private void Start()
    {
        PopulateRoomButtons();
    }

    public void StartButtonPressed()
    {
        startButtonPanel.SetActive(false);
        createOrSelectRoomPanel.SetActive(true);
    }

    public void CreateRoomButtonPressed()
    {
        // switch into main scene with an empty room config
    }

    public void SelectRoomButtonPressed()
    {
        createOrSelectRoomPanel.SetActive(false);
        roomSelectionPanel.SetActive(true);
    }

    public void SelectAndLoadIntoRoom(string room)
    {
        // StaticSceneManager.Instance.LoadScene
        // switch into main scene with the selected room config
    }

    private void CreateRoomButton(string roomName)
    {
        if (buttonPrefab != null && roomSelectionContent != null)
        {
            GameObject buttonGameObject = Instantiate(buttonPrefab, roomSelectionContent);
            buttonGameObject.name = "Room Option: [" + roomName + "] Button";

            Text buttonTextComponent = buttonGameObject.GetComponentInChildren<Text>();
            if (buttonTextComponent != null)
            {
                buttonTextComponent.text = roomName;
            }

            Button buttonButtonComponent = buttonGameObject.GetComponent<Button>();
            if (buttonButtonComponent != null)
            {
                buttonButtonComponent.onClick.AddListener(() => SelectAndLoadIntoRoom(roomName));
            }
        }
    }

    private void PopulateRoomButtons()
    {
        if (JSONPlacementMannager.Instance != null && JSONPlacementMannager.Instance.RoomList != null)
        {
            string[] roomNames = JSONPlacementMannager.Instance.RoomList.roomsLST;

            if (roomNames != null && roomNames.Length > 0)
            {
                foreach (string roomName in roomNames)
                {
                    CreateRoomButton(roomName);
                }
            }
            else
            {
                Debug.LogWarning("Rooms not found, inner else");
            }
        }
        else
        {
            Debug.LogWarning("RoomList is null");
        }
    }
}
