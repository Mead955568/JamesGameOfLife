using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireWaterPistol : MonoBehaviour
{
    public GameObject bullet; // The Bullet Prefab
    public Transform spawnPoint;
    public float fireSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>(); // Finds the XR grab script to attach to the Bullet
        grabbable.activated.AddListener(FireBullet); // Command to use the Trigger to fire the Bullet
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position; // The place where the Bullet spawns
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed; // Speed of which the Bullet moves
        Destroy(spawnedBullet, 5); // Destroys the Bullet after a set distence
    }
}
