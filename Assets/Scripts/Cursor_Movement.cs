using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cursor_Movement : MonoBehaviour
{
    public Camera Camera;
    public RaycastHit RaycastHit;
    private NavMeshAgent agent;

    private string GroundTag = "Ground";
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
