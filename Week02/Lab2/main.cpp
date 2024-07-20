#include <iostream>

#include "Polynomial.h"
#include "EquationsOfMotion.h"

void Q2();

int main()
{
	EquationsOfMotion::Equation1("vf", 10, 1, 2);
	//Q2();
}

void Q2()
{
	// vf = vi + at
	Vector3 vf, vi, a;
	a = { 1, 0, 0 };
	vf = { 2, 0, 0 };
	vi = { 1, 0, 0 };
	float t = 1.0f;
	Vector3 vavg = { 1.5, 0, 0 };

	// Eq1
	EquationsOfMotion::Equation1_vf(vi, a, t);
	EquationsOfMotion::Equation1_vi(vf, a, t);
	EquationsOfMotion::Equation1_a(vf, vi, t);

	
	// Eq2
	EquationsOfMotion::Equation2_vavg(vi, vf);
	EquationsOfMotion::Equation2_vi(vavg, vf);
	EquationsOfMotion::Equation2_vf(vavg, vi);

	// Eq3

	// Eq4

	// Eq5

}
