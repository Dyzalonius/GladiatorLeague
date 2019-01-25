using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : NetworkBehaviour
{
    private PlayerMotor playerMotor;

    private void Start()
    {
        playerMotor = GetComponentInParent<PlayerMotor>();
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
        if (playerMotor.direction != direction)
        {
            playerMotor.direction = direction;
        }
    }
}
