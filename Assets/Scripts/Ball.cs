using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb = default;
    private Vector3 destination = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddForce(Vector3 fan, float fanStrength)
    {
        destination = -(fan - transform.position);
        rb.AddForce(destination * fanStrength, ForceMode.Acceleration);
    }
}
