#include <iostream>

#include "Polynomial.h"
#include "EquationsOfMotion.h"
#include "StringToExpression.h"

void Q2();

int main()
{
	StringToExpression s;
	Polynomial p;
	p.AddTerm(s.ConvertToPolynomial("-3x^2+2x^3-1x^5"));
	p.ShowPolynomialEquation();
	//Q2();
}

void Q2()
{
	// vf = vi + at
	float vf, vi, a;
	a = 10;
	vf = 15;
	vi = 20;
	float t = 1.0f;
	Vector3 vavg = { 1.5, 0, 0 };

	// Eq1
	EquationsOfMotion::Equation1("vf", vi, a, t);

	// Eq2

	// Eq3

	// Eq4

	// Eq5

}
