using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cursor_Movement : MonoBehaviour
{
    public Camera Camera;
    public RaycastHit RaycastHit;
    private NavMeshAgent agent;
    private const float rotSpeed= 20f;
    private string GroundTag = "Ground";
    private Vector3 targetPos; 
    private Animator animator; 

    private bool canMove = false; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(!canMove) 
        {
            return; 
        }

        if(Vector3.Distance(transform.position, targetPos) > 1f && canMove)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false); 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!canMove) 
        { 
            return; 
        }

        InstantlyTurn(agent.destination);

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit, Mathf.Infinity))
            {
                if (RaycastHit.collider.CompareTag(GroundTag))
                {
                    targetPos = RaycastHit.point;
                    agent.SetDestination(targetPos);
                }
            }
        }
    }

    private void InstantlyTurn(Vector3 destination) {
        //When on target -> dont rotate!
        if ((destination - transform.position).magnitude < 0.1f) return; 
        
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion  qDir= Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * rotSpeed);
    }

    public void CanMove() 
    {
        canMove = true; 
    }
}
