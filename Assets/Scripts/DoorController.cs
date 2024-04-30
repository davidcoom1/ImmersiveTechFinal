// Chat GPT Helped Write this Script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door; // Assign the part of the door that should move.
    public Vector3 openPosition; // Set this to the position the door should slide to.
    public float openSpeed = 1f; // Speed at which the door opens.
    public float OpenDuration { get; private set; } // The estimated time it takes for the door to open completely.

    private bool isOpening = false;
    private float moveDistance;

    void Start()
    {
        moveDistance = Vector3.Distance(door.position, openPosition);
        OpenDuration = moveDistance / openSpeed; // Calculate the duration it takes to open the door.
    }

    void Update()
    {
        if (isOpening)
        {
            // Slide the door open
            door.position = Vector3.MoveTowards(door.position, openPosition, openSpeed * Time.deltaTime);
            if (door.position == openPosition)
            {
                isOpening = false; // Stops the door from further movement once it's open.
            }
        }
    }

    // Call this method to open the door
    public void OpenDoor()
    {
        isOpening = true;
    }
}
