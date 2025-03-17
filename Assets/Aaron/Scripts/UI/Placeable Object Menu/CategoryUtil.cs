// Written by Aaron Williams
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CategoryUtil
{
    // TODO update these to be the actual categories used
    public const string INTERACTABLE = "interactable";
    public const string CHAIR = "chair";
    public const string TABLE = "table";
    public const string UTILITY = "utility";
    public const string OTHER = "other";

    public static List<string> Categories = new List<string> { INTERACTABLE, CHAIR, TABLE, UTILITY, OTHER };
}
