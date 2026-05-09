using System.Net;
using System.Net.Sockets;
using UnityEngine;
using TMPro; // Use TextMeshPro for the UI

public class NetworkInfoDisplay : MonoBehaviour
{
    public TMP_Text ipDisplayText;

    void OnEnable()
    {
        string localIP = GetLocalIPv4();
        ipDisplayText.text = $"Host IP: {localIP}";
        
        // Log it to the console as well for easy copying
        Debug.Log($"Local IP Address: {localIP}");
    }

    private string GetLocalIPv4()
    {
        // Get all IP addresses associated with this machine
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

        foreach (var ip in host.AddressList)
        {
            // Filter for IPv4 and ignore "Internal" loopback (127.0.0.1)
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "No IPv4 Address Found";
    }
}