using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMotor : MonoBehaviour
{
    [HideInInspector] public Vector3 mousePos;

    [Header("References")]
    [SerializeField] private Transform character;
    [Header("Settings")]
    [SerializeField] private float maxDistance; // Max distance of sword from shoulder.
    [SerializeField] public float weaponHeight;

    private Vector3 swordPos, mousePosClamped, shoulderPos;
    private Vector3 direction;
    private float swordSpeed, swordAcceleration;

    private void Start()
	{
        swordSpeed = 1f;
    }

    private void FixedUpdate()
    {
        UpdatePositions();
        Move();
    }

    private void UpdatePositions()
    {
        shoulderPos = character.position + new Vector3(0, weaponHeight);
        mousePosClamped = shoulderPos + Vector3.ClampMagnitude(mousePos - shoulderPos, maxDistance);

        // 1: calculate acceleration of sword based on directiondifference between mousePosClamped and sword
        // 2: calculate speed of sword based on acceleration of sword
        // 3: calculate swordPos based on speed of sword
        direction = (mousePosClamped - shoulderPos).normalized;

        swordPos = Vector3.Slerp(swordPos, mousePosClamped, 0.2f); //temp
    }

    private void Move()
    {
        transform.position = swordPos;
        transform.LookAt(shoulderPos);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(swordPos, Vector3.one * 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(mousePosClamped, Vector3.one * 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(mousePos, Vector3.one * 0.5f);
    }
}
