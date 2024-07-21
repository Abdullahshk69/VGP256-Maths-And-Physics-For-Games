#pragma once
#include "Vector3.h"
#include <string>
#include <tuple>

class EquationsOfMotion
{
public:
	template<typename... Args>
	static void Equation1(Args&&... args);

	template<typename... Args>
	static void Equation2(Args&&... args);

	template<typename... Args>
	static void Equation3(Args&&... args);

	template<typename... Args>
	static void Equation4(Args&&... args);

	template<typename... Args>
	static void Equation5(Args&&... args);
};

template<typename... Args>
inline void EquationsOfMotion::Equation1(Args&&... args)
{
	auto arguments = std::make_tuple(std::forward<Args>(args)...);
	int size = std::tuple_size<decltype(arguments)>::value;
	if (size < 4)
	{
		std::cout << "At least provide 4 arguments";
		return;
	}

	std::string variableToFind = std::get<0>(arguments);

	if (variableToFind == "vf")
	{
		float vi = std::get<1>(arguments);
		float a = std::get<2>(arguments);
		float t = std::get<3>(arguments);

		std::cout << "vf = " << vi + a * t << std::endl;
	}

	else if (variableToFind == "vi")
	{
		float vf = std::get<1>(arguments);
		float a = std::get<2>(arguments);
		float t = std::get<3>(arguments);

		std::cout << "vi = " << vf - a * t << std::endl;
	}

	else if (variableToFind == "a")
	{
		float vf = std::get<1>(arguments);
		float vi = std::get<2>(arguments);
		float t = std::get<3>(arguments);

		std::cout << "a = " << (vf - vi) / t << std::endl;
	}

	else if (variableToFind == "t")
	{
		float vf = std::get<1>(arguments);
		float vi = std::get<2>(arguments);
		float a = std::get<3>(arguments);

		std::cout << "t = " << (vf - vi) / a << std::endl;
	}

	else
	{
		std::cout << "Incorrect variable asked" << std::endl;
	}
	
}

template<typename ...Args>
inline void EquationsOfMotion::Equation2(Args && ...args)
{
	auto arguments = std::make_tuple(std::forward<Args>(args)...);
	int size = std::tuple_size<decltype(arguments)>::value;
	if (size < 3)
	{
		std::cout << "At least provide 3 arguments";
		return;
	}

	std::string variableToFind = std::get<0>(arguments);

	if (variableToFind == "vavg")
	{
		float vi = std::get<1>(arguments);
		float vf = std::get<2>(arguments);

		std::cout << "vavg = " << (vi + vf) / 2 << std::endl;
	}

	else if (variableToFind == "vi")
	{
		float vavg = std::get<1>(arguments);
		float vf = std::get<2>(arguments);

		std::cout << "vi = " << vavg * 2 - vf << std::endl;
	}

	else if (variableToFind == "vf")
	{
		float vavg = std::get<1>(arguments);
		float vi = std::get<2>(arguments);

		std::cout << "vf = " << vavg * 2 - vi << std::endl;
	}

	else
	{
		std::cout << "Incorrect variable asked" << std::endl;
	}
}

template<typename ...Args>
inline void EquationsOfMotion::Equation3(Args && ...args)
{
	auto arguments = std::make_tuple(std::forward<Args>(args)...);
	int size = std::tuple_size<decltype(arguments)>::value;
	if (size < 4)
	{
		std::cout << "At least provide 4 arguments";
		return;
	}

	std::string variableToFind = std::get<0>(arguments);


	if (variableToFind == "deltaX")
	{
		float vi = std::get<1>(arguments);
		float vf = std::get<2>(arguments);
		float t = std::get<3>(arguments);

		// deltaX = (vi + vf) t / 2
		std::cout << "deltaX = " << (vi + vf) * t / 2 << std::endl;
	}

	else if (variableToFind == "vi")
	{
		float deltaX = std::get<1>(arguments);
		float vf = std::get<2>(arguments);
		float t = std::get<3>(arguments);

		// vi = (2deltaX) / t - vf
		std::cout << "vi = " << (deltaX * 2) / t - vf << std::endl;
	}

	else if (variableToFind == "vf")
	{
		float deltaX = std::get<1>(arguments);
		float vi = std::get<2>(arguments);
		float t = std::get<3>(arguments);

		// vf = (2deltaX) / t - vi
		std::cout << "vf = " << (deltaX * 2) / t - vi << std::endl;
	}

	else if (variableToFind == "t")
	{
		float deltaX = std::get<1>(arguments);
		float vf = std::get<2>(arguments);
		float vi = std::get<3>(arguments);

		// t = 2deltaX / (vi + vf)
		std::cout << "t = " << 2 * deltaX / (vi + vf) << std::endl;
	}

	else
	{
		std::cout << "Incorrect variable asked" << std::endl;
	}
}

