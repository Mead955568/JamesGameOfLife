using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguish : MonoBehaviour
{
    public ForestFireCell cellGeneration;
    public ForestFire3D cell3D;
    public HealthBar playerScoreScript;

    public bool isInFire;
    public float fireScore;
// Start is called before the first frame update
//void Awake()
//    {
//        cellGeneration = GameObject.Find("ForestFireCell").GetComponent<ForestFireCell>(); // This is a command for the "Bullet" to find the script for the Forest Fire Cell
//        cell3D = GameObject.Find("ForestFire3D").GetComponent<ForestFire3D>() ; // This  is a command for the "Bullet" to find the script for the Forest Fire 3D
//    }

    // Update is called once per frame
    void Update()
    {
        //if(cellGeneration == null)
        //{
        //    cellGeneration = GameObject.Find("ForestFireCell").GetComponent<ForestFireCell>(); // This is a command for the "Bullet" to find the script for the Forest Fire Cell

        //}
        //if (cell3D == null)
        //{
        //    cell3D = GameObject.Find("ForestFire3D").GetComponent<ForestFire3D>(); // This  is a command for the "Bullet" to find the script for the Forest Fire 3D

        //}
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire") // This is a check to ensure only the "Bullet" can interact with Fire
        {
            isInFire = true; // This sets the bool as true
            Debug.Log("The Bullet Has Hit");
        } 
        if (other.tag == "OnFire") // THis is a check to only activate the cells that are "OnFire"
        {
            Debug.Log("The Bullet Has Hit The Floor");
            cellGeneration = other.GetComponent<ForestFireCell>();
            cellGeneration.ResetCell(); // This Resets the Cell
            cellGeneration.SetBurnt(); // This sets the Cell as "Burnt"

            playerScoreScript = GameObject.Find("PlayerModel").GetComponent<HealthBar>();
            playerScoreScript.playerScore = playerScoreScript.playerScore + fireScore;
            Debug.Log(playerScoreScript.playerScore);
        }
    }
}
