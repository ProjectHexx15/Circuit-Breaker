using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BillboardObj : MonoBehaviour
{
    // variables
    private SpriteRenderer sr; // stores the sprite renderer object that is on the object

    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // gets the sprite renderer
        sr.flipX = true; // flip the sprite on the x axis because the billboarding causes it to flip (this will return it back to normal)
    }

    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position); // makes the object constantly look at the camera

    } // end of late update

} // end of class
