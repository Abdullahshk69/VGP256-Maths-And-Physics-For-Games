using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK4Integration : MonoBehaviour
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
        UpdateRK4();
        transform.position = position;
    }

    void UpdateRK4()
    {
        // k1
        Vector3 acceleration1 = ComputeAcceleration(position);
        Vector3 k1_v = deltaTime * acceleration1;
        Vector3 k1_x = deltaTime * velocity;

        // k2
        Vector3 k2_v = deltaTime * ComputeAcceleration(position + k1_x * 0.5f);
        Vector3 k2_x = deltaTime * (velocity + k1_v * 0.5f);

        // k3
        Vector3 k3_v = deltaTime * ComputeAcceleration(position + k2_x * 0.5f);
        Vector3 k3_x = deltaTime * (velocity + k2_v * 0.5f);

        // k4
        Vector3 k4_v = deltaTime * ComputeAcceleration(position + k3_x);
        Vector3 k4_x = deltaTime * (velocity + k3_v);

        velocity += (k1_v + 2.0f * k2_v + 2.0f * k3_v + k4_v) / 6.0f;
        position += (k1_x + 2.0f * k2_x + 2.0f * k3_x + k4_x) / 6.0f;
    }

    Vector3 ComputeAcceleration(Vector3 pos)
    {
        return -(springConstant / mass) * pos;
    }
}
