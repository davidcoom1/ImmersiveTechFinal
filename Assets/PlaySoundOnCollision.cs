using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Play the clank sound whenever this object collides with another
        if (!audioSource.isPlaying) // Optional: Prevent the sound from overlapping
        {
            audioSource.Play();
        }
    }
}

