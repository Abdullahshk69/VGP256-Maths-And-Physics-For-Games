#pragma once
#include "Vector3.h"
#include <string>
#include <tuple>

class EquationsOfMotion
{
public:
	static void Equation1_vf(const Vector3& vi, const Vector3& a, const float t);
	static void Equation1_vi(const Vector3& vf, const Vector3& a, const float t);
	static void Equation1_a(const Vector3& vf, const Vector3& vi, const float t);
	static void Equation1_t(const Vector3& vf, const Vector3& vi, const Vector3& a);

	static void Equation2_vavg(const Vector3& vi, const Vector3& vf);
	static void Equation2_vi(const Vector3& vavg, const Vector3& vf);
	static void Equation2_vf(const Vector3& vavg, const Vector3& vi);

	static void Equation3_deltaX(const Vector3& vi, const Vector3& vf, const float t);
	static void Equation3_vi(const Vector3& deltaX, const Vector3& vf, const float t);
	static void Equation3_vf(const Vector3& deltaX, const Vector3& vi, const float t);
	static void Equation3_t(const Vector3& deltaX, const Vector3& vf, const Vector3& vi);

	static void Equation4_deltaX(const Vector3& vi, const float t, const Vector3& a);
	static void Equation4_vi(const Vector3& deltaX, const float t, const Vector3& a);
	static void Equation4_t(const Vector3& deltaX, const Vector3& vi, const Vector3& a);
	static void Equation4_a(const Vector3& deltaX, const Vector3& vi, const float t);

	static void Equation5_vf(const Vector3& vi, const Vector3& a, const Vector3& deltaX);
	static void Equation5_vi(const Vector3& vf, const Vector3& a, const Vector3& deltaX);
	static void Equation5_a(const Vector3& vf, const Vector3& vi, const Vector3& deltaX);
	static void Equation5_deltaX(const Vector3& vf, const Vector3& vi, const Vector3& a);

	template<typename... Args>
	static void Equation1(Args&&... args);
};

template<typename... Args>
inline void EquationsOfMotion::Equation1(Args&&... args)
{
	auto arguments = std::make_tuple(std::forward<Args>(args)...);
	std::cout << std::get<0>(arguments);
	float a = std::get<1>(arguments);
	std::cout << a;

	//std::string variableToFind = (std::string)args[0];
	
	/*switch (num)
	{
	case num:
	{
		float vi = (float)args[1];
		float a = (float)args[2];
		float t = (float)args[3];
		std::cout << "vf = " << vi + a * t << std::endl;
	}
	break;

	}*/
	
}
