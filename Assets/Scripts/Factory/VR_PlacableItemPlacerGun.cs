// Isaac Bustad
// 3/14/2025


using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class VR_PlacableItemPlacerGun : PlacableItemPlacer
{
    // Vars
    //[SerializeField] protected OVRInput.Button button;
    //[SerializeField] protected GrabInteractable grabbable;

    //[SerializeField] protected OVRGrabber grabber;




    // Methods
    protected override void OnEnable()
    {
        //grabbable = GetComponent<OVRGrabbable>();
        base.OnEnable();

        //grabbable.;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("is it just me " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("is it just me leaving " + other.gameObject.name);
    }


    private void Update()
    {
        /*if ( != null)
        {
            Debug.Log("The Man Who Grabed me Is = " + grabbable.grabbedBy.gameObject.name);
        }*/
    }





    // Accessors




}
