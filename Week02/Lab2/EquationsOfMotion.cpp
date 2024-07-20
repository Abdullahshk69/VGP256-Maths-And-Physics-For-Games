#include "EquationsOfMotion.h"

void EquationsOfMotion::Equation1_vf(const Vector3& vi, const Vector3& a, const float t)
{
	// vf = vi + at
	std::cout << "vf = " << vi + a * t << std::endl;
}

void EquationsOfMotion::Equation1_vi(const Vector3& vf, const Vector3& a, const float t)
{
	// vi = vf - at
	std::cout << "vi = " << vf - a * t << std::endl;
}

void EquationsOfMotion::Equation1_a(const Vector3& vf, const Vector3& vi, const float t)
{
	// a = (vf - vi)/t
	std::cout << "a = " << (vf - vi) / t << std::endl;
}

void EquationsOfMotion::Equation1_t(const Vector3& vf, const Vector3& vi, const Vector3& a)
{
	// t = (vf - vi)/a
	//std::cout << "t = " << (vf - vi) / a << std::endl;
}

void EquationsOfMotion::Equation2_vavg(const Vector3& vi, const Vector3& vf)
{
	// vavg = (vi + vf)/2
	std::cout << "vavg = " << (vi + vf) / 2 << std::endl;
}

void EquationsOfMotion::Equation2_vi(const Vector3& vavg, const Vector3& vf)
{
	// vi = 2vavg - vf
	std::cout << "vi = " << vavg * 2 - vf << std::endl;
}

void EquationsOfMotion::Equation2_vf(const Vector3& vavg, const Vector3& vi)
{
	// vf = 2vavg - vi
	std::cout << "vf = " << vavg * 2 - vi << std::endl;
}

void EquationsOfMotion::Equation3_deltaX(const Vector3& vi, const Vector3& vf, const float t)
{
	// deltaX = (vi + vf) t / 2
	std::cout << "deltaX = " << (vi + vf) * t / 2 << std::endl;
}

void EquationsOfMotion::Equation3_vi(const Vector3& deltaX, const Vector3& vf, const float t)
{
	// vi = (2deltaX) / t - vf
	std::cout << "vi = " << (deltaX * 2) / t - vf << std::endl;
}

void EquationsOfMotion::Equation3_vf(const Vector3& deltaX, const Vector3& vi, const float t)
{
	// vf = (2deltaX) / t - vi
	std::cout << "vf = " << (deltaX * 2) / t - vi << std::endl;
}

void EquationsOfMotion::Equation3_t(const Vector3& deltaX, const Vector3& vf, const Vector3& vi)
{
	// t = 2deltaX / (vi + vf)
}

void EquationsOfMotion::Equation4_deltaX(const Vector3& vi, const float t, const Vector3& a)
{
	// deltaX = vit + at^2/2
	std::cout << "deltaX = " << vi * t + a * t * t / 2 << std::endl;
}

void EquationsOfMotion::Equation4_vi(const Vector3& deltaX, const float t, const Vector3& a)
{
	// vi = (deltaX - at^2/2) / t
	std::cout << "vi = " << (deltaX - a * t * t / 2) / t << std::endl;
}

void EquationsOfMotion::Equation4_t(const Vector3& deltaX, const Vector3& vi, const Vector3& a)
{
	// t = oadifncnc;c;d
}

void EquationsOfMotion::Equation4_a(const Vector3& deltaX, const Vector3& vi, const float t)
{
	// a = (deltaX - vit) * 2 / t^2
	std::cout << "a = " << (deltaX - vi * t) * 2 / t / t << std::endl;
}

void EquationsOfMotion::Equation5_vf(const Vector3& vi, const Vector3& a, const Vector3& deltaX)
{
	// vf^2 = vi^2 + 2 * a * deltaX
	std::cout << "vf^2 = " << vi * vi + a * deltaX * 2 << std::endl;
}

void EquationsOfMotion::Equation5_vi(const Vector3& vf, const Vector3& a, const Vector3& deltaX)
{
	// vi^2 = vf^2 - 2 * a * deltaX
	std::cout << "vi^2 = " << vf * vf - a * deltaX * 2 << std::endl;
}

void EquationsOfMotion::Equation5_a(const Vector3& vf, const Vector3& vi, const Vector3& deltaX)
{

}

void EquationsOfMotion::Equation5_deltaX(const Vector3& vf, const Vector3& vi, const Vector3& a)
{
}
