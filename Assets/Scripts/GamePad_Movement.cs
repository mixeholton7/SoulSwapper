using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad_Movement : MonoBehaviour
{
    public float speed = .1f;
    private float smoothTime = 0.05f;
    private float CurrentVelo;
    private CharacterController controller;
    private float gravityValue = -40f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Animator animator;


    void Start() 
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float xDir = Input.GetAxis("LeftJoystickX");
        float yDir = Input.GetAxis("LeftJoystickY");

        if(xDir != 0 || yDir != 0)
        {
            animator.SetBool("Moving", true); 
        }
        else
        {
            animator.SetBool("Moving", false); 
        }

        Vector3 move = new Vector3(xDir, 0, yDir);
        controller.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        var TargetAngle = Mathf.Atan2(xDir, yDir) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref CurrentVelo, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, TargetAngle, 0.0f);

        // Vector3 MoveDir = new Vector3(xDir, 0.0f, yDir);

        // transform.position += MoveDir * speed;
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
