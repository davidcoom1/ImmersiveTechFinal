// Chat GPT Helped Write this Script
using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;       // Assign the camera Transform in the Inspector
    public float shakeDuration = 0.5f;      // Duration of the shake effect
    public float shakeMagnitude = 0.1f;     // Magnitude of the shake, keep it subtle in VR
    public float intervalBetweenShakes = 10f;  // Time between each shake

    private Vector3 originalPosition;
    private bool isShaking = false;

    void Start()
    {
        if (cameraTransform == null)
        {
            // If no camera transform is assigned, use the transform this script is attached to
            cameraTransform = transform;
        }
        originalPosition = cameraTransform.localPosition;
        StartCoroutine(PeriodicShake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            cameraTransform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cameraTransform.localPosition = originalPosition;
        isShaking = false;
    }

    IEnumerator PeriodicShake()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalBetweenShakes);
            if (!isShaking)
            {
                isShaking = true;
                StartCoroutine(Shake());
            }
        }
    }
}
