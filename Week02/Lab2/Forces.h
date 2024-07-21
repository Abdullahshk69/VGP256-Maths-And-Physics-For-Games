#pragma once

#include <vector>

#include "Vector3.h"

class Forces
{
public:
	void SetWeight(Vector3 weight);
	void AddForce(Vector3 force);
	Vector3 GetResultingAccel();
private:
	std::vector<Vector3>forces;
	Vector3 weight;
};

