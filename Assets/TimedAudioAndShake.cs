using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAudioAndShake : MonoBehaviour
{
    public AudioSource audioSource; // Assign this in the inspector
    public float interval = 10f; // Time in seconds between plays
    private float timer;

    void Start()
    {
        timer = interval; // Initialize the timer
    }

    void Update()
    {
        timer -= Time.deltaTime; // Update the timer every frame
        if (timer <= 0)
        {
            PlayAudioAndShake();
            timer = interval; // Reset the timer
        }
    }

    private void PlayAudioAndShake()
    {
        audioSource.Play(); // Play the audio
        // Add your camera shake function here
        // For example: CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeIn, fadeOut);
    }
}

