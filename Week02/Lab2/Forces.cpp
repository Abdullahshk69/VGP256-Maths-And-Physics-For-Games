#include "Forces.h"

void Forces::SetWeight(float weight)
{
    this->weight = weight;
}

void Forces::AddForce(Vector3 force)
{
    forces.push_back(force);
}

Vector3 Forces::GetResultingAccel()
{
    // Add all forces
    Vector3 totalForce = Vector3{ 0, 0, 0 };

    for (Vector3& force : forces)
    {
        totalForce = totalForce + force;
    }

    float mass = weight / 9.8f;

    // f = ma
    // a = f/m
    Vector3 acceleration = totalForce / mass;
    return acceleration;
}
