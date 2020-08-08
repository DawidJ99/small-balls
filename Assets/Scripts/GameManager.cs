using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Transform LastCheckpoint { get => lastCheckpoint; set => lastCheckpoint = value; }

    [SerializeField] private Ball ball = default;
    [SerializeField] private Transform lastCheckpoint = default;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    public void Respawn()
    {
        FanManager.Instance.PowerOn = false;
        ball.Respawn(lastCheckpoint.position);
    }
}
