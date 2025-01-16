// Isaac Bustad
// 8/2/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "RacerSetting", menuName = "ScriptableObject/RacerSetting")]
public class RacerSetting
{
    // Vars
    
    protected int playerID = 0;
    protected GameObject playerPrefab;

    // Methods


    // Accessors
    public int PlayerID {  get { return playerID; } set { playerID = value; } }
    public GameObject PlayerPrefab { get {  return playerPrefab; } set {  PlayerPrefab = value; } }


}
