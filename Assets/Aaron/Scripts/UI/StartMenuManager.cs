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
    [SerializeField] private GameObject startButtonPanel;
    [SerializeField] private GameObject createOrSelectRoomPanel;
    [SerializeField] private GameObject roomSelectionPanel;
    [SerializeField] private GameObject createRoomPanel;

    [SerializeField] private Transform roomSelectionContent;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private TMP_InputField textInput;

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

    public void CreateRoomWithName()
    {
        JSONPlacementMannager.Instance.RoomConfigPath = textInput.text;
        Debug.Log("Creating room with name: " + textInput.text);
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
                Debug.Log("Rooms not found.");
            }
        }
        else
        {
            Debug.Log("RoomList is null");
        }
    }
}
