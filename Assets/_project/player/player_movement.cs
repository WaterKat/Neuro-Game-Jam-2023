using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    public Transform player_camera_container;
    public Rigidbody rb;
    public float speed = 5f;

    public float move_x_input = 0;
    public float move_y_input = 0;


    public void set_move_x(InputAction.CallbackContext context)
    {
        move_x_input = context.ReadValue<float>();
    }
    public void set_move_y(InputAction.CallbackContext context)
    {
        move_y_input = context.ReadValue<float>();
    }

    public void Update() {
        Quaternion yRotation = Quaternion.Euler(0, player_camera_container.rotation.eulerAngles.y, 0);
        Vector3 rotatedMovement = yRotation * new Vector3(move_x_input, 0, move_y_input) * speed;
        rotatedMovement.y = rb.velocity.y;
        rb.velocity = rotatedMovement;
    }


    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "move_x_input: " + move_x_input);
        GUI.Label(new Rect(10, 30, 200, 20), "move_y_input: " + move_y_input);

        Quaternion yRotation = Quaternion.Euler(0, player_camera_container.rotation.eulerAngles.y, 0);
        Vector3 rotatedMovement = yRotation * new Vector3(move_x_input, 0, move_y_input).normalized * speed;

        GUI.Label(new Rect(10, 50, 200, 20), "x_modified: " + rotatedMovement.x);
        GUI.Label(new Rect(10, 70, 200, 20), "y_modified: " + rotatedMovement.y);
    }
}
