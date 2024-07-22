#pragma once

#include <ostream>

struct Term
{
	int a;	// Coefficient
	int e;	// Power

	friend std::ostream& operator <<(std::ostream& os, const Term& term)
	{
		os << term.a;
		if(term.e != 0)
		{
			os << "x^" << term.e;
		}
		return os;
	}
};
