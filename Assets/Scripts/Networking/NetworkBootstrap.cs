// Created by   :   Isaac Bustad
// Created      :   5/8/2026

// Gemeni Assisted

using UnityEngine;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using System.Net;
using System.Net.Sockets;
using Unity.VisualScripting;

public class NetworkBootstrap : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text displayIpText;      // Shows YOUR IP to read to others
    [SerializeField] private TMP_InputField inputField;   // Where you type the Host's IP
    [SerializeField] private string manualIpTarget;     // manualy targets a set ip


    [Header("")]
    [SerializeField] private UnityTransport transport;

    void Start()
    {
        // Automatically find and display this machine's IP
        string myAddress = GetLocalIPv4();
        displayIpText.text = $"My IP: {myAddress}";
        
        Debug.Log($"Network Bootstrap Initialized. Local IP: {myAddress}");
    }

    // Call this from a UI Button on the Host machine (Desktop)
    public void StartHost()
    {
        // The Host doesn't need to change its transport address (default 0.0.0.0 is fine)
        NetworkManager.Singleton.StartHost();
        Debug.Log("Hosting started.");
    }

    // Call this from a UI Button on the Client machine (Laptop)
    public void StartClient()
    {
        
        string targetIP = inputField.text;

        if(manualIpTarget != null)
        {
            // Update the transport with the address typed into the UI
            transport.SetConnectionData(manualIpTarget, 7777);
            NetworkManager.Singleton.StartClient();
            Debug.Log($"Attempting to connect to Host at: {targetIP}");
        }

        else if (!string.IsNullOrEmpty(targetIP))
        {
            // Update the transport with the address typed into the UI
            transport.SetConnectionData(targetIP, 7777);
            NetworkManager.Singleton.StartClient();
            Debug.Log($"Attempting to connect to Host at: {targetIP}");
        }
        else
        {
            displayIpText.text = "ERROR: Enter an IP first!";
        }
    }

    // Helper method to grab the IPv4 address
    private string GetLocalIPv4()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            // Ensure we grab the standard IPv4 internal network address
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "127.0.0.1"; // Fallback to localhost
    }
}
