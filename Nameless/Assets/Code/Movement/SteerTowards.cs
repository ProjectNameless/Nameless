using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerTowards : MonoBehaviour {
    public GameObject steeringTarget;
    public float steeringDistance;
    public float steeringForce;
    private Rigidbody rb;

    public bool autoTargetPlayer = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (autoTargetPlayer)
            steeringTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        transform.LookAt(new Vector3(steeringTarget.transform.position.x, transform.position.y, steeringTarget.transform.position.z));

        var diff = steeringTarget.transform.position - transform.position;

        if (diff.magnitude > steeringDistance)
        {
            rb.AddForce(diff.normalized * steeringForce);
        } else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
