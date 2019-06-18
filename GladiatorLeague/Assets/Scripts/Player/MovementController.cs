using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementMotor))]
public class MovementController : MonoBehaviour
{
    private MovementMotor movementMotor;

    private void Start()
    {
        movementMotor = GetComponentInParent<MovementMotor>();
    }

    private void Update()
    {
        // Get movement input
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            direction.z++;
        if (Input.GetKey(KeyCode.A))
            direction.x--;
        if (Input.GetKey(KeyCode.S))
            direction.z--;
        if (Input.GetKey(KeyCode.D))
            direction.x++;

        // Update direction if it's new
        if (movementMotor.direction != direction)
        {
            movementMotor.direction = direction;
        }
    }
}
