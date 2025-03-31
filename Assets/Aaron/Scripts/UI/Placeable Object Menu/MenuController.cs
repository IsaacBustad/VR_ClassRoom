// Written by Aaron Williams
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

// TODO integrate this with the player controller or something, as of now this is for testing.
public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public Transform playerTransform;
    public GameObject rightHand;

    public void ToggleItemCatalogMenu(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            if (!menu.activeSelf)
            {
                Vector3 spawnPosition = playerTransform.position + playerTransform.forward * 2.5f;
                Quaternion spawnRotation = Quaternion.LookRotation(playerTransform.forward);
                menu.gameObject.transform.position = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z);
                menu.gameObject.transform.rotation = spawnRotation;

                rightHand.SetActive(false);
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                menu.SetActive(false);
                rightHand.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}