using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private float startFOV = 20; 
    private float endFOV = 40; 
    private Camera camera; 
    private bool moveCamera = false; 

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        camera = Camera.main; 
    }

    // Move to the target end position.
    void Update()
    {
        if(moveCamera)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
            transform.rotation = Quaternion.Lerp(startMarker.rotation, endMarker.rotation, fractionOfJourney);
            camera.fieldOfView = Mathf.Lerp(startFOV, endFOV, fractionOfJourney);
        }
    }

    public void MoveCamera() 
    {
        moveCamera = true; 
        startTime = Time.time;
    }
}
