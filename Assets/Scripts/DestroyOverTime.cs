using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    // variables
    public float lifeTime; // stores how long the object will live for before being destroyed

    private void Update()
    {
        Destroy(gameObject, lifeTime); // destroys the gameobject the script is attached too after the lifetime has past
    } // end of update

} // end of class
