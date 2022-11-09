using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPool : MonoBehaviour
{// The two commands below enable the "HealthBar" script and the "ForestFireCell" script to be used for this script
    public HealthBar healthBarScript;
    public ForestFireCell cellGenerationScript;

    public float healingValue; // float of how much Healing the Water Cell will do

    public bool inTheWater; // bool controlling wheather the "PC" is on a Water Cell
    //public void HealingWater()
    //{
    //    if (cellGenerationScript = GameObject.Find("ForestFireCell").GetComponent<ForestFireCell>()); // This command finds the Forest Fire Cell to apply the script on water tiles
    //}

    // Start is called before the first frame update
    void Awake()
    {
        healthBarScript = GameObject.Find("PlayerModel").GetComponent<HealthBar>(); // This is a command for the fire to find the script for the Health Bar
    }

    // Update is called once per frame
    void Update()
    { 
    
    }
    public void OnTriggerEnter(Collider other) // This command triggers an event when an object touchs the Water Cell
    {
        if (other.tag == "PC") // This command checks if the object that touchs the Water Cell is the "PC"
            {
                inTheWater = true; // Thic command makes the bool true

                StartCoroutine(Heal()); // This command starts the coroutine "Heal()"
            }
    }
    public IEnumerator Heal()
    {
        if (inTheWater == true) // This is a check to see if the bool is true
        {
            if (healthBarScript.playerCurrentHealth < healthBarScript.playerMaxHealth) // This is a check to see if the "PC" Current Health Value is less then the "PC" Max Health Value
            {
                healthBarScript.playerCurrentHealth = healthBarScript.playerCurrentHealth + healingValue; // This command adds the float value from the Player Current Health value
                yield return new WaitForSeconds(1f); // This command makes the script wait for 1 second before continuing
                Debug.Log("Health = " + healthBarScript.playerCurrentHealth); // This is a Debug to check how much health the "PC" has left
                StartCoroutine(Heal()); // This coroutine starts the coroutine "Heal()"
            }
            else // This command makes the script do nothing if the "PC" Current Health Value is equal to the "PC" Max Health Value
            { 
            }
        }
        else
        {
            StopCoroutine(Heal()); // This command stops the coroutine "Heal()"
        }
    }
    public void OnTriggerExit(Collider other) // This command triggers when an object leaves the Water Cell
    {
        if (other.tag == "PC") // This command is a check to ensure on the "PC" can interact with the Water Cell
        {
            inTheWater = false; // THis sets the bool as false
        }
    }
}
