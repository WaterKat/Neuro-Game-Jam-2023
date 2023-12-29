using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_camera_movement : MonoBehaviour
{
    public Transform player_camera_container;
    public float sensitivity = 10f;

    float mouse_x_input = 0;
    float mouse_y_input = 0;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void set_mouse_x(InputAction.CallbackContext context)
    {
        mouse_x_input += context.ReadValue<float>() * sensitivity * .1f;
    }

    public void set_mouse_y(InputAction.CallbackContext context)
    {
        mouse_y_input += context.ReadValue<float>() * sensitivity * .1f;
        mouse_y_input = Mathf.Clamp(mouse_y_input, -85f, 90f);
    }

    void Update()
    {
        player_camera_container.transform.rotation =
            Quaternion.Euler(
                player_camera_container.transform.rotation.x - mouse_y_input,
                player_camera_container.transform.rotation.y + mouse_x_input,
                player_camera_container.transform.rotation.z
            );
    }
}
