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