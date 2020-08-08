using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FanManager : MonoBehaviour
{
    #region Properties
    public static FanManager Instance { get; set; }
    
    public bool PowerOn { get => powerOn; set => powerOn = value; }

    #endregion

    [SerializeField] private Transform fan = default;
    [SerializeField] private Ball ball = default;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float fanStrength = 5f;
    [SerializeField] private bool powerOn = false;
    
    private float horizontal = default;
    private float fanAngle = default;
    private float smoothXVelocity = 0f;

    private float dirAngle = 0;

    private void Awake()
    {
        if (!Instance)
            Instance = this;

        ball.Init();
    }

    private void Update()
    {
        transform.position = ball.transform.position;

        if (Input.GetButtonDown("Power"))
        {
            powerOn = !powerOn;
        }        

        horizontal = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(ball.transform.position, Vector3.down, out hit, 0.6f))
        {
            float angle = 90 - Vector3.Angle(hit.normal, -Vector3.forward);
            dirAngle = Mathf.SmoothDampAngle(dirAngle, angle, ref smoothXVelocity, 0.1f);
        }

        fanAngle -= horizontal;
        transform.localRotation = Quaternion.Euler(-dirAngle, fanAngle, 0);

    }

    private void FixedUpdate()
    {
        if (powerOn)
        {
            ball.AddForce(-(fan.position - ball.transform.position), fanStrength);
        }
    }


}
