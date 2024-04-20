using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Camera Camera;
    public LayerMask layerMask;
    public GameObject Player1UI; 
    public GameObject Player2UI; 
    public GameObject Player3UI; 


    private Animator animator; 

    void FixedUpdate()
    { 
        RaycastHit hit;

        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("Player1"))
            {
                animator = hit.collider.gameObject.GetComponentInChildren<Animator>();
                animator.SetBool("Moving", true);  

                Player1UI.SetActive(true);
            }
            else if (hit.collider.CompareTag("Player2"))
            {
                animator = hit.collider.gameObject.GetComponentInChildren<Animator>();
                animator.SetBool("Moving", true);  

                Player2UI.SetActive(true);
            }
            else if (hit.collider.CompareTag("Player3"))
            {
                animator = hit.collider.gameObject.GetComponentInChildren<Animator>();
                animator.SetBool("Moving", true);  

                Player3UI.SetActive(true);
            }
        }
        else 
        {
            Player1UI.SetActive(false);
            Player2UI.SetActive(false);
            Player3UI.SetActive(false);

            if(animator)
            {
                animator.SetBool("Moving", false); 
            }
        }
    }
}
