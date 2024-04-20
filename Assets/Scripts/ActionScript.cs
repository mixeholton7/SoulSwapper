using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("SPACEBAR");
        }

        if (Input.GetMouseButtonDown(0))
        {
            print("I click left mouse");
        }

        if ( Input.GetButtonDown("fire1joy"))
        {
            print("I press A");
        }

       

    }

}
