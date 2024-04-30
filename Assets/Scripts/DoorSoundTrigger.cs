// Chat GPT Helped Write this Script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundTrigger : MonoBehaviour
{
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    public AudioSource audioSource; // Assign this in the inspector

    void Start()
    {
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the door has moved
        if (transform.position != lastPosition || transform.rotation != lastRotation)
        {
            // Play the sound
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // Update last position and rotation
            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }
    }
}
