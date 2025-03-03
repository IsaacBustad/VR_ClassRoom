// Isaac Bustad
// 1/22/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerCameraParam_SCO", menuName = "ScriptableObject/PlayerCameraParam_SCO")]
public class PlayerCameraParam_SCO : ScriptableObject
{
    // Vars
    // for camera manager and context (sensitivity)
    [SerializeField, Range(0, 90)] protected float maxRot = 90f;
    [SerializeField, Range(1,45)] protected float rotSpeed = 10f;
    [SerializeField, Range(0,3)] protected float timeToTween = 0.25f;

    // for input bridge re zeroing
    //[SerializeField, Range(0,3)] protected float reZeroSpeed = 0.25f;
    [SerializeField, Range(0,3)] protected float reZeroBuff = 0.025f;


    // Methods




    // Accessors

    // Access for camera manager and context (sensitivity)
    public virtual float RotSpeed { get { return rotSpeed; } }
    public virtual float MaxRot { get { return maxRot; } }
    public virtual float TimeToTween { get {  return timeToTween; } }


    // Access for input bridge re zeroing
    //public virtual float ReZeroSpeed { get {  return reZeroSpeed; } }
    public virtual float ReZeroBuff { get {  return reZeroBuff; } }



}
