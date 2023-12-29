using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone_follow : MonoBehaviour
{
    public GameObject drone;
    public GameObject drone_hitbox;
    public Rigidbody rb; 


    public Vector3 offset = new Vector3(0, 2, 0);
    public float speed = 5;
    public float accel_multiplier = 10;

    void FixedUpdate()
    {
        Vector3 target_offset = drone_hitbox.transform.position + offset - drone.transform.position;
        float distance = target_offset.magnitude;
        Vector3 direction = target_offset.normalized;

        if (distance > 3) {
            Vector3 desired_velocity = direction * speed;
            
            //rb.velocity = desired_velocity;
            rb.AddForce(desired_velocity * accel_multiplier * Time.fixedDeltaTime);

            Quaternion desired_rotation =  Quaternion.LookRotation(direction);
            Quaternion next_rotation = Quaternion.Lerp(drone.transform.rotation, desired_rotation, 0.1f);
            drone.transform.rotation = next_rotation;
        } 
    }
}
