// Written by Aaron Williams
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// TODO integrate this with the player controller or something, as of now this is for testing.
public class JankTempToggler : MonoBehaviour
{
    public GameObject thing;
    public void ToggleThing()
    {
        thing.SetActive(!thing.activeSelf);
    }
}