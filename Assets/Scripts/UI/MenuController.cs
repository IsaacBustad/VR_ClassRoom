// Written by Aaron Williams
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// TODO integrate this with the player controller or something, as of now this is for testing.
public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public Transform playerTransform;
    public void ToggleMenu()
    {
        if(!menu.activeSelf)
        {
            Vector3 spawnPosition = playerTransform.position + playerTransform.forward * 2.5f;
            Quaternion spawnRotation = Quaternion.LookRotation(playerTransform.forward);
            menu.gameObject.transform.position = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z);
            menu.gameObject.transform.rotation = spawnRotation;
        }

        menu.SetActive(!menu.activeSelf);
    }
}