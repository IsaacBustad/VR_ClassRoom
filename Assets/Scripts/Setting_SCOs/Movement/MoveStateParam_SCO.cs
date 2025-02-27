// Isaac Bustad
//1/21/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveStateParams_SCO", menuName = "ScriptableObject/MoveStateParams_SCO")]
public class MoveStateParam_SCO : ScriptableObject
{
    // Vars
    [SerializeField, Range(1,10)] protected float maxSpeed = 4f;
    [SerializeField, Range(0,100)] protected float accelleration = 10f;
    [SerializeField, Range(0, 1)] protected float timeToTween = .25f;



    // Methods




    // Accessors
    public virtual float MaxSpeed {get{ return maxSpeed; }}
    public virtual float Accelleration { get {  return accelleration; }}
    public virtual float TimeToTween { get {  return timeToTween; }}



}
