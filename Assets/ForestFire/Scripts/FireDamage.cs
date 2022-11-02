using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class FireDamage : MonoBehaviour
{// List below is of the other scrips being used for this script
    public HealthBar healthBarScript;
    public TeleportationProvider movementTeleport;
    public ActionBasedContinuousMoveProvider movementWalking;

    public float damageValue; // float of how much damage the Fire will do

    public bool inTheFire; //bool controlling wheather the "PC" is in the Fire

    // Start is called before the first frame update
    void Start()
    {
        healthBarScript = GameObject.Find("PlayerModel").GetComponent<HealthBar>(); // This is a command for the fire to find the script for the Health Bar
        movementTeleport = GameObject.Find("XR Rig").GetComponent<TeleportationProvider>(); // This is a command for the fire to find the script for the Teleportation
        movementWalking = GameObject.Find("XR Rig").GetComponent<ActionBasedContinuousMoveProvider>(); // This is a command for the fire to find the script for the Continuous Movement
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other) // This command triggers an event when an object touchs the Fire
    {
        if (other.tag == "PC") // This is a check to ensure only the "PC" can interact with Fire
        {
            inTheFire = true; // This sets the bool as true

            StartCoroutine(Burn()); // This command starts the coroutine "Burn()"
        }
    }

    public IEnumerator Burn()
    {
        if (inTheFire == true) // This is a check to see if the bool is true
        {
            if (healthBarScript.playerCurrentHealth > 0) // This is a check to see if the "PC" Current Health Value is greater then 0, if so runs the commands below
            {
                healthBarScript.playerCurrentHealth = healthBarScript.playerCurrentHealth - damageValue; // This command removes the float value from the Player Current Health value
                yield return new WaitForSeconds(1f); // This command makes the script wait for 1 second before continuing

                StartCoroutine(Burn()); // This command start the coroutine "Burn()"
            }
            else // If the "PC" Health Value is 0 then disable the movement scripts 
            {
                movementTeleport.enabled = false;
                movementWalking.enabled = false;
            }
        }
        else //If the bool is false then stop the coroutine
        {
            StopCoroutine(Burn()); // This command stops the coroutine "Burn()"
        }
    }
    public void OnTriggerExit(Collider other) // This command triggers when an object leaves the Fire
    {
        if (other.tag == "PC") // This command is a check to Ensure only the "PC" can interact with the Fire
        {
            inTheFire = false; // This sets the bool as false
        }
    }
}


