#pragma once
#include <iostream>

struct Vector3
{
	float x;
	float y;
	float z;

	Vector3 operator+(const Vector3& other) const { return { x + other.x, y + other.y, z + other.z }; }

	Vector3 operator-(const Vector3& other) const { return { x - other.x, y - other.y, z - other.z }; }

	Vector3 operator*(const float& other) const { return { x * other, y * other, z * other }; }

	float operator*(const Vector3& other) const { return x * other.x + y * other.y + z * other.z; }

	Vector3 operator/(const float& other) const { return { x / other, y / other,z / other }; }

	friend std::ostream& operator<<(std::ostream& os, const Vector3& vector)
	{
		os << "{ " << vector.x << ", " << vector.y << ", " << vector.z << " }";
		return os;
	}

	friend std::istream& operator>>(std::istream& is, Vector3& vector)
	{
		std::cout << "x: ";
		is >> vector.x;
		std::cout << "y: ";
		is >> vector.y;
		std::cout << "z: ";
		is >> vector.z;
		return is;
	}
};

