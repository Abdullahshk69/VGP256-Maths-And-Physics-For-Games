using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerIntegration : MonoBehaviour
{
    [SerializeField] private float springConstant;
    [SerializeField] private float mass;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 initialVelocity;

    private float deltaTime;
    private Vector3 position;
    private Vector3 velocity;

    void Start()
    {
        position = initialPosition;
        velocity = initialVelocity;

        deltaTime = Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {
        UpdateEuler();
        transform.position = position;
    }

    void UpdateEuler()
    {
        Vector3 acceleration = ComputeAcceleration(position);

        velocity += acceleration * deltaTime;
        position += velocity * deltaTime;
    }

    Vector3 ComputeAcceleration(Vector3 pos)
    {
        return -springConstant / mass * pos;
    }
}
