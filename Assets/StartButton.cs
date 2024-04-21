using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject button; 

    public CameraMovement cameraMovement;
    public StartMenu startMenu; 
    public Cursor_Movement cursorMovement; 
    public WASD_Movement wasdMovement;
    public GamePad_Movement gamePadMovement;

    public GameObject startText1; 
    public GameObject startText2; 
    public GameObject startText3; 
    public GameObject startText4; 


    void Start()
    {
        StartGame(); 
    }


    public void StartGame() 
    {
        StartCoroutine("ShowText"); 

        cameraMovement.MoveCamera(); 
        cursorMovement.CanMoveCurse(); 
        wasdMovement.CanMoveWASD(); 
        gamePadMovement.CanMovePad(); 

        Destroy(button); 
        Destroy(startMenu); 
    }

    public IEnumerator ShowText()
    {
        yield return new WaitForSeconds(0.5f);

        startText1.SetActive(true);

        yield return new WaitForSeconds(1);

        startText1.SetActive(false);
        startText2.SetActive(true);

        yield return new WaitForSeconds(1);

        startText2.SetActive(false);
        startText3.SetActive(true);

        yield return new WaitForSeconds(1);

        startText3.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        startText4.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        startText4.SetActive(false);
    }
}
