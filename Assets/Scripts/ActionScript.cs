using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    public Cursor_Movement cursorMovement;
    public WASD_Movement wasdMovement;
    public GamePad_Movement gamePadMovement;

    public GameObject fireballLoc;
    public GameObject fireball;
    public GameObject eaterSymbol;
    public GameObject shield;
    public MeshRenderer myMeshRend;
    public AudioSource AudioSource;
    public AudioClip Fire;
    public AudioClip Eat;

    public GameObject wizard; 
    public GameObject chicken; 
    public GameObject fire_wizard; 
    public GameObject shield_wizard; 

    public int currentType;

    private bool CanIShield => currentType == 3;
    private bool CanIFireBall => currentType == 1;
    private bool ihaveShootBall = false;
    public bool canIEat => currentType == 2;
    private bool amIdead = false;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        StartCoroutine(increaseCount());
    }

    // Update is called once per frame
    void Update()
    {
        if (!amIdead)
        {
            if (CanIShield)
            {
                shield.SetActive(true);

                chicken.SetActive(false);
                wizard.SetActive(false); 
                fire_wizard.SetActive(false); 

                shield_wizard.SetActive(true);
                myMeshRend = shield_wizard.GetComponent<MeshRenderer>();
            }
            else
            {
                shield.SetActive(false);

                chicken.SetActive(false);
                fire_wizard.SetActive(false);
                shield_wizard.SetActive(false);

                wizard.SetActive(true);
                myMeshRend = wizard.GetComponent<MeshRenderer>();
            }

            if (canIEat)
            {
                eaterSymbol.SetActive(true); 
                
                wizard.SetActive(false); 
                fire_wizard.SetActive(false);
                shield_wizard.SetActive(false);

                chicken.SetActive(true);
                myMeshRend = chicken.GetComponent<MeshRenderer>();
            }
            else
            {
                eaterSymbol.SetActive(false);

                chicken.SetActive(false);
                fire_wizard.SetActive(false);
                shield_wizard.SetActive(false);
                
                wizard.SetActive(true);
                myMeshRend = wizard.GetComponent<MeshRenderer>();
            }

            if (CanIFireBall)
            {
                chicken.SetActive(false);
                wizard.SetActive(false);
                shield_wizard.SetActive(false);

                fire_wizard.SetActive(true); 
                myMeshRend = fire_wizard.GetComponent<MeshRenderer>();
            }
            else
            {
                chicken.SetActive(false);
                fire_wizard.SetActive(false); 
                shield_wizard.SetActive(false);

                wizard.SetActive(true);
                myMeshRend = wizard.GetComponent<MeshRenderer>();
            }

            if (Input.GetKeyDown(KeyCode.Space) && currentType == 1 && this.gameObject.tag == "Player1")
            {
                print("SPACEBAR");
                print(currentType);
                checkType(currentType);
                // Fireball if currType == 1
                // Eater if currtype == 2
                // shield if currtype == 3
            }

            if (Input.GetMouseButtonDown(0) && currentType == 1 && this.gameObject.tag == "Player3")
            {
                print("I click left mouse");
                checkType(currentType);
            }

            if (Input.GetButton("fire1joy") && currentType == 1 && this.gameObject.tag == "Player2")
            {
                print("I press A");
                checkType(currentType);
            }
        }
    }

    void checkType(int type) { 
        if (currentType == type) // FIREBALL
        { 
            if (!ihaveShootBall)
            {
                StartCoroutine(ShootFireball());
                var fireballCopy = fireball;
                Instantiate(fireballCopy, fireballLoc.transform.position, fireballLoc.transform.rotation);
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

        if (other.tag == "Point" && currentType == 2)
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

        print("There is a collision: " + currentType );
        print("With " + other.tag);

        if (other.tag == "Fireball")
        {
            int whatPlayerAmI = 0;
            if (this.gameObject.tag == "Player1")
            {
                whatPlayerAmI = 1;
                print("Player 1 is hit");
                wasdMovement.CantMoveWASD();
                amIdead = true;
                StartCoroutine(Death(whatPlayerAmI));
                
            }
            if (this.gameObject.tag == "Player2")
            {
                whatPlayerAmI = 2;
                print("Player 2 is hit");
                gamePadMovement.CantMovePad();
                amIdead = true;
                StartCoroutine(Death(whatPlayerAmI));
                
            }
            if (this.gameObject.tag == "Player3")
            {
                whatPlayerAmI = 3;
                print("Player 3 is hit");
                cursorMovement.CantMoveCurse();
                amIdead= true;
                StartCoroutine(Death(whatPlayerAmI));
                
                
            }
            Destroy(other.gameObject);
            //gameObject.SetActive(false);
            /*
            switch (whatPlayerAmI)
            {
                case 1:
                    print("stop player 1 moveing");
                    
                    break;
                case 2:
                    print("stop player 2 moveing");
                    wasdMovement.CantMoveWASD();
                    StartCoroutine(Death(whatPlayerAmI));
                    break;
                case 3:
                    print("stop player 3 moveing");
                    gamePadMovement.CantMovePad();
                    StartCoroutine(Death(whatPlayerAmI));
                    break;
                default:
                    print("this is not supposed to happen");
                    break;
            }
            */
            //scoreManeger.Instance.AddPoint(playerType);
            //Destroy(other.gameObject);
        }
    }

    IEnumerator ShootFireball()
    {
        ihaveShootBall = true;
        yield return new WaitForSeconds(1);
        ihaveShootBall = false;
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

    /*
      if (this.gameObject.tag == "Player1")
            {
                print("Player 1 is hit");
                wasdMovement.CantMoveWASD();
                StartCoroutine(Death(whatPlayerAmI));
                whatPlayerAmI = 1;
            }
            if (this.gameObject.tag == "Player2")
            {
                print("Player 2 is hit");
                gamePadMovement.CantMovePad();
                StartCoroutine(Death(whatPlayerAmI));
                whatPlayerAmI = 2;
            }
            if (this.gameObject.tag == "Player3")
            {
                print("Player 3 is hit");
                cursorMovement.CantMoveCurse();
                StartCoroutine(Death(whatPlayerAmI));
                
                whatPlayerAmI = 3;
            }
     */
    IEnumerator Death(int thePlayer)
    {
        print("STOPPED MOVEING");
        myMeshRend.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myMeshRend.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myMeshRend.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myMeshRend.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myMeshRend.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myMeshRend.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myMeshRend.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myMeshRend.enabled = true;
        switch (thePlayer)
        {
            case 1:
                print("start player 1 moveing");
                wasdMovement.CanMoveWASD();
                break;
            case 2:
                print("start player 2 moveing");
                gamePadMovement.CanMovePad();
                break;
            case 3:
                print("start player 3 moveing");
                cursorMovement.CanMoveCurse();
                break;
            default:
                print("this is not supposed to happen");
                break;
        }
        amIdead = false;
    }

}
