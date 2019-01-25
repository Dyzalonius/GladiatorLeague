using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMotor : NetworkBehaviour
{
    [HideInInspector] public Vector3 direction;

    [Header("Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementAccelerationFactor;

    private Vector3 lastDirection;
    private float movementAcceleration;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // change acceleration
        if (direction.magnitude > 0)
        {
            movementAcceleration += movementAccelerationFactor;
            lastDirection = direction;
        }
        else
        {
            movementAcceleration -= movementAccelerationFactor;
        }

        // clamp acceleration between 0 and 1
        movementAcceleration = Mathf.Clamp(movementAcceleration, 0f, 1f);

        transform.Translate(lastDirection * movementSpeed * movementAcceleration * Time.fixedDeltaTime, Space.World);
    }
}
