using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Oculus.Interaction.Context;

public class StaticSceneManager : MonoBehaviour
{
    private static StaticSceneManager instance = null;
    private void OnEnable()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            instance = this;
        }
    }
    public static StaticSceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("StaticSceneManager").AddComponent<StaticSceneManager>();
            }
            return instance;
        }
    }
}
