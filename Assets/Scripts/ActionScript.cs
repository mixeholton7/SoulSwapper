using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    public GameObject fireballLoc;
    public GameObject fireball;
    public GameObject eaterSymbol;
    public GameObject shield;
    public AudioSource AudioSource;
    public AudioClip Fire;
    public AudioClip Eat;

    public int currentType;

    private bool CanIShield => currentType == 3;
    private bool CanIFireBall;
    public bool canIEat => currentType == 2;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        StartCoroutine(increaseCount());
    }

    // Update is called once per frame
    void Update()
    {
        if (CanIShield)
        {
            shield.SetActive(true); 
        }
        else
        {
            shield.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("SPACEBAR");
            checkType(currentType);
            // Fireball if currType == 1
            // Eater if currtype == 2
            // shield if currtype == 3
        }

        if (Input.GetMouseButtonDown(0))
        {
            print("I click left mouse");
            checkType(currentType);
        }

        if ( Input.GetButtonDown("fire1joy"))
        {
            print("I press A");
            checkType(currentType);
        }
    }

    void checkType(int type) { 
        if (type == 1) // FIREBALL
        { 
            if (CanIFireBall)
            {
                StartCoroutine(ShootFireball());
                Instantiate(fireball, fireballLoc.transform.position, Quaternion.identity);
            }
            
        }
        if (type == 2) // EAT
        {
            // look below noob :P
        }
        if (type == 3) // SHIELD
        {

        }
    }

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
            Destroy(other.gameObject);
        }
    }

    IEnumerator ShootFireball()
    {
        CanIFireBall = false;
        yield return new WaitForSeconds(1);
        CanIFireBall = true;
    }

    IEnumerator increaseCount()
    {
        yield return new WaitForSeconds(10);
        currentType++;
        if (currentType == 4)
        {
            currentType = 1;
        }
        StartCoroutine(increaseCount());
    }

}
