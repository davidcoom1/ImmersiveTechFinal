// Chat GPT Helped Write this Script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryReceptacle : MonoBehaviour
{
    public GameObject door; // Reference to the door GameObject to control

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the receptacle is a battery cell
        if (other.CompareTag("BatteryCell"))
        {
            // Get the BatteryCell component from the object
            BatteryCell cell = other.GetComponent<BatteryCell>();
            if (cell != null)
            {
                if (cell.isCorrect)
                {
                    // If the correct battery is inserted, open the door
                    Debug.Log("Correct battery cell inserted, opening door...");
                    if (door != null)
                        door.GetComponent<DoorController>().OpenDoor();
                }
                else
                {
                    // If an incorrect battery is inserted, do nothing
                    Debug.Log("Incorrect battery cell, nothing happens.");
                }
            }
        }
    }
}

