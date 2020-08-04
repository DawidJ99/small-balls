using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb = default;
    private Vector3 respawnPoint = Vector3.zero;

    public void Init(Vector3 respawnPoint)
    {
        rb = GetComponent<Rigidbody>();
        this.respawnPoint = respawnPoint;
    }

    public void AddForce(Vector3 destination, float strength)
    {
        rb.AddForce(destination * strength, ForceMode.Acceleration);
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
    }
}
