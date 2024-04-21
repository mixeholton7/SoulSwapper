using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public List<Transform> Targets;

    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(Targets.Count == 0)
        {
            return;
        }
        Vector3 center = GetCenterPoint();

        Vector3 newPos = center + Offset;

        transform.position = center;
    }

    private Vector3 GetCenterPoint()
    {
        if(Targets.Count == 1)
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
}
