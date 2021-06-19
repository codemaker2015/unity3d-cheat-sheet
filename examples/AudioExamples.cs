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