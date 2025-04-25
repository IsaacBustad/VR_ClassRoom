// Written by Aaron Williams
using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] GameObject startButtonPanel;
    [SerializeField] GameObject createOrSelectRoomPanel;
    [SerializeField] GameObject roomSelectionPanel;
    [SerializeField] GameObject createRoomPanel;

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

    public void SelectRoomButtonPressed()
    {
        createOrSelectRoomPanel.SetActive(false);
        roomSelectionPanel.SetActive(true);
    }

    public void CreateRoomButtonPressed()
    {
        createOrSelectRoomPanel.SetActive(false);
        createRoomPanel.SetActive(true);
    }

    public void CreateRoomWithName(string inputRoomName)
    {
        JSONPlacementMannager.Instance.RoomConfigPath = inputRoomName;
        SceneManager.LoadScene(1);
    }

    public void SelectAndLoadIntoRoom(string room)
    {
        JSONPlacementMannager.Instance.RoomConfigPath = room;
        SceneManager.LoadScene(1);
    }

    private void CreateRoomButton(string roomName)
    {
        if (buttonPrefab != null && roomSelectionContent != null)
        {
            GameObject buttonGameObject = Instantiate(buttonPrefab, roomSelectionContent);
            buttonGameObject.name = "Room Option: [" + roomName + "] Button";

            TMP_Text buttonTextComponent = buttonGameObject.GetComponentInChildren<TMP_Text>();
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
            List<string> roomNames = JSONPlacementMannager.Instance.RoomList;

            if (roomNames != null && roomNames.Count > 0)
            {
                foreach (string roomName in roomNames)
                {
                    CreateRoomButton(roomName);
                }
            }
            else
            {
                Debug.LogError("Rooms not found.");
            }
        }
        else
        {
            Debug.LogError("RoomList is null");
        }
    }
}
