using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGo : MonoBehaviour
{

    public float fireballSpeed;
    public int BounceTimes;
    private int bounce;
    // Start is called before the first frame update
    void Start() { 
    
        if (fireballSpeed <= 0f) {
            fireballSpeed = 10f;
        }

        var bounce = 0;

        if (BounceTimes <= 0)
        {
            BounceTimes = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * fireballSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        bounce++;

        if (other.tag == "shield")
        {
            Destroy(gameObject);
        }
        else
        {
            fireballSpeed = -fireballSpeed;
            if (bounce == BounceTimes)
            {
                Destroy(gameObject);
            }
        }
    }

}
