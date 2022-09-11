using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;

    private float maxJoystickAngle = 0.8f;

    [SerializeField]
    private GameObject GameCanvas;

    private LineRenderer line;

    RaycastHit hit;

    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward);
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    private void Rotate()
    {
        if (joystick.Horizontal > -maxJoystickAngle && joystick.Horizontal < maxJoystickAngle && joystick.Vertical > 0)
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + joystick.Horizontal * 90, transform.rotation.z);
        else if (joystick.Horizontal > maxJoystickAngle && joystick.Vertical != 0)
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + maxJoystickAngle * 90, transform.rotation.z);
        else if (joystick.Horizontal < -maxJoystickAngle && joystick.Vertical != 0)
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - maxJoystickAngle * 90, transform.rotation.z);
    }

    void Update()
    {
        if (GameCanvas.activeSelf && PlayerPrefs.GetString("IsInGame") == "Yes")
        {

            Rotate();
            Ray ray = new Ray(transform.position, transform.forward);
            Physics.Raycast(ray, out hit);
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red, 0.02f);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);
            Debug.DrawRay(hit.point, Vector3.Reflect(ray.direction, hit.normal) * 5f, Color.red, 0.02f);
        }
    }
}
