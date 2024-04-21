using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    public List<Transform> Targets;
    public Vector3 Offset;
    private Vector3 Velo;
    public float smoothTime = .5f;
    public float minZoom = 60f;
    public float maxZoom = 20f;
    public float ZoomLimit = 100f;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private float startFOV = 30; 
    private float endFOV = 40; 
    private Camera camera; 
    private bool moveCamera = false; 
    private bool moveCameraToTargets = false; 

    void Start()
    {

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        camera = Camera.main; 
    }
    private Vector3 GetCenterPoint()
    {
        if (Targets.Count == 1)
        {
            return Targets[0].position;
        }
        var bounds = new Bounds(Targets[0].position, Vector3.zero);

        for (int i = 0; i < Targets.Count; i++)
        {
            bounds.Encapsulate(Targets[i].position);
        }

        return bounds.center;
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

            if(transform.position == endMarker.position)
            {
                moveCameraToTargets = true;
                moveCamera = false;
            }
           
        }

        
        
    }
    private void LateUpdate()
    {
        if (moveCameraToTargets)
        {
            if (Targets.Count == 0)
            {
                return;
            }
            MoveOnPlay();
            ZoomOnPlay();
        }
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatesteDist() / ZoomLimit);
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, newZoom, Time.deltaTime);
    }

    private float GetGreatesteDist()
    {
        var bounds = new Bounds(Targets[0].position, Vector3.zero);
        for (int i = 0; i < Targets.Count; i++)
        {
            bounds.Encapsulate(Targets[i].position);
        }

        return bounds.size.x;

    }

    private void MoveOnPlay()
    {
        Vector3 center = GetCenterPoint();
        Vector3 newPos = new Vector3(center.x, transform.position.y, center.z + -100f);

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref Velo, smoothTime);
    }
    private void ZoomOnPlay()
    {
        Vector3 center = GetCenterPoint();
        var max = center.y <= transform.position.y ? center.y + 100 : transform.position.y;
        Vector3 newPos = new Vector3(transform.position.x, center.y + 80 + GetGreatesteDist(), transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref Velo, smoothTime);
    }


    public void MoveCamera() 
    {
        moveCamera = true; 
        startTime = Time.time;
    }
}
