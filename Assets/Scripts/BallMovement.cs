using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Transform fanTransform = default;

    private Rigidbody rb = default;
    private Vector3 destination = default;
    private bool powerOn = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            powerOn = !powerOn;
        }
    }

    private void FixedUpdate()
    {
        if (powerOn)
        {
            destination = -(fanTransform.position - transform.position);

            rb.AddForce(destination * 6, ForceMode.Acceleration);
        }
    }
}
