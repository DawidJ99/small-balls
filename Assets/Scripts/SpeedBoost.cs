using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float strength = 5f;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.AddForce(transform.forward, strength);
        }
    }
}
