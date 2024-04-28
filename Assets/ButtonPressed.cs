using System.Collections;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject doorToOpen; // Drag your door GameObject here in the inspector.
    public DoorController doorController; // Drag your DoorController script here.
    public Vector3 pressedPosition; // Local position when button is pressed.
    public float pressDuration = 0.25f; // How long it takes for the button to move to the pressed position.
    public Transform leftHandTransform; // Assign the left VR hand transform in the inspector.
    public Transform rightHandTransform; // Assign the right VR hand transform in the inspector.
    public float activationDistance = 0.1f; // Activation distance from the button.

    private Vector3 originalPosition; // To store the original position of the button.
    private bool isPressed = false;

    void Start()
    {
        originalPosition = transform.localPosition; // Store the original local position of the button.
    }

    void Update()
    {
        // Check distance from both hands to the button.
        if (!isPressed && (Vector3.Distance(leftHandTransform.position, transform.position) < activationDistance ||
                           Vector3.Distance(rightHandTransform.position, transform.position) < activationDistance))
        {
            OnTriggerEnter(null); // Simulate an OnTriggerEnter call.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other?.CompareTag("VRHand") == true || other == null) && !isPressed) // Trigger on proximity or actual collision
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
        isPressed = false; // Reset the pressed state
    }
}
