// Various  collision examples
using UnityEngine;
using System.Collections;

public class CollisionExamples : MonoBehaviour {

    // Collisions/Triggers require a collider on both gameObjects and a rigidbody on at least one.
    void OnCollisionEnter(Collision other) {

        // Do something when another collider touches this gameObject's collider
        Debug.Log("Collided with something");

        // Conditional statements can be used to filter collisions/triggers
        // Checking for a known tag is one option
        if (other.gameObject.CompareTag("tag1")) {
            Debug.Log("tag1 collision");
        }

        // Checking for a known name is one option
        else if (other.gameObject.name.Equals("name1")) {
            Debug.Log("name1 collision");
        }
    }

    // Is Trigger needs to be selected on one of the colliders
    void OnTriggerEnter(Collider other) {
        // Do something if another collider overlaps this gameObject's collider
        Debug.Log("Triggered by something");
    }

    // Collision and Trigger also have stay event
    void OnTriggerStay(Collider other) {
        // Do something while a collider is still overlapping with this gameObject's collider
        Debug.Log("Still triggering");
    }

    // Collision and Trigger also have exit event
    void OnCollisionExit(Collision other) {
        // Do something after a collider is no longer touching this gameObject's collider
        Debug.Log("Collision ended");
    }
}