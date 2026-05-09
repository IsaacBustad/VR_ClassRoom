// Created by   :   Isaac Bustad
// Created      :   5/8/2026

// Gemeni Assisted

using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using TMPro; // Use TextMeshPro for the IP input

public class NetworkBootstrap : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject connectionPanel;
    [SerializeField] private TMP_InputField ipInputField;

    [Header("Settings")]
    [SerializeField] private string defaultIP = "127.0.0.1";
    [SerializeField] private ushort port = 7777;

    private UnityTransport transport;

    private void Start()
    {
        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        
        // Pre-fill the input field with a default
        if (ipInputField != null)
            ipInputField.text = defaultIP;
    }

    public void StartHost()
    {
        // Hosting usually binds to all local interfaces
        NetworkManager.Singleton.StartHost();
        HideUI();
    }

    public void StartClient()
    {
        string targetIP = ipInputField != null ? ipInputField.text : defaultIP;
        
        // Configure the transport with the UI's IP address
        transport.SetConnectionData(targetIP, port);
        
        NetworkManager.Singleton.StartClient();
        HideUI();
    }

    private void HideUI()
    {
        if (connectionPanel != null)
        {
            connectionPanel.SetActive(false);
        }
    }
}
