#include <iostream>

#include "Polynomial.h"
#include "EquationsOfMotion.h"
#include "StringToExpression.h"
#include "Derivative.h"
#include "Forces.h"

void Q1();
void Q2();
void Q3();

int main()
{
	Q1();
	Q2();
	Q3();
}

void Q1()
{
	std::string input;
	std::cout << "Enter a polynomial expression in the form of ax + b (constant at the end): ";
	std::cin >> input;

	StringToExpression stringToExpression;
	Polynomial polynomial;

	polynomial.AddTerm(stringToExpression.ConvertToPolynomial(input));
	std::cout << "Position: ";
	polynomial.ShowPolynomialEquation();

	Polynomial velocity = Derivative::SingleDerivative(polynomial.GetPolynomial());
	std::cout << "Velocity: ";
	velocity.ShowPolynomialEquation();

	Polynomial acceleration = Derivative::SingleDerivative(velocity.GetPolynomial());
	std::cout << "Acceleration: ";
	acceleration.ShowPolynomialEquation();

	int x;
	std::cout << std::endl << "Write value of x: ";
	std::cin >> x;

	std::cout << "Velocity = " << velocity.CalculateX(x) << std::endl;
	std::cout << "Acceleration = " << acceleration.CalculateX(x) << std::endl;

}

