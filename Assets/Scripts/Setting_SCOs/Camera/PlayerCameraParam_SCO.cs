// Isaac Bustad
// 1/22/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerCameraParam_SCO", menuName = "ScriptableObject/PlayerCameraParam_SCO")]
public class PlayerCameraParam_SCO : ScriptableObject
{
    // Vars
    // "Sensitivity"
    [SerializeField, Range(0, 90)] protected float maxRot = 90f;
    [SerializeField, Range(1,45)] protected float rotSpeed = 10f;
    [SerializeField, Range(0,3)] protected float timeToTween = 0.25f;


    // Methods




    // Accessors
    public virtual float RotSpeed { get { return rotSpeed; } }
    public virtual float TimeToTween { get {  return timeToTween; } }



}
