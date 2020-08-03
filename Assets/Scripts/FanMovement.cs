using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FanMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform target = default;

    private float horizontal = default;
    private float fanAngle = default;

    private void Update()
    {
        transform.position = target.position;

        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        fanAngle -= horizontal;
        transform.localRotation = Quaternion.Euler(0, fanAngle, 0);

    }
}
