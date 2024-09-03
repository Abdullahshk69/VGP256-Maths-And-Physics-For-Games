using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerletIntegration : MonoBehaviour
{
    [SerializeField] private float mass;
    [SerializeField] private float springConstant;

    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 initialVelocity;

    Vector3 previousPosition;
    private Vector3 position;
    private Vector3 velocity;

    private void Start()
    {
        position = initialPos;
        velocity = initialVelocity;

        previousPosition = position - velocity * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        UpdateVerlet();
        transform.position = position;
    }

    void UpdateVerlet()
    {
        Vector3 acceleration = ComputeAcceleration(position);
        Vector3 newPosition = 2.0f * position - previousPosition + acceleration * Time.fixedDeltaTime * Time.fixedDeltaTime;

        previousPosition = position;
        position = newPosition;
    }

    Vector3 ComputeAcceleration(Vector3 pos)
    {
        return -springConstant / mass * pos;
    }
}
