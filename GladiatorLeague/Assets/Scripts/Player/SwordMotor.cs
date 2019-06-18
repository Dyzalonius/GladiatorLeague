using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMotor : MonoBehaviour
{
    [HideInInspector] public Vector3 swordTargetPosition;

    [Header("References")]
    [SerializeField] private Transform character;
    [Header("Settings")]
    [SerializeField] private float positionOffset; // Offset of shoulder.
    [SerializeField] private float maxDistance; // Max distance of sword from shoulder.

    private Vector3 swordPosition;

    private void Start()
	{

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 swordPositionNew = swordTargetPosition;

        // clamp distance of swordposition to character
        if (Vector3.Distance(character.position, swordPositionNew) > maxDistance)
        {
            Vector3 direction = (swordTargetPosition - character.position).normalized;
            swordPositionNew = character.position + direction * maxDistance;
        }
        swordPosition = swordPositionNew;

        transform.position = swordPosition;
        transform.LookAt(character); //replace with shoulderposition
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(swordTargetPosition, Vector3.one * 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(swordPosition, Vector3.one * 0.5f);
    }
}
