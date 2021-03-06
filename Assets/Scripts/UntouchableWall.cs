﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntouchableWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ball ball))
        {
            GameManager.Instance.Respawn();
        }
    }
}
