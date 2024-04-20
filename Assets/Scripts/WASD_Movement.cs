using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = .5f;
    private void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 MoveDir = new Vector3(xDir, 0.0f, yDir);

        transform.position += MoveDir * speed;

    }
}

