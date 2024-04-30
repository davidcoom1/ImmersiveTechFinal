using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasPlayed = false; // Flag to check if the sound has already been played

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the tag "VRHand" and if the sound has not been played yet
        if (other.CompareTag("VRHand") && !hasPlayed)
        {
            audioSource.Play();
            hasPlayed = true; // Set the flag to true to prevent further playback
        }
    }

    // Method to allow resetting the sound playback from other scripts or game events
    public void ResetPlayback()
    {
        hasPlayed = false;
    }
}
