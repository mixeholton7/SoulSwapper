using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad_Movement : MonoBehaviour
{
    private float speed = .1f;
    private float smoothTime = 0.05f;
    private float CurrentVelo;
    void Update()
    {
        float xDir = Input.GetAxis("LeftJoystickX");
        float yDir = Input.GetAxis("LeftJoystickY");

        var TargetAngle = Mathf.Atan2(xDir, yDir) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref CurrentVelo, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, TargetAngle, 0.0f);

        Vector3 MoveDir = new Vector3(xDir, 0.0f, yDir);

        transform.position += MoveDir * speed;


    }
}
