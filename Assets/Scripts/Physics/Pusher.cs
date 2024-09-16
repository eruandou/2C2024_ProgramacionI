using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField] private float pushForce;
    [SerializeField] private Vector3 pushDirection;
    [SerializeField] private float initialTemp;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform forcePosition;

    private float currentTime;

    private void Awake()
    {
        currentTime = initialTemp;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime > 0)
        {
            return;
        }

        currentTime = initialTemp;
        Push();
    }

    private void Push()
    {
        rb.AddForceAtPosition(pushDirection * pushForce, forcePosition.position, ForceMode.Impulse);
    }
}