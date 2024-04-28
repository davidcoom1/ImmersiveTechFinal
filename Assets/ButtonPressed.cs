using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject doorToOpen; // Drag your door GameObject here in the inspector.
    public DoorController doorController; // Drag your DoorController script here.
    public Vector3 pressedPosition; // Local position when button is pressed.
    public float pressDuration = 0.25f; // How long it takes for the button to move to the pressed position.

    private Vector3 originalPosition; // To store the original position of the button.
    private bool isPressed = false;

    void Start()
    {
        originalPosition = transform.localPosition; // Store the original local position of the button.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRHand") && !isPressed) // Make sure your VR hand is tagged appropriately.
        {
            isPressed = true;
            StartCoroutine(MoveButton(pressedPosition, pressDuration, () => {
                doorController.OpenDoor();
            }));
        }
    }

    private IEnumerator MoveButton(Vector3 targetPosition, float duration, System.Action onComplete)
    {
        float time = 0;
        Vector3 startPosition = transform.localPosition;

        while (time < duration)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosition;
        onComplete?.Invoke();

        // Wait for the door to open and then reset the button
        yield return new WaitForSeconds(doorController.OpenDuration);
        StartCoroutine(MoveButton(originalPosition, pressDuration, null));
    }
}
