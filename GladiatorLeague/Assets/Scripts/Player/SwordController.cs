using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwordMotor))]
public class SwordController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform character;
    [SerializeField] private Camera camera;
    [Header("Settings")]
    [SerializeField] private float weaponHeight;

    private SwordMotor swordMotor;
    private Plane plane;

    private void Start()
    {
        swordMotor = GetComponentInParent<SwordMotor>();
        plane = new Plane(Vector3.up, -weaponHeight);
    }
	
	private void Update()
	{
        float dist;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out dist))
        {
            Vector3 point = ray.GetPoint(dist);
            swordMotor.swordTargetPosition = point;
        }
    }
}
