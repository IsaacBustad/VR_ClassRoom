// Isaac Bustad
// 6/22/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRotate : MonoBehaviour
{
    // camera is locked to orientation 
    [SerializeField] private Transform orientation;
    //player is rotated separately


    [SerializeField] private float xSence = 1.0f;
    [SerializeField] private float ySence = 1.0f;

    private float xRot;
    private float yRot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // calc rotation
        yRot += mouseX * xSence;
        xRot -= mouseY * ySence;
        // restrict rotation
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // apply rotation
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        //orientation.rotation = Quaternion.Euler(0, yRot, 0);




    }

    //accessors
    public float YRot { get { return yRot; } }
}
