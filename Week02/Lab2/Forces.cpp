#include "Forces.h"

void Forces::SetWeight(Vector3 weight)
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

    Vector3 acceleration = totalForce / 10.0f;
    return acceleration;
}
