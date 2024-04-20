using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGo : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip audioClip;
    public float fireballSpeed;
    public int BounceTimes;
    private int bounce;
    // Start is called before the first frame update
    void Start() {

        m_AudioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter(Collision collision)
    {
        bounce++;
        if(collision.gameObject.tag == "Shield")
        {
            m_AudioSource.Play();
        }
        if (collision == null)
        {
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
