using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target = default;
    [SerializeField] private float mouseSpeed = 8f;
    [SerializeField] private float followSpeed = 10f;
    [SerializeField] private float minAngle = -35f;
    [SerializeField] private float maxAngle = 35f;

    private Transform camTransform = default;
    private Transform pivot = default;
    private float mouseX = default;
    private float mouseY = default;
    private float turnSmooth = 0.1f;
    private float smoothX = 0f;
    private float smoothY = 0f;
    private float smoothXVelocity = 0f;
    private float smoothYVelocity = 0f;
    private float lookAngle = 0f;
    private float tiltAngle = 0f;

    public void Awake()
    {
        camTransform = Camera.main.transform;
        pivot = camTransform.parent;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        Vector3 followPosition = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
        transform.position = followPosition;

        if (turnSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, turnSmooth);
            smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, turnSmooth);
        }
        else
        {
            smoothX = mouseX;
            smoothY = mouseY;
        }

        tiltAngle -= smoothY * mouseSpeed;

        lookAngle += smoothX * mouseSpeed;
        transform.rotation = Quaternion.Euler(0, lookAngle, 0);

        tiltAngle = Mathf.Clamp(tiltAngle, minAngle, maxAngle);
        pivot.localRotation = Quaternion.Euler(tiltAngle, 0, 0);

    }


}
