using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float playerMaxHealth; // This is a float of how high the "PC" Max Health Value is
    public float playerCurrentHealth; // This is a float for the value of the "PC" Current Health

    public GameObject gameOverText; // This is a Text screen displaying "Game Over" text

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth; // This command makes the "PC" Max Health equal the Current Health equal the same from the application has started
        gameOverText.SetActive(false); // This sets the text to be invisible
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0) // This command checks to see if the "PC" Current Health is equal or lower then zero, if so runs the lines below
        {
            gameOverText.SetActive(true); // This sets the text to be visible
        }
        }
    }

