using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguish : MonoBehaviour
{
    public ForestFireCell cellGeneration;
    public FireWaterPistol waterPistol;

    public bool isInFire;
    // Start is called before the first frame update
    void Start()
    {
        cellGeneration = GameObject.Find("ForestFireCell").GetComponent<ForestFireCell>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire") // This is a check to ensure only the "Bullet" can interact with Fire
        {
            isInFire = true; // This sets the bool as true
            
            cellGeneration.SetBurnt();
        }
        else
        {
            isInFire= false;
        }
    }
}
