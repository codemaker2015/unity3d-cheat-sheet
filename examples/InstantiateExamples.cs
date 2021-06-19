// Various Instantiate examples for Unity
using UnityEngine;
using System.Collections;

public class InstantiateExamples : MonoBehaviour {

    // Set the object to be cloned in the Inspector.
    public GameObject prefab;

    // Set a target transform in the Inspector to clone prefab from
    public Transform spawnPoint;

    // Update is called once per frame
    void Update() {
        
        // Basic cloning
        if (Input.GetButton("X")) {

            // Pass the prefab as an argument and clone it at the spawnPoint. 
            // spawnPoint can be set to transform for cloning the prefab at the position of this object.
            Instantiate(prefab, spawnPoint);
            //Instantiate(prefab, transform);
        }

        // Advanced cloning
        if (Input.GetButtonDown("Fire")) {

            // Overloaded method which can be positioned and rotated. 
            GameObject prefab1 = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;

            // Make this prefab a child of the gameObject that spawned it
            prefab1.transform.parent = transform;

            // Destroying the prefab after a set amount of time
            Destroy(prefab1, 3f);

            // Accessing the cloned prefab's components. Note: The prefab needs a Rigidbody2D component for the next 2 lines to work.
            Rigidbody2D prefabRB2D = prefab1.GetComponent<Rigidbody2D>();
            prefabRB2D.AddForce(Vector2.up * 100f);
        }
    }
}