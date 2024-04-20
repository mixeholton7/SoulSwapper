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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InstantlyTurn(agent.destination);

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit, Mathf.Infinity))
            {
                if (RaycastHit.collider.CompareTag(GroundTag))
                {
                    agent.SetDestination(RaycastHit.point);
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
}
