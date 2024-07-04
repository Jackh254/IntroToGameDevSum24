using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    // The game object that will be disabled when this object gets hit
    public GameObject balloonObject;
    // The time it takes a balloon to respawn after it has been destroyed
    public float respawnTime = 5;
    // The effect when popping
    public Transform poppingEffect;

    // Keeps track of whether the balloon is popped
    private bool popped = false;
    // The time passed since the last spawn/respawn
    private float respawnTimeCount = 0;

    [Header("Shaking")]
    public float shakeDuration = 0.1f;
    public float shakeIntensity = 1f;

    [Header("Animations")]
    public Animator animator;
    public string spawnParameterName = "spawn";

    [Header("Sounds")]
    public AudioSource source;
    public AudioClip popSound;
    public AudioClip respawnSound;

    private Collider balloonCollider;

    private void Awake()
    {
        // Get the collider component
        balloonCollider = GetComponent<Collider>();
    }

    // Every frame...
    private void Update()
    {
        // Call the function to check if the balloon needs to be respawned and do so if applicable
        BalloonRespawning();
    }

    // When any object enters this trigger (or when this object enters any trigger)
    public void OnTriggerEnter(Collider other)
    {
        // If the balloon is already popped, do nothing
        if (popped)
            return;

        // Destroy the other object
        Destroy(other.gameObject);

        // Pop the balloon
        PopBalloon();
    }

    private void BalloonRespawning()
    {
        // If the balloon is popped, we don't need to do anything 
        if (!popped)
            return;

        // If enough time has passed
        if (respawnTimeCount >= respawnTime)
        {
            // The balloon is enabled again
            balloonObject.SetActive(true);
            // Enable the collider
            balloonCollider.enabled = true;
            // The balloon is marked as not popped
            popped = false;
            // The time for respawn is reset
            respawnTimeCount = 0;

            // Play respawn animation and sound
            animator.SetTrigger(spawnParameterName);
            PlayRespawnSound();
        }
        // Otherwise
        else
        {
            // We add time to the time-keeping variable
            respawnTimeCount += Time.deltaTime;
        }
    }

    // This function is called to pop the balloon
    public void PopBalloon()
    {
        // Disable the balloon
        balloonObject.SetActive(false);
        // Disable the collider
        balloonCollider.enabled = false;
        // Mark this balloon as popped
        popped = true;

        // Instantiate pop effect
        Instantiate(poppingEffect, this.transform.position, Quaternion.identity);

        // Shake the camera
        CameraShake.instance.ShakeCamera(shakeDuration, shakeIntensity);

        // Play pop sound
        PlayPopSound();
    }

    private void PlayPopSound()
    {
        source.PlayOneShot(popSound);
    }

    private void PlayRespawnSound()
    {
        source.PlayOneShot(respawnSound);
    }
}
