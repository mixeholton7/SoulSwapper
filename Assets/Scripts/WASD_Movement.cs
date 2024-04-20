using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float rotationSpeed = 2f;


    private float smoothTime = 0.05f;
    private float CurrentVelo;
    private Rigidbody rigidbody;
    private float gravityValue = -40f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Animator animator; 

    void Start() 
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }


    private void FixedUpdate()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        if(xDir != 0 || yDir != 0)
        {
            animator.SetBool("Moving", true); 
        }
        else
        {
            animator.SetBool("Moving", false); 
        }

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, xDir, 0) * Time.fixedDeltaTime * rotationSpeed);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);   

        rigidbody.AddForce(transform.forward * speed * yDir);

    }
}

