using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartButton : MonoBehaviour
{
    public GameObject button; 

    public CameraMovement cameraMovement;
    public StartMenu startMenu; 
    public Cursor_Movement cursorMovement; 
    public WASD_Movement wasdMovement;
    public GamePad_Movement gamePadMovement;

    public TMP_Text startText1; 
    public TMP_Text startText2; 
    public TMP_Text startText3; 


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
        Debug.Log("hello"); 
        
        startText1.text = "HEj"; 

        yield return new WaitForSeconds(2);

        Debug.Log("yo"); 

        startText1.text = ""; 
    }
}
