using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // variables
    public Camera playerCam; // stores the transform of the player camera object

    public GameObject bulletImpact; // references the bulletImpact prefab GO

    public int currentAmmo = 30; // stores how much ammo the player has currently 

    public int maxAmmo = 30; // stores the maximum amount of ammo that the player is allowed to hold

    public int ammoBox = 5; // each ammo box will give the player this many more shots

    public Animator gunAnim; // stores the Animator component that is atached to the players gun

    public static PlayerShooting Instance; // creates a static instance of this script

    private void Awake()
    {
        Instance = this;
    } // end of awake

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) // if the player right clicks
            // could use get mouse down for a different type of gun?

            if(currentAmmo > 0)
            {
                {
                    Ray ray = playerCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f)); // ray cast through the middle of the screen
                    RaycastHit hit; //stores if the ray hits something or not
                    if (Physics.Raycast(ray, out hit)) // if the ray hits something
                    {
                        Instantiate(bulletImpact, hit.point, transform.rotation); // spawns the bulletimpact prefab at the position where the ray hits an object
                    }
                    else
                    {
                        Debug.Log("im looking  at nothing"); // raycast hits nothing
                    }
                    currentAmmo--; // player uses up one ammo
                    gunAnim.SetTrigger("Shoot"); // triggers the "shoot" trigger that lets us know to play the shooting animation
                }
            }
    }

    public void IncreaseAmmo()
    {
        currentAmmo += ammoBox; // adds the amount of bullets in the box to the players ammocount
        if(currentAmmo > maxAmmo) // if the player has more ammo than they should have
        {
            currentAmmo = maxAmmo; // set their ammo back to the maximum amount
        }


    } // end of IncreaseAmmo

   
} // end of class
