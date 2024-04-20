using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScience : MonoBehaviour
{
<<<<<<< HEAD
    public bool canIEat = true;
 
=======
    private AudioSource audioSource;
    public AudioClip audioClip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
>>>>>>> 47f11a50fb213fdbb4b8c20cf733e1385547a768
    private void OnTriggerEnter(Collider other)
    {
        var playerType = 0;

        if (other.tag == "Point" || canIEat)
        {
            if (this.gameObject.tag == "Player1")
            {
                playerType = 1;
            }
            if (this.gameObject.tag == "Player2")
            {
                playerType = 2;
            }
            if (this.gameObject.tag == "Player3")
            {
                playerType = 3;
            }

            scoreManeger.Instance.AddPoint(playerType);
            audioSource.Play();
            Destroy(other.gameObject);
        }
    }
}
