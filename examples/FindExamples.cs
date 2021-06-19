// Various ways of finding things in Unity

using UnityEngine;
using System.Collections;

public class FindExamples : MonoBehaviour {
    
    // Example needs a Rigidbody2D component to work
    private Rigidbody2D rigidbody2D, otherrigidbody2D, childrigidbody2D;
    private GameObject hierarchyObject, childObject, taggedObject;

    void Start() {

        // Find a component attached to this GameObject
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Find a GameObject in the Hierarchy, will check all GameObjects in the Hierarchy
        hierarchyObject = GameObject.Find("Name Of Object");
        
        // Find a GameObject in the hierarchy based on tag
        taggedObject = GameObject.FindWithTag("Player");
        
        // Can be combined to find a component on a GameObject in the Hierarchy
        otherrigidbody2D = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

        // Lowercase transform.Find can be used to search child GameObjects by name
        childObject = transform.Find("Name Of Object").gameObject;

        // Can also be combined to find a component on a GameObject in the Hierarchy
        childrigidbody2D = transform.Find("Name Of Object").GetComponent<Rigidbody2D>();
    }
}