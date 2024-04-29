using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketTrigger : MonoBehaviour
{
    public DoorController doorController; // Assign in the Inspector
    public int requiredRods = 5; // Number of rods required to open the door
    private int rodsInBucket = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UraniumRod"))
        {
            // Freeze the rod in place
            Rigidbody rodRigidbody = other.GetComponent<Rigidbody>();
            if (rodRigidbody != null)
            {
                rodRigidbody.isKinematic = true;
                rodRigidbody.velocity = Vector3.zero;
                rodRigidbody.angularVelocity = Vector3.zero;
            }

            rodsInBucket++;
            if (rodsInBucket >= requiredRods)
            {
                doorController.OpenDoor(); // Open the door if enough rods are in the bucket
            }
        }
    }
}
