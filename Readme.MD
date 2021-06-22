# Unity 3D C# Cheat Sheet

## Cheatsheet

### Unity 3D Scripting
![cheatsheet](https://github.com/codemaker2015/unity3d-cheat-sheet/blob/master/cheatsheets/unity-cheatsheet.jpg)
[Download](https://github.com/codemaker2015/unity3d-cheat-sheet/blob/master/cheatsheets/unity-cheatsheet.pdf)

![cheatsheet](https://github.com/codemaker2015/unity3d-cheat-sheet/blob/master/cheatsheets/unity-cheatsheet2.jpg)
[Download](https://github.com/codemaker2015/unity3d-cheat-sheet/blob/master/cheatsheets/unity-cheatsheet2.pdf)


### Unity 3D Keyboard Shortcuts
![cheatsheet](https://github.com/codemaker2015/unity3d-cheat-sheet/blob/master/cheatsheets/unity3d-keyboard-shortcuts.jpg)
[Download](https://github.com/codemaker2015/unity3d-cheat-sheet/blob/master/cheatsheets/unity3d-keyboard-shortcuts.pdf)

## Examples

### InputExamples.cs

```cs
// Various examples of Input usage in Unity
using UnityEngine;
using System.Collections;

public class InputExamples : MonoBehaviour {

    // These strings need to be set in the Inspector to match Input Manager entries
    public string horiAxis, vertAxis, jump;
    public KeyCode key1;
    public Vector2 speed = new Vector2(10f, 5f);

    void Update() {

        // Input.GetAxis will return a number between -1 and 1, with smoothing applied 
        // (adjust Sensitivity in Input Manager)
        Debug.Log("Horizontal: " + Input.GetAxis(horiAxis));

        // Input.GetAxisRaw will return a number between -1 and 1, without Sensitivity smoothing applied
        Debug.Log("Vertical: " + Input.GetAxisRaw(vertAxis));

        // This is often multiplied by a number to create movement
        Debug.Log("Horizontal Modified: " + Input.GetAxis(horiAxis) * speed.x);

        // Key pressed down
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("Key T pressed");
        }

        // KeyCode can also be set in the Inspector as a variable
        if (Input.GetKeyUp(key1)) {
            Debug.Log("Key Released");
        }

        // Run only once when button is pressed
        if (Input.GetButtonDown(jump)) {
            Debug.Log("Jump");
        }
    }
}
```

### InstantiateExamples.cs

```cs
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

            // Pass the prefab as an argument and clone it at the spawnPoint 
            // spawnPoint can be set to transform for cloning the prefab at the position of this object
            Instantiate(prefab, spawnPoint);
            //Instantiate(prefab, transform);
        }

        // Advanced cloning
        if (Input.GetButtonDown("Fire")) {

            // Overloaded method which can be positioned and rotated
            GameObject prefab1 = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;

            // Make this prefab a child of the gameObject that spawned it
            prefab1.transform.parent = transform;

            // Destroying the prefab after a set amount of time
            Destroy(prefab1, 3f);

            // Accessing the cloned prefab's components. Note: The prefab needs a Rigidbody component for the next 2 lines to work
            Rigidbody prefabrigidbody = prefab1.GetComponent<Rigidbody>();
            prefabrigidbody.AddForce(Vector2.up * 100f);
        }
    }
}
```

### FindExamples.cs

```cs
// Various ways of finding things in Unity

using UnityEngine;
using System.Collections;

public class FindExamples : MonoBehaviour {

    // Example needs a Rigidbody component to work
    private Rigidbody rigidbody, otherrigidbody, childrigidbody;
    private GameObject hierarchyObject, childObject, taggedObject;

    void Start() {

        // Find a component attached to this GameObject
        rigidbody = GetComponent<Rigidbody>();

        // Find a GameObject in the Hierarchy, will check all GameObjects in the Hierarchy
        hierarchyObject = GameObject.Find("Name Of Object");
        
        // Find a GameObject in the hierarchy based on tag
        taggedObject = GameObject.FindWithTag("Player");
        
        // Can be combined to find a component on a GameObject in the Hierarchy
        otherrigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();

        // Lowercase transform.Find can be used to search child GameObjects by name
        childObject = transform.Find("Name Of Object").gameObject;

        // Can also be combined to find a component on a GameObject in the Hierarchy
        childrigidbody = transform.Find("Name Of Object").GetComponent<Rigidbody>();
    }
}
```

### EnableSetActiveExamples.cs

```cs
// Various ways of enabling/disabling a gameObject's components and activating/deactivating a gameObject
using UnityEngine;
using System.Collections;

public class EnableSetActiveExamples : MonoBehaviour {
    
    public GameObject targetGameObject;
    private Collider collider;

    void Start() {

        // SetActive can switch a gameObject on or off in the Hierarchy. Once deactivated, its components will no longer run until reactivated.
        targetGameObject.SetActive(false);

        // Get a collider component attached to this gameObject. Note: Collider will work with any kind of  collider component.
        collider = GetComponent<Collider>();

        // Disable or enable a component using a bool
        collider.enabled = false;
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
            if (!collider.enabled) {
                collider.enabled = true;
            }
        }
    }
}
```

### CollisionExamples.cs

```cs
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
```

### AudioExamples.cs

```cs
// Various audio examples for Unity
using UnityEngine;
using System.Collections;

public class AudioExamples : MonoBehaviour {

    // Attach an AudioSource component to this gameObject
    private AudioSource audioSource;

    // Set an audioclip in the Inspector
    public AudioClip clip1;

    void Start() {

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        // Plays the AudioClip set in the AudioSource component
        audioSource.Play();
    }

    void Update() {

        // AudioSource.Play() can also be paused or stopped
        // Check if audioSource is playing a clip
        if (audioSource.isPlaying) {
            if (Input.GetButtonDown("P"))
                audioSource.Pause();
            else if (Input.GetButtonDown("S"))
                audioSource.Stop();

            // Set the pitch and volume of the clips played by Audio Source. Volume range is 0~1
            audioSource.pitch = Random.Range(0.25f, 2f);
            audioSource.volume = Random.Range(0.25f, 1f);
        }

        // PlayOneShot can be used to play a short clip
        // Can't be used with Pause & Stop
        if (Input.GetButtonDown("Play")) {
            audioSource.PlayOneShot(clip1);

            // You can give this an optional volume setting as well (0-1 range)
            //audioSource.PlayOneShot(clip1, 0.5f);
        }
    }
}
```

### IEnumeratorExamples.cs

```cs
// Various IEnumerator timer examples for Unity
using UnityEngine;
using System.Collections;

public class IEnumeratorExamples : MonoBehaviour {
    // Flag for checking if a coroutine is running
    private bool alreadyDelayed;

    // Necessary to stop a coroutine
    private IEnumerator coroutine;

    void Start() {
        // Coroutines run in Start are only called once. No if statement + bool needed.
        StartCoroutine(LoopingTimer(7f));

        // Set to an IEnumerator
        coroutine = LoopingTimer(1f);
        StartCoroutine(coroutine);
    }

    void Update() {

        // DelayTimerOneShot
        if (Input.GetButtonDown("PlayOneShot"))
            StartCoroutine(DelayTimerOneShot(1f));

        // Space bar is Jump in Input Manager
        if (Input.GetButtonDown("Jump"))
            // This if statement ensures that a coroutine can't be run again if it is already running.
            if (!alreadyDelayed)
                StartCoroutine(DelayTimerLatching(3f));

        if (Input.GetButtonDown("Fire")) {
            // To stop a coroutine
            StopCoroutine(coroutine);
            Debug.Log("Stopped at " + Time.time);
        }
    }

    // Wait for an amount of time before doing something
    private IEnumerator DelayTimerOneShot(float delayLength) {
        yield return new WaitForSeconds(delayLength);
        Debug.Log("Delayed One Shot");
    }

    // Wait for an amount of time before doing something
    private IEnumerator DelayTimerLatching(float delayLength) {

        // Set the already delayed flag to signal that this coroutine is already running
        alreadyDelayed = true;
        Debug.Log("Delayed Latch");
        yield return new WaitForSeconds(delayLength);
        Debug.Log("Delayed Latch Released");
        // Reset the already delayed flag so that this coroutine can be used once again.
        alreadyDelayed = false;
    }
}
```

### SceneManagementExamples.cs

```cs
// Various examples of scene management
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagementExamples : MonoBehaviour {

    // Name of new scene. Should be add the scene in build settings.
    public string scene;

    // Load the new scene
    public void LoadScene(string newScene) {
        SceneManager.LoadScene(newScene);
    }

    // Reload the current scene
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
```

### UIExamples.cs

```cs
// Various UI examples
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIExamples : MonoBehaviour {

    // Set the target UI Text in the Inspector
    public Text uiText;
    // Set the target UI image in Inspector. UI Image must be "filled" type
    public Image uiImage;
    private int uiNumber = 5;

    void Update() {

        if (Input.GetButtonDown("Jump")) {
            // Basic usage
            uiText.text = "CODEMAKER";
            // Fill amount is in a range from 0-1. Empty
            uiImage.fillAmount = 0;
        } else if (Input.GetButtonDown("Fire1")) {
            // Numbers must be converted to strings
            uiText.text = uiNumber.ToString();
            
            // Larger ranges of number can be converted by dividing with the max value
            uiImage.fillAmount = 2.5f/uiNumber;
        } else if (Input.GetButtonDown("Fire2")) {
            // Numbers can be formatted to display a certain number of places
            uiText.text = uiNumber.ToString("000");
            // Full
            uiImage.fillAmount = 1;
        }
    }
}
```