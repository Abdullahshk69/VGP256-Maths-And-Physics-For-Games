#include "Polynomial.h"
#include <iostream>

Polynomial::Polynomial()
{
}

std::vector<Term> Polynomial::GetTerm()
{
	return terms;
}

void Polynomial::AddTerm(Term term)
{
	terms.push_back(term);
}

void Polynomial::AddTerm(std::vector<Term> terms)
{
	this->terms = terms;
}

void Polynomial::ShowPolynomialEquation()
{
	std::cout << terms[0];
	for (size_t t = 1; t < terms.size(); t++)
	{
		if (terms[t].a >= 0)
		{
			std::cout << "+";
		}
		std::cout << terms[t];
	}
	std::cout << std::endl;
}
