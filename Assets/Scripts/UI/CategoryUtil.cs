// Written by Aaron Williams
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CategoryUtil
{
    // TODO update these to be the actual categories used
    private const string INTERACTABLE = "interactable";
    private const string CHAIR = "chair";
    private const string TABLE = "table";
    private const string UTILITY = "utility";
    private const string OTHER = "other";

    public static List<string> Categories = new List<string> { INTERACTABLE, CHAIR, TABLE, UTILITY, OTHER };
}
