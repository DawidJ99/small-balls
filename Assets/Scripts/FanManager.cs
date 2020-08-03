using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FanManager : MonoBehaviour
{
    [SerializeField] private Transform fan = default;
    [SerializeField] private Ball target = default;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float fanStrength = 5f;
    [SerializeField] private bool powerOn = false;
    
    private float horizontal = default;
    private float fanAngle = default;

    private void Update()
    {
        transform.position = target.transform.position;

        if (Input.GetButtonDown("Power"))
        {
            powerOn = !powerOn;
        }        

        horizontal = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        fanAngle -= horizontal;
        transform.localRotation = Quaternion.Euler(0, fanAngle, 0);

    }

    private void FixedUpdate()
    {
        if (powerOn)
        {
            target.AddForce(fan.position, fanStrength);
        }
    }


}
