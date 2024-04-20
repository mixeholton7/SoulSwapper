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


    public void StartGame() 
    {
        StartCoroutine("ShowText"); 

        cameraMovement.MoveCamera(); 
        cursorMovement.CanMove(); 
        wasdMovement.CanMove(); 
        gamePadMovement.CanMove(); 

        Destroy(button); 
        Destroy(startMenu); 
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(1);

        startText1.SetActive(true); 

        yield return new WaitForSeconds(1);

        startText1.SetActive(false); 
        startText2.SetActive(true); 

        yield return new WaitForSeconds(1);

        startText2.SetActive(false); 
        startText3.SetActive(true); 

        yield return new WaitForSeconds(1);

        startText3.SetActive(false); 

        Destroy(gameObject); 
    }
}
