using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("audio manager is NULL!");
            }
            return _instance;
        }
    }

    public AudioSource voiceOver;


    private void Awake()
    {
        _instance = this;
    }

    public void PlaySound(AudioClip voiceOverClip)
    {
        voiceOver.clip = voiceOverClip;
        voiceOver.Play();
    }
}
