using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerShooting.Instance.IncreaseAmmo(); // go to the player shooting script and add the correct amount of ammo
        Destroy(this.gameObject); // remove the ammo when the player collects it
    }

} // end of class
