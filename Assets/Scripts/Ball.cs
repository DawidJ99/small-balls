using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb = default;

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddForce(Vector3 destination, float strength)
    {
        rb.AddForce(destination * strength, ForceMode.Acceleration);
    }

    public void Respawn(Vector3 respawnPoint)
    {
        transform.position = respawnPoint;
    }
}