template<typename ...Args>
inline void EquationsOfMotion::Equation4(Args && ...args)
{
	auto arguments = std::make_tuple(std::forward<Args>(args)...);
	int size = std::tuple_size<decltype(arguments)>::value;
	if (size < 4)
	{
		std::cout << "At least provide 4 arguments";
		return;
	}

	std::string variableToFind = std::get<0>(arguments);

	if (variableToFind == "deltaX")
	{
		float vi = std::get<1>(arguments);
		float t = std::get<2>(arguments);
		float a = std::get<3>(arguments);

		// deltaX = vit + at^2/2
		std::cout << "deltaX = " << vi * t + a * t * t / 2 << std::endl;
	}

	else if (variableToFind == "vi")
	{
		float deltaX = std::get<1>(arguments);
		float t = std::get<2>(arguments);
		float a = std::get<3>(arguments);

		// vi = (deltaX - at^2/2) / t
		std::cout << "vi = " << (deltaX - a * t * t / 2) / t << std::endl;
	}

	else if (variableToFind == "t")
	{
		float deltaX = std::get<1>(arguments);
		float vi = std::get<2>(arguments);
		float a = std::get<3>(arguments);

		// Using quadratic formula (simplified)
		// t = (-vi + sqrt(vi^2 + 2a deltaX))/a
		std::cout << "t = " << (-vi + sqrtf(vi ^ 2 + 2 * a * deltaX)) / a << std::endl;
	}

	else if (variableToFind == "a")
	{
		float deltaX = std::get<1>(arguments);
		float vi = std::get<2>(arguments);
		float t = std::get<3>(arguments);

		// a = (deltaX - vit) * 2 / t^2
		std::cout << "a = " << (deltaX - vi * t) * 2 / t / t << std::endl;
	}

	else
	{
		std::cout << "Incorrect variable asked" << std::endl;
	}
}

template<typename ...Args>
inline void EquationsOfMotion::Equation5(Args && ...args)
{
	auto arguments = std::make_tuple(std::forward<Args>(args)...);
	int size = std::tuple_size<decltype(arguments)>::value;
	if (size < 4)
	{
		std::cout << "At least provide 4 arguments";
		return;
	}

	std::string variableToFind = std::get<0>(arguments);

	if (variableToFind == "vf")
	{
		float vi = std::get<1>(arguments);
		float a = std::get<2>(arguments);
		float deltaX = std::get<3>(arguments);

		// vf^2 = vi^2 + 2 * a * deltaX
		std::cout << "vf = " << sqrtf(vi * vi + a * deltaX * 2) << std::endl;
	}

	else if (variableToFind == "vi")
	{
		float vf = std::get<1>(arguments);
		float a = std::get<2>(arguments);
		float deltaX = std::get<3>(arguments);

		// vi^2 = vf^2 - 2 * a * deltaX
		std::cout << "vi = " << sqrtf(abs(vf * vf - a * deltaX * 2)) << std::endl;
	}

	else if (variableToFind == "a")
	{
		float vf = std::get<1>(arguments);
		float vi = std::get<2>(arguments);
		float deltaX = std::get<3>(arguments);

		// a = (vf^2-vi^2)/2deltaX
		std::cout << "a = " << (vf ^ 2 - vi ^ 2) / 2 * deltaX << std::endl;
	}

	else if (variableToFind == "deltaX")
	{
		float vf = std::get<1>(arguments);
		float vi = std::get<2>(arguments);
		float a = std::get<3>(arguments);

		// deltaX = (vf^2-vi^2)/2a 
		std::cout << "deltaX = " << (vf ^ 2 - vi ^ 2) / 2 * a << std::endl;
	}

	else
	{
		std::cout << "Incorrect variable asked" << std::endl;
	}
}
