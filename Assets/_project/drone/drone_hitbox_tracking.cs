using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone_hitbox_tracking : MonoBehaviour
{
    public GameObject drone_hitbox;
    public GameObject target;
    public Rigidbody rb; 
    public float speed = 5;

    void GetTarget() {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        GetTarget();
    }

    void FixedUpdate()
    {
        Vector3 dir = (target.transform.position - drone_hitbox.transform.position).normalized;
        Vector3 desired_velocity = dir * speed;
        rb.velocity = desired_velocity;
        //rb.AddForce( * speed, ForceMode.VelocityChange);
    }
}