void Q2()
{
	float vf, vi, a, t, vavg, deltaX;
	int equation;

	std::cout << "What equation do you want to use? " << std::endl <<
		"[1] Equation 1" << std::endl <<
		"[2] Equation 2" << std::endl <<
		"[3] Equation 3" << std::endl <<
		"[4] Equation 4" << std::endl <<
		"[5] Equation 5" << std::endl;
	std::cout << "Equation: ";
	std::cin >> equation;

	switch (equation)
	{
	case 1:
	{
		int choice;
		std::cout << "Which variable would you like to find?" << std::endl <<
			"[1] vf = vi + at" << std::endl <<
			"[2] vi = vf - at" << std::endl <<
			"[3] a = (vf - vi) / t" << std::endl <<
			"[4] t = (vf - vi) / a" << std::endl;
		std::cout << "Chocie: ";
		std::cin >> choice;

		switch (choice)
		{
		case 1:
		{
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "a = ";
			std::cin >> a;
			std::cout << "t = ";
			std::cin >> t;

			EquationsOfMotion::Equation1("vf", vi, a, t);
		}
		break;

		case 2:
		{
			std::cout << "vf = ";
			std::cin >> vf;
			std::cout << "a = ";
			std::cin >> a;
			std::cout << "t = ";
			std::cin >> t;

			EquationsOfMotion::Equation1("vi", vf, a, t);
		}
		break;

		case 3:
		{
			std::cout << "vf = ";
			std::cin >> vf;
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "t = ";
			std::cin >> t;

			EquationsOfMotion::Equation1("a", vf, vi, t);
		}
		break;

		case 4:
		{
			std::cout << "vf = ";
			std::cin >> vf;
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "a = ";
			std::cin >> a;

			EquationsOfMotion::Equation1("t", vf, vi, a);
		}
		break;

		default:
		{
			std::cout << "Incorrect Input!" << std::endl;
		}
		break;
		}
	}
	break;

	case 2:
	{
		int choice;
		std::cout << "Which variable would you like to find?" << std::endl <<
			"[1] vavg = (vi + vf) / 2" << std::endl <<
			"[2] vi = 2vavg - vf" << std::endl <<
			"[3] vf = 2vavg - vi" << std::endl;
		std::cout << "Chocie: ";
		std::cin >> choice;

		switch (choice)
		{
		case 1:
		{
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "vf = ";
			std::cin >> vf;

			EquationsOfMotion::Equation2("vavg", vi, vf);
		}
		break;

		case 2:
		{
			std::cout << "vavg = ";
			std::cin >> vavg;
			std::cout << "vf = ";
			std::cin >> vf;

			EquationsOfMotion::Equation2("vi", vavg, vf);
		}
		break;

		case 3:
		{
			std::cout << "vavg = ";
			std::cin >> vavg;
			std::cout << "vi = ";
			std::cin >> vi;

			EquationsOfMotion::Equation2("vf", vavg, vi);
		}
		break;

		default:
		{
			std::cout << "Incorrect Input!" << std::endl;
		}
		break;
		}
	}
	break;

	case 3:
	{
		int choice;
		std::cout << "Which variable would you like to find?" << std::endl <<
			"[1] deltaX = (vi + vf) t / 2" << std::endl <<
			"[2] vi = (2deltaX) / t - vf" << std::endl <<
			"[3] vf = (2deltaX) / t - vi" << std::endl <<
			"[4] t = 2deltaX / (vi + vf)" << std::endl;
		std::cout << "Chocie: ";
		std::cin >> choice;

		switch (choice)
		{
		case 1:
		{
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "vf = ";
			std::cin >> vf;
			std::cout << "t = ";
			std::cin >> t;

			EquationsOfMotion::Equation3("deltaX", vi, vf, t);
		}
		break;

		case 2:
		{
			std::cout << "deltaX = ";
			std::cin >> deltaX;
			std::cout << "vf = ";
			std::cin >> vf;
			std::cout << "t = ";
			std::cin >> t;

			EquationsOfMotion::Equation3("vi", deltaX, vf, t);
		}
		break;

		case 3:
		{
			std::cout << "deltaX = ";
			std::cin >> deltaX;
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "t = ";
			std::cin >> t;

			EquationsOfMotion::Equation3("vf", deltaX, vi, t);
		}
		break;

		case 4:
		{
			std::cout << "deltaX = ";
			std::cin >> deltaX;
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "vf = ";
			std::cin >> vf;

			EquationsOfMotion::Equation3("t", deltaX, vi, vf);
		}
		break;

		default:
		{
			std::cout << "Incorrect Input!" << std::endl;
		}
		break;
		}
	}
	break;

	case 4:
	{
		int choice;
		std::cout << "Which variable would you like to find?" << std::endl <<
			"[1] deltaX = vit + at^2 / 2" << std::endl <<
			"[2] vi = (deltaX - at^2/2) / t" << std::endl <<
			"[3] t = (-vi + sqrt(vi^2 + 2a deltaX))/a" << std::endl <<
			"[4] a = (deltaX - vit) * 2 / t^2" << std::endl;
		std::cout << "Chocie: ";
		std::cin >> choice;

		switch (choice)
		{
		case 1:
		{
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "t = ";
			std::cin >> t;
			std::cout << "a = ";
			std::cin >> a;

			EquationsOfMotion::Equation4("deltaX", vi, t, a);
		}
		break;

		case 2:
		{
			std::cout << "deltaX = ";
			std::cin >> deltaX;
			std::cout << "t = ";
			std::cin >> t;
			std::cout << "a = ";
			std::cin >> a;

			EquationsOfMotion::Equation4("vi", deltaX, t, a);
		}
		break;

		case 3:
		{
			std::cout << "deltaX = ";
			std::cin >> deltaX;
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "a = ";
			std::cin >> a;

			EquationsOfMotion::Equation4("vi", deltaX, vi, a);
		}
		break;

		case 4:
		{
			std::cout << "deltaX = ";
			std::cin >> deltaX;
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "t = ";
			std::cin >> t;

			EquationsOfMotion::Equation4("vi", deltaX, vi, t);
		}
		break;

		default:
		{
			std::cout << "Incorrect Input!" << std::endl;
		}
		break;
		}
	}
	break;

	case 5:
	{
		int choice;
		std::cout << "Which variable would you like to find?" << std::endl <<
			"[1] vf = sqrt(vi^2 + 2 * a * deltaX)" << std::endl <<
			"[2] vi = sqrt(vf^2 - 2 * a * deltaX)" << std::endl <<
			"[3] a = (vf^2-vi^2)/2deltaX" << std::endl <<
			"[4] deltaX = (vf^2-vi^2)/2a " << std::endl;
		std::cout << "Chocie: ";
		std::cin >> choice;

		switch (choice)
		{
		case 1:
		{
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "a = ";
			std::cin >> a;
			std::cout << "deltaX = ";
			std::cin >> deltaX;

			EquationsOfMotion::Equation5("vf", vi, a, deltaX);
		}
		break;

		case 2:
		{
			std::cout << "vf = ";
			std::cin >> vf;
			std::cout << "a = ";
			std::cin >> a;
			std::cout << "deltaX = ";
			std::cin >> deltaX;

			EquationsOfMotion::Equation5("vi", vf, a, deltaX);
		}
		break;

		case 3:
		{
			std::cout << "vf = ";
			std::cin >> vf;
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "deltaX = ";
			std::cin >> deltaX;

			EquationsOfMotion::Equation5("a", vf, vi, deltaX);
		}
		break;

		case 4:
		{
			std::cout << "vf = ";
			std::cin >> vf;
			std::cout << "vi = ";
			std::cin >> vi;
			std::cout << "a = ";
			std::cin >> a;

			EquationsOfMotion::Equation5("deltaX", vf, vi, a);
		}
		break;

		default:
		{
			std::cout << "Incorrect Input!" << std::endl;
		}
		break;
		}
	}
	break;

	default:
	{
		std::cout << "Incorrect Input!" << std::endl;
	}
	break;
	}

}

void Q3()
{
	float weight;
	int numberOfForces;
	Vector3 force;
	Forces forces;

	std::cout << "Enter number of forces: ";
	std::cin >> numberOfForces;

	for (size_t t = 0; t < numberOfForces; t++)
	{
		std::cout << "Force " << t+1 << ":";
		std::cin >> force;
		forces.AddForce(force);
	}

	std::cout << "Enter weight of the object: ";
	std::cin >> weight;
	forces.SetWeight(weight);

	std::cout << "Acceleration on this body: " <<
		forces.GetResultingAccel();
}
