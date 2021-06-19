// Various ways of enabling/disabling a gameObject's components and activating/deactivating a gameObject
using UnityEngine;
using System.Collections;

public class EnableSetActiveExamples : MonoBehaviour {
    
    public GameObject targetGameObject;
    private Collider2D collider2D;

    void Start() {

        // SetActive can switch a gameObject on or off in the Hierarchy. Once deactivated, its components will no longer run until reactivated.
        targetGameObject.SetActive(false);

        // Get a collider2D component attached to this gameObject. Note: Collider2D will work with any kind of 2D collider component.
        collider2D = GetComponent<Collider2D>();

        // Disable or enable a component using a bool
        collider2D.enabled = false;
    }

    // Update is called once per frame
    void Update() {

        // Jump is space in Input Manager
        if (Input.GetButtonDown("Jump")) {

            // Check if a gameObject is active in the scene with activeInHierarchy
            if (!targetGameObject.activeInHierarchy) {
                targetGameObject.SetActive(true);
            }
        }

        // Fire is left ctrl in Input Manager
        if (Input.GetButtonDown("Fire")) {

            // Check if a component is enabled
            if (!collider2D.enabled) {
                collider2D.enabled = true;
            }
        }
    }
}